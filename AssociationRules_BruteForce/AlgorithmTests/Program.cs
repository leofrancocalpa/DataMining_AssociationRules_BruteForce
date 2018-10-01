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
            double minS = Convert.ToInt32(Console.ReadLine());
            FIGeneration fIGeneration = new FIGeneration(minS, true);
            Console.WriteLine("Ingrese el tamaño de r para las combinaciones");
            int tamCom = Convert.ToInt32(Console.ReadLine());
            fIGeneration.loadItemSet(tamCom);
            fIGeneration.BruteForce();
            fIGeneration.pruning();

            foreach(ItemSet itemset in fIGeneration.fItemSets)
            {
                String cods = "";
                itemset.items.ToList().ForEach(x => cods += x.Value.cod+" ");
                Console.WriteLine("Conjunto frecuente. Support: "+itemset.countSupport+" "+cods);
                
            }
            
            //Console.ReadLine();
            Console.WriteLine("¡Terminó!");
            Console.ReadLine();
        }
        
    }
}
