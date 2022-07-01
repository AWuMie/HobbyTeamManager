using Microsoft.EntityFrameworkCore;
using HobbyTeamManager.EntityConfigurations;
using HobbyTeamManager.Models;

namespace HobbyTeamManager.Data;

public class HobbyTeamManagerContext : DbContext
{
    public HobbyTeamManagerContext(DbContextOptions<HobbyTeamManagerContext> options)
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
        modelBuilder.ApplyConfiguration(new SiteConfiguration());
        modelBuilder.ApplyConfiguration(new SitePlayerConfiguration());
    }

    public DbSet<MembershipType>? MembershipTypes { get; set; }
    public DbSet<TeamColor>? TeamColors { get; set; }
    public DbSet<Player>? Players { get; set; }
    public DbSet<Team>? Teams { get; set; }
    public DbSet<TeamPlayer>? TeamPlayers { get; set; }
    public DbSet<MatchDay>? MatchDays { get; set; }
    public DbSet<Season>? Seasons { get; set; }
    public DbSet<Site>? Sites { get; set; }
    public DbSet<SitePlayer>? SitePlayers { get; set; }
}
