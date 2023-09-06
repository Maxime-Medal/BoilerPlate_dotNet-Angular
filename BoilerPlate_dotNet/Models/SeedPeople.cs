using Microsoft.EntityFrameworkCore;
using BoilerPlate.Models;
using Newtonsoft.Json;
using BoilerPlate.Data;

namespace BoilerPlate.Models
{
    public class SeedPeople
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BoilerPlateContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<BoilerPlateContext>>()))
            {
                if(context.People.Any()) 
                {
                    return;
                }

                List<People> PeopleList = GetPeople();

                foreach (var people in PeopleList)
                {
                    context.People.Add(people);
                }
                context.SaveChanges();
            }
        }

        // TODO Pour faire un seeding à partir d'une liste en dur

        private static List<People> GetPeople()
        {
            
            var peopleList = new List<People>
            {
                new People
                {
                    Name = "Fred",
                    Age = 14,
                    Job = "Écolier"
                },new People
                {
                    Name = "Claire",
                    Age = 35,
                    Job = "Enseignante"
                },new People
                {
                    Name = "Dominique",
                    Age = 67,
                    Job = "Retraité"
                },
            };
            return peopleList;
        }
    }
}
