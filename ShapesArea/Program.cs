using Shapes;

namespace TestProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int N = 3;
            double[] sides = new double[N];
            double radius;
            double triangleArea;

            try // Блок try с вычислением площади треугольника
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Введите {i + 1} сторону треугольника: ");
                    sides[i] = Convert.ToDouble(Console.ReadLine());
                }
                var triangle = new Triangle(sides);
                triangleArea = triangle.GetArea();
                Console.WriteLine("Площадь треугольника по трем сторонам: {0}", triangleArea);

                //Проверка прямоугольности треугольника
                if (triangle.IsRight())
                    Console.WriteLine("Треугольник является прямоугольным");
                else
                    Console.WriteLine("Треугольник не является прямоугольным");
                Console.WriteLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенное значение имеет неверный формат");
                return;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try // Блок try с вычислением площади круга
            {
                Console.WriteLine("Введите радиус круга: ");
                radius = Convert.ToDouble(Console.ReadLine());
                var circle = new Circle(radius);
                double circleArea = circle.GetArea();
                Console.WriteLine("Площадь круга по радиусу: {0}\n", circleArea);
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенное значение имеет неверный формат");
                return;
            }
        }
    }
}