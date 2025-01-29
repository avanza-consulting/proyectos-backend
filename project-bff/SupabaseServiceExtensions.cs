public static class SupabaseServiceExtensions
{
    public static IServiceCollection AddSupabase(this IServiceCollection services)
    {
        services.AddScoped(_ =>
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

        return services;
    }
}