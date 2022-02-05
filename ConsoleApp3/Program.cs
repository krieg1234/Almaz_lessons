namespace Almaz_lessons_app
{
    public class Program
    {
       static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(2, 10); //создать дробь
            Fraction fraction2 = new Fraction(3, 5);
            Fraction result;

            result = fraction1 + fraction2;
            result.PrintInfo(); //вывести результат на консоль
            result = fraction1 - fraction2;
            result.PrintInfo();
            result = fraction1 * fraction2;
            result.PrintInfo();
            result = fraction2 / fraction1;
            result.PrintInfo();




            Figure[] figures = Figure.CreateFigureArr(10); //создать массив случайных фигур
            foreach (Figure f in figures)
            {
                f.PrintInfo(); //вывести информацию о фигуре на консоль
            }
            Console.WriteLine("----");
            figures = I2DFigure.FindMaxSquareFigures(figures); //найти фигуру с наибольшей площадью
            foreach (Figure f in figures)
            {
                f.PrintInfo();
                I2DFigure i2DFigure=(I2DFigure)f;
                Console.WriteLine(i2DFigure.GetSquare());
                
            }

        }
    }
}





