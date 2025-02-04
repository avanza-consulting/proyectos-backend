using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ProjectBff.Repositories.SqlServer;

public static class SqlServerServiceExtensions
{
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        Env.Load();
        var sqlServerUser = Environment.GetEnvironmentVariable("SQLSERVER_USER");
        var sqlServerPassword = Environment.GetEnvironmentVariable("SQLSERVER_PASSWORD");
        var sqlServerHost = Environment.GetEnvironmentVariable("SQLSERVER_HOST");
        var sqlServerPort = Environment.GetEnvironmentVariable("SQLSERVER_PORT");
        var sqlServerDatabase = Environment.GetEnvironmentVariable("SQLSERVER_DATABASE");
        var connectionString = $"Server={sqlServerHost},{sqlServerPort};Database={sqlServerDatabase};User Id={sqlServerUser};Password={sqlServerPassword};TrustServerCertificate=True;";

        services.AddDbContext<ProjectsDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}