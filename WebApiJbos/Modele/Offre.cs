using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJobs.Modele
{
    public class Offre
    {
        public long Id { get;  }
        public string Titre { get; set; }
        public string Compagnie { get; set; }
        public string Adresse { get; set; }
        public string Description { get; set; }

    }
}
