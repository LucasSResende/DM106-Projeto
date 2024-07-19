using SeriesManager_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesManager_Console
{
    public class Platform
    {
        public Platform()
        {
        }

        public Platform(string platformName)
        {
            this.platformName = platformName;
        }

        public int Id { get; set; }
        public string platformName { get; set; }

        public virtual ICollection<Serie> Series { get; set; }

        //public void AddSeries(Serie serie)
        //{
        //    Series.Add(serie);
        //}

        //public void ShowSeries()

        //{
        //    Console.WriteLine($"Nome das Séries da plataforma {platformName}:");
        //    foreach (var serie in Series)
        //    {
        //        Console.WriteLine(serie);
        //    }
        //}

        public override string ToString()
        {
            return $@"Id: {Id}" + Environment.NewLine
                + $@"Nome da plataforma: {platformName}";
        }
    }
}
