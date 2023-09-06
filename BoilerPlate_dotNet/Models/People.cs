using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public int Age { get; set; }
        //public ICollection<Hobbies>? Hobbies { get; }
    }

    //public class Hobbies
    //{
    //    public int Id { get; set; }
    //    public string Name { set; get; } = string.Empty;
    //    //public People? People { get; set; }

    //}
}

