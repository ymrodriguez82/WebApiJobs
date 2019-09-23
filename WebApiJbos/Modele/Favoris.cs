using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiJbos.Modele;

namespace WebApiJobs.Modele
{
    public class Favoris
    {
        public int Id_candidat { get; set; }
        public string Id_offre { get; set; }
        public DateTime Date_favoris { get; set; }
        public decimal Postule { get; set; }

    }
}
