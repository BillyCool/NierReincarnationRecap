using Microsoft.EntityFrameworkCore;
using NierReincarnationRecap.Business.EF.Model;

namespace NierReincarnationRecap.Business.EF;

public class NierReincarnationRecapDbContext : DbContext
{
    public DbSet<UserData> UserData { get; set; }

    public DbSet<UserSubmission> UserSubmissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DbConnectionString"));
        optionsBuilder.UseCamelCaseNamingConvention();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserData>(x =>
        {
            x.OwnsMany(y => y.ArenaRankings, z => z.ToJson());
            x.OwnsMany(y => y.SubjugationRankings, z => z.ToJson());
            x.OwnsMany(y => y.ExplorationRankings, z => z.ToJson());
        });

        modelBuilder.Entity<UserSubmission>(x => x.OwnsMany(y => y.Votes, z => z.ToJson()));

        base.OnModelCreating(modelBuilder);
    }
}
