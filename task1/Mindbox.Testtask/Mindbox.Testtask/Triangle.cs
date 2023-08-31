using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mindbox.Testtask
{
    public class Triangle : ISquareCalcable
    {
        double A, B, C;
        public Triangle(double A, double B, double C)
        {
            this.A = A; this.B = B; this.C = C;
        }
        void checkSides()
        {
            if(A >= B + C || B >= A + C || C >= A + B) 
            {
                throw new ArgumentException("Треугольника с заданными сторонами не существует!");
            }
        }

        public double CalcSquare()
        {
            checkSides();
            double eps = 0.0001;
            //Присвоим наибольшую длину A
            if(B > A || C > A)
            {
                double temp = A;
                if(B > C)
                {
                    A = B;
                    B = temp;
                }
                else
                {
                    A = C;
                    C = temp;
                }
            }
            //Проверим, прямоугольный ли треугольник
            if(Math.Abs(A * A - (B * B + C * C)) < eps)
            {
                return (B * C) / 2;
            }
            //Если нет, то считаем по формуле
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}
