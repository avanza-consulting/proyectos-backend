namespace ProjectBff.Endpoints;

public static class FeesEndpoints
{
    public static void MapFeesEndpoints(this WebApplication app)
    {
        app.MapGet("/fees", async (Client supabaseClient) =>
        {
            var response = await supabaseClient.From<Fees>().Get();
            return Results.Ok(response.Models);
        })
        .WithName("GetFees")
        .WithDisplayName("Get Fees")
        .Produces<List<Fees>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithDescription("Gets all fees.")
        .WithTags("Fees")
        .WithMetadata(new Dictionary<string, object>
        {
            { "x-api-version", ApiVersion.CurrentVersionSemver }
        });

        app.MapPost("/fees", async (Client supabaseClient, CreateFeeRequest request, IMapper mapper) =>
        {
            var fee = mapper.Map<Fee>(request);
            fee.AssignCreatedAt();
            var feeModel = mapper.Map<Fees>(fee);
            var response = await supabaseClient.From<Fees>().Insert(feeModel);
            var createdFee = response.Models.First();
            return Results.Ok(createdFee);
        })
        .WithName("CreateFee")
        .WithDisplayName("Create Fee")
        .Produces<Fees>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status500InternalServerError)
        .ProducesValidationProblem()
        .Accepts<CreateFeeRequest>("application/json")
        .WithDescription("Creates a new fee.")
        .WithTags("Fees")
        .WithMetadata(new Dictionary<string, object>
        {
            { "x-api-version", ApiVersion.CurrentVersionSemver }
        });

        app.MapGet("/fees/{id}", async (Client supabaseClient, int id) =>
        {
            var response = await supabaseClient.From<Fees>().Where(i => i.Id == id).Get();
            var fee = response.Models.FirstOrDefault();
            if (fee is null)
            {
                return Results.NotFound();
            }
            var foundFee = new CreateFeeResponse(fee.Id, fee.CreatedAt);
            return fee is not null ? Results.Ok(fee) : Results.NotFound();
        })
        .WithName("GetFee")
        .WithDisplayName("Get Fee")
        .Produces<Fees>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError)
        .Accepts<int>("application/json")
        .WithDescription("Gets a fee by ID.")
        .WithTags("Fees")
        .WithMetadata(new Dictionary<string, object>
        {
            { "x-api-version", ApiVersion.CurrentVersionSemver }
        });

        app.MapPatch("/fees/{id}", async (Client supabaseClient, int id, UpdateFeeRequest request, IMapper mapper) =>
        {
            var fee = mapper.Map<Fee>(request);
            fee.AssignUpdatedAt();
            var feeModel = mapper.Map<Fees>(fee);
            var response = await supabaseClient.From<Fees>().Update(feeModel);
            var createdFee = response.Models.First();
            return Results.Ok(createdFee);
        })
        .WithName("UpdateFee")
        .WithDisplayName("Update Fee")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .Accepts<int>("application/json")
        .WithDescription("Updates a fee by ID.")
        .WithTags("Fees")
        .WithMetadata(new Dictionary<string, object>
        {
            { "x-api-version", ApiVersion.CurrentVersionSemver }
        });

        app.MapDelete("/fees/{id}", async (Client supabaseClient, int id) =>
        {
            await supabaseClient.From<Fees>().Where(i => i.Id == id).Delete();
            return Results.NoContent();
        })
        .WithName("DeleteFee")
        .WithDisplayName("Delete Fee")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status500InternalServerError)
        .Accepts<int>("application/json")
        .WithDescription("Deletes a fee by ID.")
        .WithTags("Fees")
        .WithMetadata(new Dictionary<string, object>
        {
            { "x-api-version", ApiVersion.CurrentVersionSemver }
        });
    }
}