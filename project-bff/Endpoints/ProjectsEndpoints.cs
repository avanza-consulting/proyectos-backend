namespace ProjectBff.Endpoints;

public static class ProjectsEndpoints
{
    public static void MapProjectsEndpoints(this WebApplication app, string databaseProvider)
    {
        app.MapGet("/projects", async (IProjectRepository feeRepository) =>
        {
            var projects = await feeRepository.GetAllProjectsAsync();
            return Results.Ok(projects);
        })
        .WithName("GetProjects")
        .WithDisplayName("Get Projects")
        .Produces<List<IProjects>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithDescription("Gets all projects.")
        .WithTags("Projects")
        .WithMetadata(new Dictionary<string, object>
        {
            { "x-api-version", ApiVersion.CurrentVersionSemver }
        });

        // app.MapPost("/projects", async (Client supabaseClient, CreateProjectRequest request, IMapper mapper) =>
        // {
        //     var project = mapper.Map<SupabaseProjects>(request);
        //     var response = await supabaseClient.From<SupabaseProjects>().Insert(project);
        //     var createdProject = response.Models.First();
        //     return Results.Ok(createdProject);
        // });

        // app.MapGet("/projects/{id}", async (Client supabaseClient, int id) =>
        // {
        //     var response = await supabaseClient.From<SupabaseProjects>().Where(i => i.Id == id).Get();
        //     var project = response.Models.FirstOrDefault();
        //     if (project is null)
        //     {
        //         return Results.NotFound();
        //     }
        //     var foundProject = new CreateProjectResponse(project.Id, project.Name ?? string.Empty, project.ClientName ?? string.Empty, project.CurrencyId, project.CreatedAt);
        //     return project is not null ? Results.Ok(project) : Results.NotFound();
        // });

        // app.MapDelete("/projects/{id}", async (Client supabaseClient, int id) =>
        // {
        //     await supabaseClient.From<SupabaseProjects>().Where(i => i.Id == id).Delete();
        //     return Results.NoContent();
        // });
    }
}