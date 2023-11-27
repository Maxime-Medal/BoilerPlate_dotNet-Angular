using BoilerPlate_dotNet.Data.Domain;

namespace BoilerPlate_dotNet.Data.Dto
{
    public class CompetenceSimple
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Type { get; set; }
        public int? Note {  get; set; }
    }
}
