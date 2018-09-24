using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Data
    {
        private String routeA = "..\\..\\..\\Data\\Articulos.csv";
        private String routeC = "..\\..\\..\\Data\\Clientes.csv";
        private String routeV = "..\\..\\..\\Data\\Ventas.csv";
        private String routeFI = "..\\..\\..\\Data\\FrequentItems.csv";
        private double minSupport;

        private Dictionary<String, Item> items { get; set; }
        public Dictionary<String, Transaction> transactions { get; set; }
        public Dictionary<String, Item> frequentItems { get; set; }

        public Data(int minS)
        {
            minSupport = minS/100;
            items = new Dictionary<String, Item>();
            transactions = new Dictionary<string, Transaction>();
            frequentItems = new Dictionary<string, Item>();
        }

        public void LoadTransactions()
        {
            try
            {

            }
            catch(Exception e)
            {
                Console.WriteLine()
            }
        }
    }
}
