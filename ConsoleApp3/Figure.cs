using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    abstract  class Figure
    {
        public static string[] colors = { "красный", "зелёный", "синий" };
        public abstract string type { get; }
        public string color { get; set; }

        public Figure(string _color)
        {
            if (Array.IndexOf(colors, _color) == -1)
                throw new InvalidColorExeption("Установлен недопустимый цвет", _color);

            color = _color;           
        }

        public Figure() { }

        public void PrintInfo()
        {
            Console.WriteLine($"Type: {type}, color: {color}");
        } 
        
        public static Figure[] CreateFigureArr(int size)
        {
            Figure[] figures = new Figure[size];
            for (int i = 0; i < size; i++)
            {
                figures[i] = CreateRandomFigure();
            }
            return figures;
        }

        public static Figure CreateRandomFigure()
        {
            Random rnd = new Random();
            
            Figure[] types = {
                new Squere(), 
                new Rectangle() , 
                new Triangle() ,
                new Circle() , 
                new Cube() , 
                new Ball() 
            };

            return (Figure)types[rnd.Next(types.Length)];           
        }       
    }   

    interface I2DFigure
    {
        double GetSquare();
        double GetPerimeter();

        static Figure[] FindMaxSquareFigures(Figure[] figures)
        {
            double maxSquare = 0;
            Figure[] result = { };
            foreach (Figure f in figures)
            {
                if (f is not I2DFigure) continue;
                else
                {
                    I2DFigure i2DFigure = (I2DFigure)f;
                    double currentSquare = i2DFigure.GetSquare();
                    if (currentSquare > maxSquare)
                    {
                        maxSquare = currentSquare;
                        result = new Figure[] { f };
                    }
                    if (currentSquare == maxSquare)
                    {
                        Figure[] newResult = new Figure[result.Length + 1];
                        for (int i = 0; i < result.Length; i++)
                        {
                            newResult[i] = result[i];
                        }
                        newResult[newResult.Length - 1] = f;
                        result = newResult;
                    }
                }              
                             
            }
            return result;
        }
    }

    interface I3DFigure
    {
        double GetVolume();
    }

    
    class Squere : Figure, I2DFigure
    {
        public override string type { get; }
        public double sizeA { get; }
        public Squere(string color, double _sizeA): base (color)
        {
            if (_sizeA <= 0) 
                throw new InvalidSizeExeption("Сторона квадрата не может быть 0 и меньше", _sizeA);

            type = "Квадрат";
            sizeA = _sizeA;
        }
        public Squere()
        {
            Random rnd = new Random();

            color = colors[rnd.Next(colors.Length)];
            sizeA = rnd.Next();
            type = "Квадрат";
        }
        public double GetSquare()
        {
            return sizeA * sizeA;
        }
        public double GetPerimeter()
        {
            return sizeA  * 4;
        }        
    }

    class Rectangle : Figure, I2DFigure
    {
        public override string type { get; }
        public double sizeA { get; }
        public double sizeB { get; }
        public Rectangle(string color, double _sizeA, double _sizeB) : base(color)
        {
            if (_sizeA <= 0 )
                throw new InvalidSizeExeption("Сторона прямоугольника не может быть 0 и меньше", _sizeA);
            if (_sizeB <= 0)
                throw new InvalidSizeExeption("Сторона прямоугольника не может быть 0 и меньше", _sizeB);

            type = "Прямоугольник";
            sizeA = _sizeA;
            sizeB = _sizeB;
        }
        public Rectangle()
        {
            Random rnd = new Random();

            color = colors[rnd.Next(colors.Length)];
            sizeA = rnd.Next();
            sizeB = rnd.Next();
            type = "Прямоугольник";
        }
        public double GetSquare()
        {
            return sizeA * sizeB;
        }
        public double GetPerimeter()
        {
            return (sizeA + sizeB) * 2;
        }
    }

    class Triangle : Figure, I2DFigure
    {
        public override string type { get; }
        public double sizeA { get; }
        public double sizeB { get; }
        public double angleAlpha { get; }
        public Triangle(string color, double _sizeA, double _sizeB, double _angleAlpha) : base(color)
        {
            if (_sizeA <= 0 )
                throw new InvalidSizeExeption("Сторона треугольника не может быть 0 и меньше", _sizeA);
            if (_sizeB <= 0)
                throw new InvalidSizeExeption("Сторона треугольника не может быть 0 и меньше", _sizeB);
            if (_angleAlpha <= 0)
                throw new InvalidSizeExeption("Угол треугольника не может быть 0 и меньше", _angleAlpha);
            if (_angleAlpha >= 180)
                throw new InvalidSizeExeption("Угол треугольника не может быть 180 и больше", _angleAlpha);

            type = "Треугольник";
            sizeA = _sizeA;
            sizeB = _sizeB;
            angleAlpha = _angleAlpha;
        }
        public Triangle()
        {
            Random rnd = new Random();

            color = colors[rnd.Next(colors.Length)];
            sizeA = rnd.Next();
            sizeB = rnd.Next();
            angleAlpha = rnd.Next();
            type = "Треугольник";
        }
        public double GetSquare()
        {
            return 0.5*sizeA*sizeB*Math.Sin(angleAlpha);
        }
        public double GetPerimeter()
        {
            return Math.Sqrt(Math.Pow(sizeB,2)+ Math.Pow(sizeA, 2)-2*sizeB*sizeA*Math.Cos(angleAlpha))+sizeB+sizeA;
        }
    }

    class Circle : Figure, I2DFigure
    {
        public override string type { get; }
        public double sizeR { get; }

        public Circle(string color, double _sizeR) : base(color)
        {
            if (_sizeR <= 0)
                throw new InvalidSizeExeption("Радиус круга не может быть 0 и меньше", _sizeR);

            type = "Круг";
            sizeR = _sizeR;
        }
        public Circle()
        {
            Random rnd = new Random();

            color = colors[rnd.Next(colors.Length)];
            sizeR = rnd.Next();            
            type = "Круг";
        }
        public double GetSquare()
        {
            return Math.PI * Math.Pow(sizeR, 2);
        }
        public double GetPerimeter()
        {
            return 2 * sizeR * Math.PI;
        }
    }

    class Cube : Figure, I3DFigure
    {
        public override string type { get; }
        public double sizeA { get; }
        public Cube(string color, double _sizeA) : base(color)
        {
            if (_sizeA <= 0)
                throw new InvalidSizeExeption("Сторона куба не может быть 0 и меньше", _sizeA);

            type = "Куб";
            sizeA = _sizeA;
        }
        public Cube()
        {
            Random rnd = new Random();

            color = colors[rnd.Next(colors.Length)];
            sizeA = rnd.Next();
            type = "Куб";
        }
        public double GetVolume()
        {
            return Math.Pow(sizeA, 3);
        }
    }

    class Ball : Figure, I3DFigure
    {
        public override string type { get; }
        public double sizeR { get; }

        public Ball(string color, double _sizeR) : base(color)
        {
            if (_sizeR <= 0)
                throw new InvalidSizeExeption("Радиус шара не может быть 0 и меньше", _sizeR);

            type = "Шар";
            sizeR = _sizeR;
        }
        public Ball()
        {
            Random rnd = new Random();

            color = colors[rnd.Next(colors.Length)];
            sizeR = rnd.Next();
            type = "Шар";
        }
        public double GetVolume()
        {
            return 4/3*Math.PI*Math.Pow(sizeR,3);
        }
    }
}
