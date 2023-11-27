using BoilerPlate_dotNet.Data;
using BoilerPlate_dotNet.Data.Domain;
using BoilerPlate_dotNet.Data.Dto;
using BoilerPlate_dotNet.Repository.Interface;

namespace BoilerPlate_dotNet.Repository
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private ApplicationDbContext _dbContext;
        public EvaluationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(CreateEvaluation evaluation)
        {
            if (evaluation.Note < 1 || evaluation.Note > 5)
            {
                throw new Exception("la note doit avoir être de 1 et 5 !");
            }

            Evaluation newEvaluation = new Evaluation
            {
                Id = 0,
                CompetenceId = evaluation.CompetenceId,
                PersonneId = evaluation.PersonneId,
                Note = evaluation.Note,
            };
            await this._dbContext.Evaluation.AddAsync(newEvaluation);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
