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

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        modelBuilder.ApplyConfiguration(new TeamPlayerConfiguration());
        modelBuilder.ApplyConfiguration(new MatchDayConfiguration());
    }

    public DbSet<Player>? Players { get; set; }
    public DbSet<Team>? Teams { get; set; }
    public DbSet<TeamPlayer>? TeamPlayers { get; set; }
}
