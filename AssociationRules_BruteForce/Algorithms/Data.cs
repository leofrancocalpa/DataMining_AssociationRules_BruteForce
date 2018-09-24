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
        private String routeArticulos = "..\\..\\..\\Data\\Articulos.csv";
        private String routeClientes = "..\\..\\..\\Data\\Clientes.csv";
        private String routeVentas = "..\\..\\..\\Data\\Ventas.csv";
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
                StreamReader sr = new StreamReader(routeVentas);
                String line = sr.ReadLine();
                line = sr.ReadLine();
                while (line != null)
                {

                    String[] datos = line.Split(';');
                    if (transactions.ContainsKey(datos[2]))
                    {
                        Item actualItem = new Item(datos[4]);
                        transactions[datos[2]].items.Add(actualItem);
                        if (!items.ContainsKey(datos[4]))
                        {
                            items.Add(actualItem.cod, actualItem);
                        }
                        items[datos[4]].IncreaserCount();
                    }
                    else
                    {
                        Transaction actual = new Transaction(datos[0], datos[1], datos[2]);
                        transactions.Add(datos[2], actual);
                        Item actualItem = new Item(datos[4]);
                        actual.items.Add(actualItem);
                        if (!items.ContainsKey(datos[4]))
                        {
                            items.Add(actualItem.cod, actualItem);
                        }
                        items[datos[4]].IncreaserCount();
                    }

                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine(items.Count());
            }
            catch(Exception e)
            {
                Console.WriteLine("Error LoadTransaction: \n" + e.StackTrace);
            }
        }

        public void FiltrarPorSupport()
        {
            foreach(KeyValuePair<String, Item> pairs in items)
            {
                Console.WriteLine(pairs.Value.countSupport);
                if (!(pairs.Value.countSupport >= (minSupport * items.Count())))
                {
                    
                    items[pairs.Key]=null;
                }
            }
            foreach (KeyValuePair<String, Item> pairs in items)
            {
                if (pairs.Value!=null)
                {
                    frequentItems.Add(pairs.Key, pairs.Value);
                }
            }
            Console.WriteLine(frequentItems.Count());
        }
    }
}
