using Gramophone.Models;
using Microsoft.EntityFrameworkCore;

namespace Gramophone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Listener> Listeners { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
    }
}
