using InterviewApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewApp.Core.DAL;

internal sealed class InterviewAppDbContext : DbContext
{
    public DbSet<MovieEntity> Movies { get; set; } = null!;

    public InterviewAppDbContext(DbContextOptions<InterviewAppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}