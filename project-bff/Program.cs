using AutoMapper;
using Microsoft.OpenApi.Models;
using Supabase;
using ProjectBff.Contracts;
using ProjectBff.Domain;
using ProjectBff.Models;
using ProjectBff.Utils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped(_ =>
{
    DotNetEnv.Env.Load();
    var supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
    var supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");
    if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey))
    {
        throw new InvalidOperationException("Supabase URL or Key is not set in the environment variables.");
    }
    var supabaseOptions = new SupabaseOptions
    {
        AutoRefreshToken = true,
        AutoConnectRealtime = true,
    };
    return new Client(supabaseUrl, supabaseKey, supabaseOptions);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.MapGet("/", () => "Hello World!");

app.MapPost("/fees", async (Client supabaseClient, CreateFeeRequest request, IMapper mapper) =>
{
    var fee = mapper.Map<Fee>(request);
    fee.AssignCreatedAt();
    var feeModel = mapper.Map<Fees>(fee);
    var response = await supabaseClient.From<Fees>().Insert(feeModel);
    var createdFee = response.Models.First();
    return Results.Ok(createdFee);
});

app.MapGet("/fees", async (Client supabaseClient) =>
{
    var response = await supabaseClient.From<Fees>().Get();
    return Results.Ok(response.Models);
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
});

app.MapDelete("/fees/{id}", async (Client supabaseClient, int id) =>
{
    await supabaseClient.From<Fees>().Where(i => i.Id == id).Delete();
    return Results.NoContent();
});

app.MapPost("/projects", async (Client supabaseClient, CreateProjectRequest request, IMapper mapper) =>
{
    var project = mapper.Map<Projects>(request);
    var response = await supabaseClient.From<Projects>().Insert(project);
    var createdProject = response.Models.First();
    return Results.Ok(createdProject);
});

app.MapGet("/projects/{id}", async (Client supabaseClient, int id) =>
{
    var response = await supabaseClient.From<Projects>().Where(i => i.Id == id).Get();
    var project = response.Models.FirstOrDefault();
    if (project is null)
    {
        return Results.NotFound();
    }
    var foundProject = new CreateProjectResponse(project.Id, project.Name ?? string.Empty, project.ClientName ?? string.Empty, project.CurrencyId, project.CreatedAt);
    return project is not null ? Results.Ok(project) : Results.NotFound();
});

app.MapDelete("/projects/{id}", async (Client supabaseClient, int id) =>
{
    await supabaseClient.From<Projects>().Where(i => i.Id == id).Delete();
    return Results.NoContent();
});

app.UseHttpsRedirection();

app.Run();