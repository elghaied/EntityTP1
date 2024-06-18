using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTP.DAL { 
 
    public class Personne
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public long PersonneId { get; set; }


        public string Nom {  get; set; }
        public string Prenom { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateNaissance { get; set; }


        public long? AdressePrincipaleId { get; set; }
    
        public long? AdresseSecondaireId { get; set; }

        public long SocieteId { get; set; }
        public Societe Societe { get; set; }

        public Adresse AdressePrincipale { get; set; }
        public Adresse AdresseSecondaire { get; set; }

    }
}
