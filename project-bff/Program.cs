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
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSupabase();

// Register repository based on configuration
var databaseProvider = builder.Configuration.GetValue<string>("DatabaseProvider");
var feeRepositoryType = databaseProvider switch
{
    nameof(DatabaseProviders.Supabase) => typeof(SupabaseFeeRepository),
    nameof(DatabaseProviders.SqlServer) => typeof(SqlServerFeeRepository),
    // nameof(DatabaseProviders.MySql) => typeof(MySqlFeeRepository),
    // nameof(DatabaseProviders.PostgreSql) => typeof(PostgreSqlFeeRepository),
    _ => throw new InvalidOperationException($"Unsupported database provider: {databaseProvider}")
};

builder.Services.AddScoped(typeof(IFeeRepository), feeRepositoryType);

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