namespace BoilerPlate.Models
{
    public class SeedData
    {
        //public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    using (var context = new BoilerPlateContext(
        //       serviceProvider.GetRequiredService<
        //           DbContextOptions<BoilerPlateContext>>()))
        //    {
        //        if(context.Shape.Any()) 
        //        {
        //            return;
        //        }

        //        ShapesList shapesList = GetShapes();

        //        foreach (var shape in shapesList.Shapes)
        //        {
        //            context.Shape.Add(shape);
        //        }
        //        context.SaveChanges();
        //    }
        //}

        //// TODO Pour faire un seeding à partir d'un Json
        //private static ShapesList GetShapes()
        //{
        //    string JsonShapes = System.IO.File.ReadAllText(@"Data" + Path.DirectorySeparatorChar + "shapes.json");
        //    ShapesList shapesList = JsonConvert.DeserializeObject<ShapesList>(JsonShapes) ?? new ShapesList();
        //    return shapesList;
        //}

        //// TODO Pour faire un seeding à partir d'une liste en dur
        //private static List<People> GetPeople()
        //{

        //    var peopleList = new List<People>
        //    {
        //        new People
        //        {
        //            Name = "Fred",
        //            Age = 14,
        //            Job = "Écolier"
        //        },new People
        //        {
        //            Name = "Claire",
        //            Age = 35,
        //            Job = "Enseignante"
        //        },new People
        //        {
        //            Name = "Dominique",
        //            Age = 67,
        //            Job = "Retraité"
        //        },
        //    };
        //    return peopleList;
        //}

    }
}
