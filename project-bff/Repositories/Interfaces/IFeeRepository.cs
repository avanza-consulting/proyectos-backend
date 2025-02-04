namespace ProjectBff.Repositories;
public interface IFeeRepository
{
    public Task<IEnumerable<Fees>> GetAllFeesAsync();
    public Task<Fees?> GetFeeByIdAsync(int id);
    public Task<Fees> CreateFeeAsync(Fees fee);
    public Task DeleteFeeAsync(int id);
}