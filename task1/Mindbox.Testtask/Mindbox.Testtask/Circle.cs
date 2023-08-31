using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mindbox.Testtask
{
    public class Circle : ISquareCalcable
    {
        double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double CalcSquare()
        {
            if(radius > Math.Sqrt(double.MaxValue / Math.PI)){
                throw new ArgumentOutOfRangeException("Полученный результат больше диапазона значений double!");
            }
            return Math.Pow(radius, 2) * Math.PI;
        }
    }
}
