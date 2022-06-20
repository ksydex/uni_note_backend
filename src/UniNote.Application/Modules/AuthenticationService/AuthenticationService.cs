using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.AuthenticationService.Models;
using UniNote.Application.Modules.TokenGenerator;
using UniNote.Core.Exceptions;
using UniNote.Core.Helpers;
using UniNote.Data.Common;
using UniNote.Domain.Entities;

namespace UniNote.Application.Modules.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRepository _repository;
    private readonly ITokenGenerator _tokenGenerator;

    private readonly IMapper _mapper;

    public AuthenticationService(IRepository repository, ITokenGenerator tokenGenerator, IMapper mapper)
    {
        _repository = repository;
        _tokenGenerator = tokenGenerator;
        _mapper = mapper;
    }

    public async Task SignUpAsync(string email, string password, string name)
    {
        if (await _repository.Queryable<User>()
                .AnyAsync(x => x.Email.ToLower() == email.ToLower()))
            throw new ConflictException();

        var user = new User { Email = email, PasswordHashed = Hasher.Hash(password), Name = name};
        await _repository.AddAndSaveChangesAsync(user);
    }

    public async Task<InitialData> AuthenticateWithCredentials(string email, string password)
    {
        var user = await _repository.Queryable<User>()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

        if (user == null) throw new NotFoundException();

        // IMPL password compare

        return await GenerateInitialDataAsync(user.Id);
    }

    public async Task<InitialData> AuthenticateWithRefreshToken(string refreshToken)
    {
        var token = await _repository.Queryable<RefreshToken>().SingleOrDefaultAsync(x => x.Token == refreshToken);
        if (token == null) throw new NotFoundException("");

        await _repository.RemoveAndSaveChangesAsync(token);

        return await GenerateInitialDataAsync(token.UserId);
    }

    private async Task<InitialData> GenerateInitialDataAsync(int userId)
    {
        var user = await _repository.Queryable<User>()
            .AsNoTracking()
            .SingleAsync(x => x.Id == userId);

        var refreshToken = await _tokenGenerator.CreateRefreshTokenAsync(user);
        var accessToken = _tokenGenerator.GenerateAccessToken(user);

        return new InitialData(refreshToken.Token, accessToken, _mapper.Map<UserDto>(user));
    }
}