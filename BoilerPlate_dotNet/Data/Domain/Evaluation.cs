using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BoilerPlate_dotNet.Data.Domain
{
    public class Evaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Competence")]
        public int CompetenceId { get; set; }

        [ForeignKey("CompetenceId")]
        [ValidateNever]
        public Competence? Competence { get; set; }

        [Required]
        [Display(Name = "Personne")]
        public int PersonneId { get; set; }

        [ForeignKey("PersonneId")]
        [ValidateNever]
        public Personne? Personne { get; set; }

        [Required]
        public int Note {  get; set; }
    }
}
