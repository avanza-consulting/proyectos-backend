public static class ApiVersion
{
    public static readonly Dictionary<string, string> V1 = new Dictionary<string, string> { { "v1", "1.0.0" } };
    public static readonly string CurrentVersionName = V1.Keys.First();
    public static readonly string CurrentVersionSemver = V1.Values.First();
}