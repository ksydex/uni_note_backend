using FastEndpoints;

namespace UniNote.Api.Endpoints;

public class HealthCheckEndpointRequest {}

public record HealthCheckEndpointResponse
{
    public string Status { get; set; } = "";
}

public class HealthCheckEndpoint : Endpoint<HealthCheckEndpointRequest, HealthCheckEndpointResponse>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/health-check");
        AllowAnonymous();
    }

    public override async Task HandleAsync(HealthCheckEndpointRequest req, CancellationToken ct)
    {
        var response = new HealthCheckEndpointResponse { Status = "active" };
        await SendAsync(response, cancellation: ct);
    }
}