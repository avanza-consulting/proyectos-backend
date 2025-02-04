using Microsoft.EntityFrameworkCore;
using ProjectBff.Repositories.SqlServer;

namespace ProjectBff.Repositories
{
    public class SqlServerFeeRepository : IFeeRepository
    {
        private readonly DbContext _dbContext;

        public SqlServerFeeRepository(ProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<IFees>> GetAllFeesAsync()
        {
            return await _dbContext.Set<SqlServerFees>().ToListAsync();
        }

        public async Task<IFees?> GetFeeByIdAsync(int id)
        {
            return await _dbContext.Set<SqlServerFees>().FindAsync(id);
        }

        public async Task<IFees> CreateFeeAsync(IFees fee)
        {
            _dbContext.Set<SqlServerFees>().Add((SqlServerFees)fee);
            await _dbContext.SaveChangesAsync();
            return fee;
        }

        public async Task DeleteFeeAsync(int id)
        {
            var fee = await _dbContext.Set<SqlServerFees>().FindAsync(id);
            if (fee != null)
            {
                _dbContext.Set<SqlServerFees>().Remove(fee);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}