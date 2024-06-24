﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesManager_Console
{
    internal class Serie
    {
        public Serie(string serieName, string genre, string description)
        {
            this.SerieName = serieName;
            this.Genre = genre;
            this.Description = description;
        }

        public string SerieName { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public List<Episode> episodes = new List<Episode>();

        public void AddEpisode(Episode episode)
        {
            episodes.Add(episode);
        }

        public void ShowEpisodes()
        {
            Console.WriteLine($"Nome dos Episódios {SerieName}:");
            foreach (var episode in episodes)
            {
                Console.WriteLine(episode);
            }
        }

        public override string ToString()
        {
            return $@"Nome da série: {SerieName}" + 
                Environment.NewLine + $@"Gênero: {Genre}" + 
                Environment.NewLine + $@"Breve descrição: {Description}";
        }
     
    }
}