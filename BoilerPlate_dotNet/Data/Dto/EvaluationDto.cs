using BoilerPlate_dotNet.Data.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate_dotNet.Data.Dto
{
    public class EvaluationDto
    {
        public int Id { get; set; }

        public Competence? Competence { get; set; }

        public int Note { get; set; }
    }
}
