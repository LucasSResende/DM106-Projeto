﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesManager_Console
{
    public class Serie
    {
        public Serie(string serieName, string serieGenre, string serieDescription)
        {
            this.serieName = serieName;
            this.serieGenre = serieGenre;
            this.serieDescription = serieDescription;
        }

        public int Id { get; set; }
        public string serieName { get; set; }
        public string serieGenre { get; set; }
        public string serieDescription { get; set; }

        public List<Episode> episodes = new List<Episode>();

        public void AddEpisode(Episode episode)
        {
            episodes.Add(episode);
        }

        public void ShowEpisodes()
        {
            Console.WriteLine($"Nome dos Episódios {serieName}:");
            foreach (var episode in episodes)
            {
                Console.WriteLine(episode);
            }
        }

        public override string ToString()
        {
            return $@"Id: {Id}" +
                Environment.NewLine + $@"Nome da série: {serieName}" + 
                Environment.NewLine + $@"Gênero: {serieGenre}" + 
                Environment.NewLine + $@"Breve descrição: {serieDescription}";
        }
     
    }
}