using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SeriesManager_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace HeroWiki.Shared.Data.DB
{
    public class SerieManagerContext : DbContext
    {

        public DbSet<Serie> Serie{ get; set; }
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=SerieManager_BD;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
            "Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}