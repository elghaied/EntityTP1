
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityTP.DAL
{

    public class Adresse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AdresseId { get; set; }
     
        public int? Numero {  get; set; }
        public string Rue {  get; set; }

        public TypeVoie TypeVoie {  get; set; }

        public string LieuDit {  get; set; }
        public string CodePostal { get; set; }

        public string Ville { get; set; }
        public ICollection<Societe> Societes { get; set; }
        public ICollection<Societe> Etablissements { get; set; }


        public ICollection<Personne> Personnes {  get; set; }
        public ICollection<Personne> PersonnesSecondaire { get; set; }


    }

    public enum TypeVoie
    {
        Rue,
        Impasse,
        Route,
        Avenue
    }
}
