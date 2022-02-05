using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_lessons_app
{
    class Fraction
    {
        int numerator { get; }
        int denominator { get; }

        public Fraction(int _numerator, int _denominator)
        {
            this.numerator = _numerator;
            this.denominator = _denominator;
        }

        static Fraction Simplify (Fraction fraction)
        {
            int _nom = Math.Abs(fraction.numerator);
            int _den=Math.Abs(fraction.denominator);
            int maxDevider= _nom > _den ? _den : _nom;

            while (maxDevider>1)
            {
                bool checkNumenator = fraction.numerator % maxDevider==0;
                bool checkDenominator = fraction.denominator % maxDevider==0;
                if (checkNumenator && checkDenominator)
                {
                    return new Fraction(fraction.numerator / maxDevider, fraction.denominator / maxDevider);
                } 
                else
                {
                    maxDevider--;
                }
            }
            return fraction;
        }

        static public Fraction operator + (Fraction a, Fraction b)
        {
            int newDenomenator = a.denominator * b.denominator;
            int newNumenator=a.numerator*b.denominator+b.numerator*a.denominator;
            Fraction result = new Fraction(newNumenator, newDenomenator);
            return Fraction.Simplify(result);
        }

        static public Fraction operator - (Fraction a, Fraction b)
        {
            int newDenomenator = a.denominator * b.denominator;
            int newNumenator = a.numerator * b.denominator - b.numerator * a.denominator;
            Fraction result = new Fraction(newNumenator, newDenomenator);
            return Fraction.Simplify(result);
        }

        static public Fraction operator * (Fraction a, Fraction b)
        {
            int newDenomenator = a.denominator * b.denominator;
            int newNumenator = a.numerator * b.numerator;
            Fraction result = new Fraction(newNumenator, newDenomenator);
            return Fraction.Simplify(result);
        }

        static public Fraction operator / (Fraction a, Fraction b)
        {
            int newDenomenator = a.denominator * b.numerator;
            int newNumenator = a.numerator * b.denominator;
            Fraction result = new Fraction(newNumenator, newDenomenator);
            return Fraction.Simplify(result);
        }

        public void PrintInfo()
        {
            string result = $"{this.numerator}/{this.denominator}";
            if (denominator == 1) result = $"{numerator}";
            Console.WriteLine(result);
        }
    }
}
