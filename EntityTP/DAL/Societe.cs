
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityTP.DAL
{

    public class Societe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SocieteId { get; set; }
        public string Nom { get; set; }

        public long AdresseId {  get; set; }
        public Adresse SiegeSocial {  get; set; }

        public ICollection<Adresse> Adresses {  get; set; }
     
        public ICollection<Personne> Personnes {  get; set; }

    }
}
