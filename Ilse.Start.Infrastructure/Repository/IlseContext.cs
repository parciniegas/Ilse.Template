using Ilse.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Ilse.Start.Infrastructure.Repository;

public class IlseContext(
    DbContextOptions<IlseContext> dbContextOptions,
    IServiceProvider serviceProvider,
    IOptions<RepositoryOptions> repositoryOptions) : BaseContext(dbContextOptions, serviceProvider, repositoryOptions)
{
    
}