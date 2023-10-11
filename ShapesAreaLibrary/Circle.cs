namespace Shapes
{
    public class Circle : IShapeArea
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Вычисляет площадь круга по радиусу
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        /// <returns>Площадь круга по radius</returns>
        public double GetArea()
        {
            return double.Pi * Math.Pow(Radius, 2);
        }
    }
}
