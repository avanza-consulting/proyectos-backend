using Microsoft.EntityFrameworkCore;
using ProjectBff.Repositories.SqlServer;

namespace ProjectBff.Repositories
{
    public class SqlServerProjectRepository : IProjectRepository
    {
        private readonly DbContext _dbContext;

        public SqlServerProjectRepository(ProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<IProjects>> GetAllProjectsAsync()
        {
            return await _dbContext.Set<SqlServerProjects>().ToListAsync();
        }

        public async Task<IProjects?> GetProjectByIdAsync(int id)
        {
            return await _dbContext.Set<SqlServerProjects>().FindAsync(id);
        }

        public async Task<IProjects> CreateProjectAsync(IProjects project)
        {
            _dbContext.Set<SqlServerProjects>().Add((SqlServerProjects)project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task UpdateProjectAsync(IProjects project)
        {
            _dbContext.Set<SqlServerProjects>().Update((SqlServerProjects)project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _dbContext.Set<SqlServerProjects>().FindAsync(id);
            if (project != null)
            {
                _dbContext.Set<SqlServerProjects>().Remove(project);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}