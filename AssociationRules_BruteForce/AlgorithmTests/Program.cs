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
            FIGeneration fIGeneration = new FIGeneration(minS, true);//true ejemplo del libro, false datos allers

            fIGeneration.FrequentItemGeneration(3);// parametro tamaño k de k-itemset comniacion maximo
            //fIGeneration.AprioriFrequentItemGeneration();
            
            foreach(ItemSet itemset in fIGeneration.candidates)
            {
                String cods = "";
                itemset.items.ToList().ForEach(x => cods += x.Value.cod+" ");
                Console.WriteLine("Conjunto frecuente -> Support: "+itemset.countSupport+" Conjunto: "+cods);
                
            }
            
            //Console.ReadLine();
            Console.WriteLine("¡Terminó!");
            Console.ReadLine();
        }
        
    }
}
