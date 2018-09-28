using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Combinacion
    {
        static Func<int, double> factorial = x => Enumerable.Range(1, x).Aggregate(1.0, (a, b) => a * b);
        static Func<int, int, double> combinatoria = (x, y) => (factorial(x))/((factorial(y))*factorial(x-y));

        public Combinacion()
        {

        }

        public List<IEnumerable<T>> Combinations<T>(IEnumerable<T> items, int setLenght)
        {
            if (setLenght == 1)
                return items.Select(e => Enumerable.Repeat(e, 1)).ToList();
            else if (setLenght == items.Count())
                return Enumerable.Repeat(items, 1).ToList();
            else
            {
                return Combinations(items.Skip(1), setLenght - 1)
                                .Select(tail => Enumerable.Repeat(items.First(), 1).Union(tail))
                                .Union(Combinations(items.Skip(1), setLenght)).ToList();
            }
        }
    }
}
