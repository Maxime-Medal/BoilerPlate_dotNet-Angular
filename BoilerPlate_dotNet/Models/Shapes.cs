namespace BoilerPlate.Models
{
    public class Shape
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().ToUpper();
        public string FormType { get; set; } = string.Empty;
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Order { get; set; }
    }

    public class ShapesList
    {
        public List<Shape>? Shapes { get; set; }
    }
}
