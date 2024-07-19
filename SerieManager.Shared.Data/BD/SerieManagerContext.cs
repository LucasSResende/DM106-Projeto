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


        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=SerieManager_BD_V0;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
            "Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Serie>().HasMany(p => p.Platforms).WithMany(s => s.Series);
        }
    }
}