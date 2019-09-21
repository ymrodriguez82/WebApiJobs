using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJbos.Modele
{
    public class Candidat
    {
        public long  Id_Condidat { get; set; }
        public string Prenom_Condidat { get; set; }
        public string Nom_Condidat { get; set; }
        public string Courriel { get; set; }
        public string Mot_Passe { get; set; }
        public string  Tel { get; set; }
        public string Statut { get; set; }

    }
}
