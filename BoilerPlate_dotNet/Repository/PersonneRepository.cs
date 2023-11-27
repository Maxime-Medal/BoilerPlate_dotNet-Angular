using BoilerPlate_dotNet.Data.Domain;
using BoilerPlate_dotNet.Data.Dto;
using BoilerPlate_dotNet.Data;
using BoilerPlate_dotNet.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BoilerPlate_dotNet.Repository
{
    public class PersonneRepository : IPersonneRepository
    {
        private ApplicationDbContext _dbContext;

        public PersonneRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(CreatePersonne personne)
        {

            int age = DateTime.Now.Year - personne.DateNaissance.Year;

            if (DateTime.Now < personne.DateNaissance.AddYears(age))
            {
                age--;
            }
            if (age >= 70)
            {
                throw new Exception("la personne doit avoir moins de 70 ans !");
            }

            Personne newPersonne = new Personne
            {
                Id = 0,
                Nom = personne.Nom,
                Prenom = personne.Prenom,
                DateNaissance = personne.DateNaissance,
            };

            await this._dbContext.Personne.AddAsync(newPersonne);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<List<PersonneDetails>> GetAllDetails()
        {
            List<PersonneDetails> personneDetails = new List<PersonneDetails>();
            List<Personne> personnes = await this._dbContext.Personne.Select(p => p).Include(p => p.Evaluations).ThenInclude(eval => eval.Competence).ToListAsync();

            personnes.ForEach(personne =>
            {
                List<Evaluation> evals = personne.Evaluations.Select(eval => eval).OrderByDescending(eval => eval.Note).ToList();
                List<EvaluationDto> evalDto = new List<EvaluationDto>();
                foreach (var ev in evals)
                {
                    EvaluationDto eval = new EvaluationDto
                    {
                      Id = ev.Id,
                      Competence = ev.Competence.Nom,
                      Note = ev.Note
                    };  
                    evalDto.Add(eval);
                }
                PersonneDetails p = new PersonneDetails
                {
                    Id = personne.Id,
                    Nom = personne.Nom,
                    Prenom = personne.Prenom,
                    DateNaissance = personne.DateNaissance,
                    evaluations = evalDto,
                };

                personneDetails.Add(p);
            });
            return personneDetails.OrderBy(p => p.Nom).ToList();
        }

        public async Task<List<PersonneDetails>> GetPersonnesByCompetence(string competence)
        {
            List<PersonneDetails> personneDetails = new List<PersonneDetails>();
            List<Personne> personnes = await this._dbContext.Personne.Where(p => p.Evaluations.Any(eval => eval.Competence.Nom == competence))
                                                                     .ToListAsync();
            personnes.ForEach(personne =>
            {
                PersonneDetails p = new PersonneDetails
                {
                    Id = personne.Id,
                    Nom = personne.Nom,
                    Prenom = personne.Prenom,
                    DateNaissance = personne.DateNaissance,  
                };

                personneDetails.Add(p);
            });
            return personneDetails;
        }

    }
}
