using Microsoft.OpenApi.Models;
using ProjectBff.Utils;
using ProjectBff.Endpoints;

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
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSupabase();

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

app.MapFeesEndpoints();

app.UseHttpsRedirection();
app.Run();