namespace ProjectBff.Endpoints
{
    public static class FeesEndpoints
    {
        public static void MapFeesEndpoints(this WebApplication app, string databaseProvider)
        {
            app.MapGet("/fees", async (IFeeRepository feeRepository) =>
            {
                var fees = await feeRepository.GetAllFeesAsync();
                return Results.Ok(fees);
            })
            .WithName("GetFees")
            .WithDisplayName("Get Fees")
            .Produces<List<IFees>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithDescription("Gets all fees.")
            .WithTags("Fees")
            .WithMetadata(new Dictionary<string, object>
            {
                { "x-api-version", ApiVersion.CurrentVersionSemver }
            });

            app.MapPost("/fees", async (IFeeRepository feeRepository, CreateFeeRequest request, IMapper mapper) =>
            {
                Fee fee = mapper.Map<Fee>(request);
                fee.AssignCreatedAt();
                IFees feeModel = databaseProvider switch
                {
                    nameof(DatabaseProviders.Supabase) => mapper.Map<SupabaseFees>(fee),
                    nameof(DatabaseProviders.SqlServer) => mapper.Map<SqlServerFees>(fee),
                    _ => throw new InvalidOperationException($"Unsupported database provider: {databaseProvider}")
                };
                var createdFee = await feeRepository.CreateFeeAsync(feeModel);
                return Results.Ok(createdFee);
            })
            .WithName("CreateFee")
            .WithDisplayName("Create Fee")
            .Produces<IFees>(StatusCodes.Status200OK)
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

            app.MapGet("/fees/{id}", async (IFeeRepository feeRepository, int id) =>
            {
                var fee = await feeRepository.GetFeeByIdAsync(id);
                if (fee is null)
                {
                    return Results.NotFound();
                }
                var foundFee = new CreateFeeResponse(fee.Id, fee.CreatedAt);
                return fee is not null ? Results.Ok(fee) : Results.NotFound();
            })
            .WithName("GetFeeById")
            .WithDisplayName("Get Fee By Id")
            .Produces<IFees>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithDescription("Gets a fee by id.")
            .WithTags("Fees")
            .WithMetadata(new Dictionary<string, object>
            {
                { "x-api-version", ApiVersion.CurrentVersionSemver }
            });

            app.MapDelete("/fees/{id}", async (IFeeRepository feeRepository, int id) =>
            {
                await feeRepository.DeleteFeeAsync(id);
                return Results.NoContent();
            })
            .WithName("DeleteFee")
            .WithDisplayName("Delete Fee")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithDescription("Deletes a fee by id.")
            .WithTags("Fees")
            .WithMetadata(new Dictionary<string, object>
            {
                { "x-api-version", ApiVersion.CurrentVersionSemver }
            });
        }
    }
}