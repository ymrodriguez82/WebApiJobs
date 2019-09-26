using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJbos.Modele
{
    public class CandidatFavoris
    {
        public string Titre { get; set; }
        public string Companie { get; set; }
        public string Location { get; set; }
        public string Date_offre { get; set; }
        public string Descr { get; set; }
        public string Url { get; set; }
        public decimal Postule { get; set; }
        public string Date_favoris { get; set; }
    }
}
