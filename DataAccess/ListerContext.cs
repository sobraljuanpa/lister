using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;
public class ListerContext : DbContext
{
    public ListerContext(DbContextOptions<ListerContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
}
