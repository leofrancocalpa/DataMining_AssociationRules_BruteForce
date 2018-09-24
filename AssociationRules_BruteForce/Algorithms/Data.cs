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
        }

        public Dictionary<String, Item> FiltrarItems()
        {
            Dictionary<String, Item> salida = new Dictionary<string, Item>();
            //salida=items.Where(x => x.Value.countSupport >= (minSupport * items.Count())).ToDictionary(x=> x.Key, x=>x.Value);
            foreach(KeyValuePair<String, Item> pairs in items)
            {
                //Console.WriteLine(pairs.Value.countSupport);
                if (pairs.Value.countSupport >= (minSupport * items.Count()))
                {
                    salida.Add(pairs.Key, pairs.Value);
                }
            }
            return salida;
        }

        public void LoadTransactions()
        {
            String lineaV = "";
            try
            {
                StreamReader srv = new StreamReader(routeV);
                lineaV = srv.ReadLine();
                while (lineaV != null)
                {
                    String[] data = lineaV.Split(';');
                    /*if (transactions[data[1]]!=null)
                    {
                        transactions[data[1]].items.Add(items[data[4]]);
                        items[data[4]].IncreaserCount();
                    }
                    else
                    {*/
                        Transaction T = new Transaction(data[0], data[1], data[2]);
                        T.items.Add(items[data[4]]);
                        items[data[4]].IncreaserCount();
                        Console.WriteLine(items[data[4]]);
                        
                   // }

                    lineaV = srv.ReadLine();
                    /*if (lineaV != null)
                    {
                        String[] data1 = lineaV.Split(';');
                        while ((data1[1].Equals(data[1])) && lineaV != null)
                        {
                            T.items.Add(items[data1[4]]);
                            items[data1[4]].IncreaserCount();
                            lineaV = srv.ReadLine();
                        }
                    }*/
                }

                srv.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Err: " + e.StackTrace);
            }
        }

        public void LoadFrequentItems()
        {
            String line = "";
            try
            {
                StreamReader sr = new StreamReader(routeFI);
                while ((line = sr.ReadLine()) != null)
                {
                    String[] data = line.Split(';');
                    Item i = new Item(data[0], data[1]);
                    frequentItems.Add(i.cod, i);
                }
                sr.Close();
            }
            catch(Exception e)
            {

            }
        }

        private void FindData()
        {
            String lineA = "";
            try
            {
                StreamReader sra = new StreamReader(routeA);

                while ((lineA = sra.ReadLine()) != null)
                {
                    String[] data = lineA.Split(';');
                    if (!(data[0].Contains('*') || data[0].Equals("NULL")) && !(data[1].Contains('*') || data[1].Equals("NULL")))
                    {
                        Item i = new Item(data[0], data[1]);
                        items.Add(i.cod, i);
                    }
                }
                sra.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error malo: " + e.StackTrace);
            }
        }

        public void SaveRelevantItems()
        {
            FindData();
            LoadTransactions();
            try
            {
                String routeToSave = routeFI;
                StreamWriter sw = new StreamWriter(routeToSave, true);
                foreach(KeyValuePair<String, Item> pairs in FiltrarItems())
                {
                    String line = pairs.Key + ";" + pairs.Value.name;
                    sw.WriteLine(line);
                }
                sw.Close();
            }
            catch(Exception e)
            {

            }
        }
    }
}
