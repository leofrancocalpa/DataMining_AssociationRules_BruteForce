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
        public List<KeyValuePair<String, Item>> items { get; set; }
        public int countSupport { get; set; }

        public ItemSet()
        {
            items = new List<KeyValuePair<string, Item>>();
            countSupport = 0;
        }

        public void IncreaseSupport()
        {
            countSupport++;
        }
    }
}
