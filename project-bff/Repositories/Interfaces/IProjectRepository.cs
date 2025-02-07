namespace ProjectBff.Repositories
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<IProjects>> GetAllFeesAsync();
        public Task<IProjects?> GetFeeByIdAsync(int id);
        public Task<IProjects> CreateFeeAsync(IProjects fee);
        public Task DeleteFeeAsync(int id);
    }
}