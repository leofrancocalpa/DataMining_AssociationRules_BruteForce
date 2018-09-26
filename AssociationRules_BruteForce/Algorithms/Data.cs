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

        public Data(double minS)
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
                    if (transactions.ContainsKey(datos[1]))
                    {
                        Item actualItem = new Item(datos[4]);
                        transactions[datos[1]].items.Add(actualItem);
                        if (!items.ContainsKey(datos[4]))
                        {
                            items.Add(actualItem.cod, actualItem);
                        }
                        items[datos[4]].IncreaserCount();
                    }
                    else
                    {
                        Transaction actual = new Transaction(datos[0], datos[1], datos[2]);
                        transactions.Add(datos[1], actual);
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
                Console.WriteLine("Numero de items: "+items.Count());
            }
            catch(Exception e)
            {
                Console.WriteLine("Error LoadTransaction: \n" + e.StackTrace);
            }
        }

        public void FiltrarPorSupport()
        {
            Console.WriteLine("Numero de transacciones: "+transactions.Count);
            foreach(KeyValuePair<String, Item> pairs in items)
            {
                int c = pairs.Value.countSupport;
                if (c>(minSupport*transactions.Count))
                {
                    frequentItems.Add(pairs.Key, pairs.Value);
                }
            }
            Console.WriteLine("Items frecuentes: "+frequentItems.Count);
        }
    }
}
