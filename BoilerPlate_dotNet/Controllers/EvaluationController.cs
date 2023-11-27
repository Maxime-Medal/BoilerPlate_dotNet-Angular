using BoilerPlate_dotNet.Data.Dto;
using BoilerPlate_dotNet.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate_dotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private IEvaluationRepository _evaluationRepository;

        public EvaluationController(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOccupation(CreateEvaluation evaluation)
        {
            await this._evaluationRepository.Add(evaluation);
            return Ok("Une évaluation a été associé a une personne");
        }
    }
}
