using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SerieManager.Shared.Data.Models;
using SeriesManager_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SerieManager.Shared.Data.BD
{
    public class SerieManagerContext : IdentityDbContext<AccessUser, AccessRole, int>
    {

        public DbSet<Serie> Serie{ get; set; }
        public DbSet<Episode> Episode{ get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<Country> Country { get; set; }


        private string connectionString = "Server=tcp:seriesmanagerserver.database.windows.net,1433;" +
            "Initial Catalog=SerieManager_BD_V0;Persist Security Info=False;User ID=serieserver;" +
            "Password=Senh@100;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Serie>().HasMany(p => p.Platforms).WithMany(s => s.Series);
            modelBuilder.Entity<Serie>().HasMany(c => c.Countries).WithMany(s => s.Series);
        }
    }
}