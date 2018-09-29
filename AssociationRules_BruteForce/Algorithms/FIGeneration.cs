using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FIGeneration
    {
        private int minsup;
        private Data datos;
        public List<ItemSet> itemSet { get; set; }

        //Constructor
        public FIGeneration(int minSupport)
        {
            minsup = minSupport;
            datos = new Data(minsup);
            datos.LoadTransactions();
            datos.FiltrarPorSupport();
            itemSet = new List<ItemSet>();
        }

        //Frequent Intemset Generation Apriori Algorithm 
        public void FrequentIGApriorio()
        {
            int k = 1; // size k of itemset (k-itemset)
            //HashSet<>
        }

        public void loadItemSet(int setLenght)
        {
            Combinacion comb = new Combinacion();
            List<IEnumerable<KeyValuePair<String, Item>>> sets = comb.Combinations(datos.frequentItems, 3).ToList();
            foreach (IEnumerable<KeyValuePair<String, Item>> conjunto in sets)
            {
                ItemSet newItemSet = new ItemSet();
                List<KeyValuePair<String, Item>> evaluado = conjunto.ToList();
                evaluado.ForEach(x => newItemSet.items.Add(x));
                itemSet.Add(newItemSet);
                
            }
        }

        public void BruteForce()
        {
            Dictionary<String, Transaction> transactions = datos.transactions;
            foreach(ItemSet itemset in itemSet)
            {  
               foreach(KeyValuePair<String, Transaction> transaccion in transactions)
                {
                    int valor = 0;
                    foreach (KeyValuePair<String, Item> item in itemset.items)
                    {
                        if(transaccion.Value.items.Contains(item.Value))
                        {
                            valor++;
                            //Console.WriteLine("1sddxxxxxxxxxxxxxxxxxxxxxx");
                        }
                    }
                    if (valor == itemset.items.Count)
                    {
                        Console.WriteLine("2ddyyyyyyyyyyyyyyyyyyyyyy");

                        itemset.IncreaseSupport();
                    }
                }
               
            }
        }
    }
}
