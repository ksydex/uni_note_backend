using FastEndpoints;
using FluentValidation;
using UniNote.Application.Modules.AuthenticationService;
using UniNote.Application.Modules.AuthenticationService.Models;

namespace UniNote.Api.Endpoints.Auth;

public record AuthSignUpEndpointRequest
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string Name { get; set; } = "";
}

public class AuthSignUpEndpointRequestValidator : Validator<AuthSignUpEndpointRequest>
{
    public AuthSignUpEndpointRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}

public class AuthSignUpEndpoint : Endpoint<AuthSignUpEndpointRequest>
{
    private readonly IAuthenticationService _authenticationService;

    public AuthSignUpEndpoint(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/auth/sign-up");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AuthSignUpEndpointRequest req, CancellationToken ct)
    {
        await _authenticationService.SignUpAsync(req.Email, req.Password, req.Name);
        await SendAsync(new {}, cancellation: ct);
    }
}