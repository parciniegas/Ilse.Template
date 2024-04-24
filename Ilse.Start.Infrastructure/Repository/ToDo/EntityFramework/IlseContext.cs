using Ilse.Repository.Abstracts;
using Ilse.Repository.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Ilse.Start.Infrastructure.Repository.ToDo.EntityFramework;

public class IlseContext(
    DbContextOptions<IlseContext> dbContextOptions,
    IServiceProvider serviceProvider,
    IOptions<RepositoryOptions> repositoryOptions) : BaseContext(dbContextOptions, serviceProvider, repositoryOptions)
{
    
}