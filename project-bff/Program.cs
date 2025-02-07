using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(ApiVersion.CurrentVersionName, new OpenApiInfo
    {
        Title = "Projects API",
        Version = ApiVersion.CurrentVersionName,
        Description = "API for creating and maintaining projects"
    });
});

// Register repository based on configuration
var databaseProvider = builder.Configuration.GetValue<string>("DatabaseProvider") ?? throw new InvalidOperationException("DatabaseProvider configuration is missing.");

builder.Services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile(databaseProvider)));
builder.Services.AddRepositories(databaseProvider, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/{ApiVersion.CurrentVersionName.ToLower()}/swagger.json", $"Projects API {ApiVersion.CurrentVersionSemver}");
    });
}
else
{
    app.MapGet("/", () => "Projects API Online");
}

app.MapFeesEndpoints(databaseProvider);
app.MapProjectsEndpoints(databaseProvider);

app.UseHttpsRedirection();
app.Run();