using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesManager_Console
{
    public class Country
    {

        public Country(string countryName, string language)
        {
            this.countryName = countryName;
            this.language = language;
        }

        public Country()
        {
        }

        public int Id { get; set; }
        public string countryName { get; set; }
        public string language { get; set; }
        public virtual ICollection<Serie> Series { get; set; }

        public override string ToString()
        {
            return $@"Países disponíveis: {countryName}" + Environment.NewLine
                + $@"Linguagens disponíveis: {language}";
        }
    }
}
