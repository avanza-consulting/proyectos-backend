namespace ProjectBff.Repositories;
public class SupabaseFeeRepository : IFeeRepository
{
    private readonly Client _supabaseClient;

    public SupabaseFeeRepository(Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    public async Task<IEnumerable<Fees>> GetAllFeesAsync()
    {
        var response = await _supabaseClient.From<Fees>().Get();
        return response.Models;
    }

    public async Task<Fees?> GetFeeByIdAsync(int id)
    {
        var response = await _supabaseClient.From<Fees>().Where(i => i.Id == id).Get();
        return response?.Models?.FirstOrDefault();
    }

    public async Task<Fees> CreateFeeAsync(Fees fee)
    {
        var response = await _supabaseClient.From<Fees>().Insert(fee);
        return response.Models.First();
    }

    public async Task DeleteFeeAsync(int id)
    {
        await _supabaseClient.From<Fees>().Where(i => i.Id == id).Delete();
    }
}