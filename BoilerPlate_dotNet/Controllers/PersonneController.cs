using BoilerPlate_dotNet.Data.Dto;
using BoilerPlate_dotNet.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate_dotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private IPersonneRepository personneRepository;

        public PersonneController(IPersonneRepository personneRepository)
        {
            this.personneRepository = personneRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonne([FromBody] CreatePersonne personne)
        {
            await this.personneRepository.Add(personne);
            return Ok("Personne créer");
        }

        [HttpGet("GetAllPersonnes")]
        public async Task<IActionResult> GetAllPersonnes()
        {
            List<PersonneDetails> personnes = await this.personneRepository.GetAllDetails();

            return Ok(personnes);
        }

        [HttpGet("{competence}")]
        public async Task<IActionResult> GetPersonnesByCompetence(string competence)
        {
            List<PersonneDetails> personnes = await this.personneRepository.GetPersonnesByCompetence(competence);
            return Ok(personnes);
        }

    }
}
