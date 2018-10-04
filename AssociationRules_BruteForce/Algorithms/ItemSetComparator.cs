using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class ItemSetComparator : IEqualityComparer<ItemSet>
    {
        public bool Equals(ItemSet x, ItemSet y)
        {
            if (x.items.Count == y.items.Count)
            {
                int coincidencias = 0;
                foreach(KeyValuePair<String, Item> item in x.items)
                {
                    if (y.items.ContainsKey(item.Key))
                    {
                        coincidencias++;
                    }
                }
                if (coincidencias == x.items.Count)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(ItemSet obj)
        {
            return obj.items.GetHashCode();
        }
    }
}
