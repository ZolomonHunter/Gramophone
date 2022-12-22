using Gramophone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gramophone.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserApp>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Listener> Listeners { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<UserApp> UserApps { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Composition> Compositions { get; set; }
    }
}
