using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ItemSet 
    {
        public Dictionary<String, Item> items { get; set; }
        public int countSupport { get; set; }

        public ItemSet()
        {
            items = new Dictionary<string, Item>();
            countSupport = 0;
        }

        public void IncreaseSupport()
        {
            countSupport+=1;
        }

        public Boolean ContainsItems(Dictionary<String, Item> evaluated)
        {
            Boolean salida = false;
            int count = 0;
            foreach(KeyValuePair<String, Item> pairs in evaluated)
            {
                if (items.ContainsKey(pairs.Key))
                {
                    count++;
                }
            }
            if (count == evaluated.Count)
            {
                salida = true;
            }
            return salida;
        }
    }
}
