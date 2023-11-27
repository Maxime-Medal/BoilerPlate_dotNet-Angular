using BoilerPlate_dotNet.Data.Dto;

namespace BoilerPlate_dotNet.Repository.Interface
{
    public interface IPersonneRepository
    {
        Task Add(CreatePersonne personne);

        Task<List<PersonneDetails>> GetAllDetails();

        Task<List<PersonneDetails>> GetPersonnesByCompetence(string nomEntreprise);

    }
}
