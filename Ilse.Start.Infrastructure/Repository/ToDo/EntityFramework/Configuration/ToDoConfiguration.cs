using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilse.Start.Infrastructure.Repository.ToDo.EntityFramework.Configuration;

public class ToDoConfiguration: IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .IsRequired(false);
        builder.Property(p => p.CompletedNotes)
            .HasMaxLength(2000)
            .IsRequired(false);
        builder.Property(p => p.CreatedBy)
            .HasMaxLength(100)
            .IsRequired(false);
        builder.Property(p => p.UpdatedBy)
            .HasMaxLength(100)
            .IsRequired(false);
        builder.Property(p => p.Tags)
            .HasConversion(
                t => JsonSerializer.Serialize(t, JsonSerializerOptions.Default),
                t => JsonSerializer.Deserialize<List<Tag>>(t, JsonSerializerOptions.Default) ?? new List<Tag>())
            .HasMaxLength(2000);
        builder.OwnsMany(p => p.Notes, n =>
        {
            n.WithOwner().HasForeignKey("TodoId");
            n.Property<int>("Id");
            n.HasKey("Id");
            n.Property(p => p.Text)
                .HasMaxLength(2000)
                .IsRequired();
        });
    }
}
