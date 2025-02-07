using Microsoft.EntityFrameworkCore;

namespace ProjectBff.Repositories.SqlServer;

public class ProjectsDbContext : DbContext
{
    public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options)
    {
    }

    public DbSet<SqlServerProjects> Projects { get; set; }
    public DbSet<SqlServerFees> Fees { get; set; }
}