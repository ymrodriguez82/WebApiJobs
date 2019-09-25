using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJobs.Modele
{
    public class Rappel
    {
        public int Id_rappel { get; set; }
        public int Id_evenement { get; set; }
        public DateTime Date_rappel { get; set; }
        public string Heure_rappel { get; set; }
        public decimal Tel_rappel { get; set; }
        public decimal Courriel_rappel { get; set; }
        public string Statut_rappel { get; set; }
        //proprite de navitation
        [JsonIgnore]
        public Evenement Evenement { get; set; }
    }
}
