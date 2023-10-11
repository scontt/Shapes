using System.Linq;

namespace Shapes
{
    public class Triangle : IShapeArea
    {
        public double A { get ; set; }
        public double B { get ; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c)
        {
            if (!TriangleExists(a, b, c))
            {
                A = a;
                B = b;
                C = c;
            }
            else
                throw new ArgumentException("Треугольника с данными сторонами не существует");
        }

        public Triangle(double[] sides)
        {
            if (!TriangleExists(sides[0], sides[1], sides[2]))
            {
                A = sides[0];
                B = sides[1];
                C = sides[2];
            }
            else
                throw new ArgumentException("Треугольника с данными сторонами не существует");
        }

        /// <summary>
        /// Вычисляет площадь треугольника по трем сторонам, принимая три double значения
        /// </summary>
        /// <param name="a">Сторона A</param>
        /// <param name="b">Сторона B</param>
        /// <param name="c">Сторона C</param>
        /// <returns>Площадь треугольника по трем сторонам a, b, c</returns>
        public double GetArea()
        {
            // Вычисление полупериметра треугольника
            double p = (A + B + C) / 2;
            // Вычисление площади треугольника
            double area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            // Проверка на NaN
            if (double.IsNaN(area))
                throw new InvalidOperationException("Ошибка вычисления");

            return area;
        }

        /// <summary>
        /// Проверяет, является ли треугольник прямоугольным
        /// </summary>
        /// <returns>bool</returns>
        public bool IsRight()
        {
            (double max, double mid, double min) = MaxSide(A, B, C);

            if (max == Math.Sqrt(Math.Pow(min, 2) + Math.Pow(mid, 2)))
                return true;
            else
                return false;
        }

        public static (double max, double mid, double min) MaxSide(double a, double b, double c)
        {
            double max = Math.Max(Math.Max(a, b), c);
            double min = Math.Min(Math.Min(a, b), c);
            double mid = a + b + c - max - min;

            return (max, mid, min);
        }

        public static bool TriangleExists(double a, double b, double c)
        {
            (double max, double mid, double min) = MaxSide(a, b, c);
            return max > min + mid;
        }
    }
}
