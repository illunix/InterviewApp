using InterviewApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewApp.Core.DAL.Configurations;

internal sealed class MovieEntityConfiguration : IEntityTypeConfiguration<MovieEntity>
{
    public void Configure(EntityTypeBuilder<MovieEntity> builder)
    {
        builder.Property(q => q.Id).ValueGeneratedNever();
        builder.Property(q => q.Name).IsRequired();
        builder.Property(q => q.Description).IsRequired();
    }
}