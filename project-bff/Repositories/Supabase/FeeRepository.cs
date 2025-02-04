namespace ProjectBff.Repositories;
public class SupabaseFeeRepository : IFeeRepository
{
    private readonly Client _supabaseClient;

    public SupabaseFeeRepository(Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    public async Task<IEnumerable<IFees>> GetAllFeesAsync()
    {
        var response = await _supabaseClient.From<SupabaseFees>().Get();
        return response.Models;
    }

    public async Task<IFees?> GetFeeByIdAsync(int id)
    {
        var response = await _supabaseClient.From<SupabaseFees>().Where(i => i.Id == id).Get();
        return response?.Models?.FirstOrDefault();
    }

    public async Task<IFees> CreateFeeAsync(IFees fee)
    {
        var response = await _supabaseClient.From<SupabaseFees>().Insert((SupabaseFees)fee);
        return response.Models.First();
    }

    public async Task DeleteFeeAsync(int id)
    {
        await _supabaseClient.From<SupabaseFees>().Where(i => i.Id == id).Delete();
    }
}