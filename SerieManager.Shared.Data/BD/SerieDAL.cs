using HeroWiki.Shared.Data.DB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SeriesManager_Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SerieManager.Shared.Data.BD
{
    public class SerieDAL
    {
        private readonly SerieManagerContext context;

        public SerieDAL(SerieManagerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Serie> Read()
        {
            return context.Serie.ToList();
        }

        public void Create(Serie serie)
        {
            context.Serie.Add(serie);
            context.SaveChanges();
        }

        public void Update(Serie serie)
        {
            context.Serie.Update(serie);
            context.SaveChanges();
        }

        public void Delete(Serie serie)
        {
            context.Remove(serie);
            context.SaveChanges();
        }

        public Serie ReadByName(string serieName)
        {
            return context.Serie.FirstOrDefault(x => x.serieName == serieName);
        }
    }
}
