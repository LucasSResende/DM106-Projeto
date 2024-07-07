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
            this.EpisodeNumber = episodeNumber;
            this.EpisodeName = episodeName;
        }
        public int Id { get; set; }

        public int EpisodeNumber { get; set; }

        public string EpisodeName { get; set; }
        public virtual Serie? Serie { get; set; }


        public override string ToString()
        {
            return $@"Ep n°: {EpisodeNumber}" + Environment.NewLine +
                $@"Nome do episódio: {EpisodeName}";
        }

    }
}
