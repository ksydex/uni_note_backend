using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniNote.Application.Dtos;
using UniNote.Application.Modules.AuthenticationService.Models;
using UniNote.Application.Modules.TokenGenerator;
using UniNote.Core.Exceptions;
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

    public async Task<InitialData> AuthenticateWithCredentials(string email, string password)
    {
        var user = await _repository.Queryable<User>()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => string.Equals(x.Email, email, StringComparison.CurrentCultureIgnoreCase));

        if (user == null) throw new NotFoundException();
        
        // IMPL password compare
        
        return await GenerateInitialDataAsync(user.Id);
    }

    public async Task<InitialData> AuthenticateWithRefreshToken(string refreshToken)
    {
        var token = await _repository.Queryable<RefreshToken>().SingleOrDefaultAsync(x => x.Token == refreshToken);
        if (token == null) throw new NotFoundException("");

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