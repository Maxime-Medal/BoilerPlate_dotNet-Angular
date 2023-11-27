using BoilerPlate_dotNet.Data.Dto;

namespace BoilerPlate_dotNet.Repository.Interface
{
    public interface IEvaluationRepository
    {
        Task Add(CreateEvaluation evaluation);
    }
}
