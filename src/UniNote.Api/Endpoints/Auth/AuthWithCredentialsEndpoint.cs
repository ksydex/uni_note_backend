using FastEndpoints;
using FluentValidation;
using UniNote.Application.Modules.AuthenticationService;
using UniNote.Application.Modules.AuthenticationService.Models;

namespace UniNote.Api.Endpoints.Auth;

// Tested
public record AuthWithCredentialsEndpointRequest
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}

public class AuthWithCredentialsEndpointRequestValidator : Validator<AuthWithCredentialsEndpointRequest>
{
    public AuthWithCredentialsEndpointRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}

public class AuthWithCredentialsEndpoint : Endpoint<AuthWithCredentialsEndpointRequest, InitialData>
{
    private readonly IAuthenticationService _authenticationService;

    public AuthWithCredentialsEndpoint(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/auth/credentials");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AuthWithCredentialsEndpointRequest req, CancellationToken ct)
    {
        var response = await _authenticationService.AuthenticateWithCredentials(req.Email, req.Password);
        await SendAsync(response, cancellation: ct);
    }
}