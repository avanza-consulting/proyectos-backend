namespace ProjectBff.Repositories;
public interface IFeeRepository
{
    public Task<IEnumerable<IFees>> GetAllFeesAsync();
    public Task<IFees?> GetFeeByIdAsync(int id);
    public Task<IFees> CreateFeeAsync(IFees fee);
    public Task DeleteFeeAsync(int id);
}