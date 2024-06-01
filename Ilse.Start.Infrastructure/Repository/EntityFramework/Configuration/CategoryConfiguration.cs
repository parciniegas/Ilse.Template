using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilse.Start.Infrastructure.Repository.EntityFramework.Configuration;

public class CategoryConfiguration: IEntityTypeConfiguration<Todo.Category>
{
    public void Configure(EntityTypeBuilder<Todo.Category> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(p => p.Description)
            .HasMaxLength(2000)
            .IsRequired(false);
    }
}
