using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJobs.Modele
{
    public class Contact
    {
  
        public int Id_contact { get; set; }
        public string Nom_contact { get; set; }
        public string Prenom_contact { get; set; }
        public string Courriel_contact { get; set; }
        public string Poste{ get; set; }
        public string Tel_contact{ get; set; }
        public List<Evenement> ListeEvenements { get; set; }

        public Contact()
        {
            ListeEvenements = new List<Evenement>();
        }

    }
}
