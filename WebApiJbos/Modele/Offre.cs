using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJobs.Modele
{
    public class Offre
    {
        public string Id_offre { get; set; }
        public string Titre { get; set; }
        public string Companie { get; set; }
        public string Location { get; set; }
        public DateTime Date_offre { get; set; }
        public string Descr { get; set; }
        public string Url { get; set; }
        public List<Favoris> Favorites { get; set; }

    }
}
