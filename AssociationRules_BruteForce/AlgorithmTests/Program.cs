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

            Console.WriteLine("Ingrese valor de minSupport para los items (1-100)%");
            int minS = Convert.ToInt32(Console.ReadLine());
            Data data = new Data(minS);
            data.LoadTransactions();
            data.FiltrarPorSupport();

            Dictionary<String, Item> FI = data.frequentItems;
            Combinacion comb = new Combinacion();
            List<IEnumerable<KeyValuePair<String,Item >>> sets = comb.Combinations(FI, 3).ToList();

            //Console.ReadLine();

            foreach(IEnumerable<KeyValuePair<String,Item>> conjunto in sets)
            {
                List<KeyValuePair<String, Item>> evaluado = conjunto.ToList();
                String itemsC = " ";
                evaluado.ToList().ForEach(x => itemsC += x.Value.cod + " ");
                Console.WriteLine(itemsC);
            }
            Console.WriteLine("¡Terminó!");
            Console.ReadLine();
        }
        
    }
}
