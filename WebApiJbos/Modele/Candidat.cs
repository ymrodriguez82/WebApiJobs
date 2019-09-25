using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApiJobs.Modele;

namespace WebApiJbos.Modele
{
    public class Candidat
    {
        public int Id_candidat { get; set; }
        public string Nom_candidat { get; set; }
        public string Prenom_candidat { get; set; }
        public string Courriel { get; set; }
        public string Mot_passe { get; set; }
        public string Tel { get; set; }
        public string Statut { get; set; }
        public List<Favoris> Favorites { get; set; }

        public Candidat()
        {
            Favorites = new List<Favoris>();
        }

    }
}
