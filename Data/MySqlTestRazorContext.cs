using Microsoft.EntityFrameworkCore;
using MysqlTestConsole.Models;

namespace MySqlTestRazor.Data;

public class MySqlTestRazorContext : DbContext
{
    public MySqlTestRazorContext(DbContextOptions<MySqlTestRazorContext> options)
        : base(options)
    {
    }

    // public DbSet<Guest> Guests { get; set; }
    public DbSet<Player>? Players { get; set; }
}
