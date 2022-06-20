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
        Description(b => b
            .Produces<ErrorResponse>(400,"application/json+problem")
            .ProducesProblem(403));
        Summary(s => {
            s.Summary = "short summary goes here";
            s.Description = "long description goes here";
            s.Responses[200] = "success response description goes here";
            s.Responses[403] = "forbidden response description goes here";
        });   
    }

    public override async Task HandleAsync(HealthCheckEndpointRequest req, CancellationToken ct)
    {
        var response = new HealthCheckEndpointResponse { Status = "active" };
        await SendAsync(response, cancellation: ct);
    }
}