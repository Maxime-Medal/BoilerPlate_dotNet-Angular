using BoilerPlate_dotNet.Data.Domain;
using System.Text.Json.Serialization;

namespace BoilerPlate_dotNet.Data.Dto
{
    public class PersonneDetails
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime DateNaissance { get; set; }

        public virtual List<EvaluationDto>? evaluations { get; set; }
    }
}
