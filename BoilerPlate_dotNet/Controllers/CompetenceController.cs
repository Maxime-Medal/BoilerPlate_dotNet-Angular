using BoilerPlate_dotNet.Data.Domain;
using BoilerPlate_dotNet.Data.Dto;
using BoilerPlate_dotNet.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate_dotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceController : ControllerBase
    {
        private ICompetenceRepository _competenceRepository;
        public CompetenceController(ICompetenceRepository competenceRepository)
        {
            _competenceRepository = competenceRepository;
        }

        [HttpGet("{nomPersonne}")]
        public async Task<IActionResult> GetCompetencesByNomPersonne(string nomPersonne)
        {
            List<CompetenceSimple> competences = await this._competenceRepository.GetCompetenceByNomPersonne(nomPersonne);
            return Ok(competences);
        }

        [HttpGet("GetAllCompetences")]
        public async Task<IActionResult> GetAllCompetences()
        {
            List<CompetenceSimple> competences = await this._competenceRepository.GetAllCompetence();

            return Ok(competences);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompetence([FromBody] CreateCompetence competence)
        {
            await this._competenceRepository.Add(competence);
            return Ok("Compétence créée");
        }
    }
}
