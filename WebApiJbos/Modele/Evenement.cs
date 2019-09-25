using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiJbos.Modele;

namespace WebApiJobs.Modele
{
    public class Evenement
    {
        public int Id_evenement { get; set; }
        public int Id_candidat { get; set; }
        public string Id_offre { get; set; }
        public int Id_contact { get; set; }
        public string Titre { get; set; }
        public DateTime Date_event{ get; set; }
        public string Heure{ get; set; }
        public string Adresse { get; set; }
        public string Descr { get; set; }
        //proprite de navitation
        [JsonIgnore]
        public Candidat Candidat { get; set; }
        [JsonIgnore]
        public Offre Offre { get; set; }
        [JsonIgnore]
        public Contact Contact { get; set; }
        public List<Rappel> Rappels { get; set; }

        public Evenement()
        {
            Rappels = new List<Rappel>();
        }
    }
}
