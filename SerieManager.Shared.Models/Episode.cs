using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesManager_Console
{
    public class Episode
    {
        public Episode(int episodeNumber, string episodeName)
        {
            EpisodeNumber = episodeNumber;
            EpisodeName = episodeName;
        }

        public int EpisodeNumber { get; set; }

        public string EpisodeName { get; set; }

        public override string ToString()
        {
            return $@"EP n°: {EpisodeNumber}" + Environment.NewLine +
                $@"Nome do episódio: {EpisodeName}";
        }

    }
}
