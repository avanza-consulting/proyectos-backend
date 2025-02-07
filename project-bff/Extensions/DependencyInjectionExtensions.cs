public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, string databaseProvider, ConfigurationManager configuration)
    {
        var feeRepositoryType = databaseProvider switch
        {
            nameof(DatabaseProviders.Supabase) => typeof(SupabaseFeeRepository),
            nameof(DatabaseProviders.SqlServer) => typeof(SqlServerFeeRepository),
            _ => throw new InvalidOperationException($"Unsupported database provider: {databaseProvider}")
        };
        var projectRepositoryType = databaseProvider switch
        {
            // nameof(DatabaseProviders.Supabase) => typeof(SupabaseProjectRepository),
            nameof(DatabaseProviders.SqlServer) => typeof(SqlServerProjectRepository),
            _ => throw new InvalidOperationException($"Unsupported database provider: {databaseProvider}")
        };

        Action databaseProviderService = databaseProvider switch
        {
            nameof(DatabaseProviders.SqlServer) => () => services.AddSqlServer(configuration),
            nameof(DatabaseProviders.Supabase) => () => services.AddSupabase(),
            _ => throw new InvalidOperationException($"Unsupported database provider: {databaseProvider}")
        };
        databaseProviderService();

        services.AddScoped(typeof(IFeeRepository), feeRepositoryType);
        services.AddScoped(typeof(IProjectRepository), projectRepositoryType);

        return services;
    }
}