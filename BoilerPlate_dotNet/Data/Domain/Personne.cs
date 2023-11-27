using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate_dotNet.Data.Domain
{
    public class Personne
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }

        public DateTime DateNaissance { get; set; }
        [JsonIgnore]
        public virtual List<Evaluation> Evaluations { get; set; }

    }
}
