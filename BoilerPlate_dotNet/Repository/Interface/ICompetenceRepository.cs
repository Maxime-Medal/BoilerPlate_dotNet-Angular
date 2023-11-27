using BoilerPlate_dotNet.Data.Domain;
using BoilerPlate_dotNet.Data.Dto;

namespace BoilerPlate_dotNet.Repository.Interface
{
    public interface ICompetenceRepository
    {
        Task<List<CompetenceSimple>> GetAllCompetence();
        Task<List<CompetenceSimple>> GetCompetenceByNomPersonne(string nomPersonne);
        Task Add(CreateCompetence competence);
    }
}
