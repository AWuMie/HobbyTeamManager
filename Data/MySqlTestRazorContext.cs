using Microsoft.EntityFrameworkCore;
using MySqlTestRazor.Models;

namespace MySqlTestRazor.Data;

public class MySqlTestRazorContext : DbContext
{
    public MySqlTestRazorContext(DbContextOptions<MySqlTestRazorContext> options)
        : base(options)
    {
    }

    public DbSet<Player>? Players { get; set; }
    public DbSet<Team>? Teams { get; set; }
}
