using Microsoft.EntityFrameworkCore;
using ProjectBff.Models;

namespace ProjectBff.Repositories
{
    public class SqlServerFeeRepository : IFeeRepository
    {
        private readonly DbContext _dbContext;

        public SqlServerFeeRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Fees>> GetAllFeesAsync()
        {
            return await _dbContext.Set<Fees>().ToListAsync();
        }

        public async Task<Fees?> GetFeeByIdAsync(int id)
        {
            return await _dbContext.Set<Fees>().FindAsync(id);
        }

        public async Task<Fees> CreateFeeAsync(Fees fee)
        {
            _dbContext.Set<Fees>().Add(fee);
            await _dbContext.SaveChangesAsync();
            return fee;
        }

        public async Task DeleteFeeAsync(int id)
        {
            var fee = await _dbContext.Set<Fees>().FindAsync(id);
            if (fee != null)
            {
                _dbContext.Set<Fees>().Remove(fee);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}