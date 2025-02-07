namespace ProjectBff.Repositories
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<IProjects>> GetAllProjectsAsync();
        public Task<IProjects?> GetProjectByIdAsync(int id);
        public Task<IProjects> CreateProjectAsync(IProjects project);
        public Task UpdateProjectAsync(IProjects project);
        public Task DeleteProjectAsync(int id);
    }
}