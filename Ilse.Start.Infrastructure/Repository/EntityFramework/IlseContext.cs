using Ilse.Repository.Abstracts;
using Ilse.Repository.Options;
using Ilse.Start.Infrastructure.Repository.Todo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Ilse.Start.Infrastructure.Repository.EntityFramework;

public class IlseContext(
    DbContextOptions<IlseContext> dbContextOptions,
    IServiceProvider serviceProvider,
    IOptions<RepositoryOptions> repositoryOptions) : BaseContext(dbContextOptions, serviceProvider, repositoryOptions)
{
    public required DbSet<Category> Categories { get; set; }
    public required DbSet<Todo.Todo> Todos { get; set; }
    public required DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IlseContext).Assembly);
    }
}
