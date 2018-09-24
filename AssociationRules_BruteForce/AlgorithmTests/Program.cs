using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace AlgorithmTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine("Elija una opción:");
            Console.WriteLine("1. Depurar Datos de entrada (1)");
            Console.WriteLine("2. Correr algoritmo Apriori con busqueda intensiva (2)");
            Console.WriteLine("*******************************************************");
            Console.WriteLine("\n");

            int num = Convert.ToInt32(Console.ReadLine());

            if (num == 1)
            {
                Console.WriteLine("Ingrese valor de minSupport para los items (10-100)");
                int minS = Convert.ToInt32(Console.ReadLine());
                Data data = new Data(minS);
                //data.LoadTransactions();
                data.SaveRelevantItems();
                Console.WriteLine("Acabó");
                Console.ReadLine();
            }
        }
    }
}
