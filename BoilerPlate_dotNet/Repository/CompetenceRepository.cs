using BoilerPlate_dotNet.Data;
using BoilerPlate_dotNet.Data.Domain;
using BoilerPlate_dotNet.Data.Dto;
using BoilerPlate_dotNet.Repository.Interface;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlate_dotNet.Repository
{
    public class CompetenceRepository : ICompetenceRepository
    {
        private ApplicationDbContext _dbContext;

        public CompetenceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CompetenceSimple>> GetAllCompetence()
        {
            List<Competence> competences = await this._dbContext.Competence.Select(c => c).ToListAsync();
            List<CompetenceSimple> comp = new List<CompetenceSimple>();

            foreach (var c in competences)
            {
                comp.Add(new CompetenceSimple { Id = c.Id, Nom = c.Nom, Type = c.Type });
            }
            return comp;
        }

        public async Task<List<CompetenceSimple>> GetCompetenceByNomPersonne(string nomPersonne)
        {
            Personne personne = await this._dbContext.Personne.Where(p => p.Nom == nomPersonne).FirstAsync();
            List<CompetenceSimple> comp = new List<CompetenceSimple>();

            var competences = this._dbContext.Evaluation
                                .Where(e => e.PersonneId == personne.Id)
                                .OrderByDescending(e => e.Note)
                                .ThenBy(e => e.Competence.Nom)
                                .Include(e => e.Competence.Evaluations)
                                .Select(e => e.Competence)
                                .ToList();
            foreach (var c in competences)
            {
                List<EvalSimple> evalSimples = new List<EvalSimple>();
                foreach (var e in c.Evaluations)
                {
                    evalSimples.Add(new EvalSimple { Id = c.Id, Note = e.Note });
                }
                comp.Add(new CompetenceSimple { Id = c.Id, Nom = c.Nom, Note = evalSimples.Select(e => e.Note).First(), Type = c.Type });  
            }
            return comp;
        }
        public async Task Add(CreateCompetence competence)
        {
            var newCompetence = new Competence { Id = 0, Type = competence.Type, Nom = competence.Nom };
            this._dbContext.Competence.Add(newCompetence);
            await this._dbContext.SaveChangesAsync();
        }
    }

}
