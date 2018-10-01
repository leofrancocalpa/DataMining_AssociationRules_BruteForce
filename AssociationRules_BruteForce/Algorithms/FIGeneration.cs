using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FIGeneration
    {
        private double minsup;
        private Data datos;
        public List<ItemSet> candidates { get; set; }
        public List<ItemSet> fItemSets { get; set; }

        //Constructor
        public FIGeneration(double minSupport, Boolean test)
        {
            minsup = minSupport/100;
            datos = new Data(minsup);
            if (test)
            {
                datos.loadDataTest();
            }
            datos.LoadTransactions();
            datos.FiltrarPorSupport();
            candidates = new List<ItemSet>();
            fItemSets = new List<ItemSet>();
        }

        //Frequent Intemset Generation Apriori Algorithm 
        public void FrequentIGApriorio()
        {
            int k = 1; // size k of itemset (k-itemset)
            Dictionary<String, Item> fItemSetK1 = datos.frequentItems;
            do
            {
                k++;

            } while (fItemSetK1.Count != 0);
        }

        public void loadItemSet(int setLenght)
        {
            Combinacion comb = new Combinacion();
            List<IEnumerable<KeyValuePair<String, Item>>> sets = comb.Combinations(datos.frequentItems, setLenght).ToList();
            Console.WriteLine("Tamaño conjuntos comb: " + sets.Count);
            foreach (IEnumerable<KeyValuePair<String, Item>> conjunto in sets)
            {
                ItemSet newItemSet = new ItemSet();
                List<KeyValuePair<String, Item>> evaluado = conjunto.ToList();
                evaluado.ForEach(x => newItemSet.items.Add(x.Key, x.Value));
                candidates.Add(newItemSet);

            }
        }

        public List<ItemSet> BruteForce()
        {
            Dictionary<String, Transaction> transactions = datos.transactions;
            foreach (ItemSet itemset in candidates)
            {
                Console.WriteLine("Itemset: -------------");
                foreach (KeyValuePair<String, Transaction> transaccion in transactions)
                {
                    Console.WriteLine("Transaccion:-----------");
                    int valor = 0;
                    foreach (KeyValuePair<String, Item> item in itemset.items)
                    {
                        Console.WriteLine("item: >" + item.Key);
                        if (transaccion.Value.items.items.ContainsKey(item.Key))
                        {
                            valor++;
                            Console.WriteLine("item entra: " + item);
                        }
                    }
                    Console.WriteLine("valor: " + valor);
                    if (valor == itemset.items.Count)
                    {
                        itemset.IncreaseSupport();
                        String ite = "";
                        itemset.items.ToList().ForEach(x => ite += x.Key + " ");
                        Console.WriteLine("Entro: " + transaccion.Value.cod + " " + itemset.countSupport + " <" + ite);
                    }
                }

            }
            return fItemSets;
        }
        
        public void pruning()
        {
            foreach(ItemSet itemset in candidates)
            {
                if (itemset.countSupport >= 0.2 * datos.transactions.Count)
                {
                    Console.WriteLine(itemset.countSupport + "++ " + minsup*datos.transactions.Count);
                    fItemSets.Add(itemset);
                }
            }
        }
    }
}
