using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.EntityConfigurations;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Data;

public class MySqlTestRazorContext : DbContext
{
    public MySqlTestRazorContext(DbContextOptions<MySqlTestRazorContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new MembershipTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TeamColorConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        modelBuilder.ApplyConfiguration(new TeamPlayerConfiguration());
        modelBuilder.ApplyConfiguration(new MatchDayConfiguration());
        modelBuilder.ApplyConfiguration(new SeasonConfiguration());
        //modelBuilder.ApplyConfiguration(new SiteConfiguration());
    }

    public DbSet<MembershipType>? MembershipTypes { get; set; }
    public DbSet<TeamColor>? TeamColors { get; set; }
    public DbSet<Player>? Players { get; set; }
    public DbSet<Team>? Teams { get; set; }
    public DbSet<TeamPlayer>? TeamPlayers { get; set; }
    public DbSet<MatchDay>? MatchDays { get; set; }
    public DbSet<Season>? Seasons { get; set; }
    //public DbSet<Site>? Sites { get; set; }
}
