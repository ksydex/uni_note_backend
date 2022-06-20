
using FastEndpoints;
using FluentValidation;
using UniNote.Application.Modules.AuthenticationService;
using UniNote.Application.Modules.AuthenticationService.Models;

namespace UniNote.Api.Endpoints.Auth;

public record AuthWithRefreshTokenEndpointRequest
{
    public string RefreshToken { get; set; } = "";
}

public class AuthWithRefreshTokenEndpointRequestValidator : Validator<AuthWithRefreshTokenEndpointRequest>
{
    public AuthWithRefreshTokenEndpointRequestValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();
    }
}

public class AuthWithRefreshTokenEndpoint : Endpoint<AuthWithRefreshTokenEndpointRequest, InitialData>
{
    private readonly IAuthenticationService _authenticationService;
    
    public AuthWithRefreshTokenEndpoint(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/auth/refresh-token");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AuthWithRefreshTokenEndpointRequest req, CancellationToken ct)
    {
        var response = await _authenticationService.AuthenticateWithRefreshToken(req.RefreshToken);
        await SendAsync(response, cancellation: ct);
    }
}