using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Item
    {
        public String cod { get; set; }
        public String name { get; set; }
        public int countSupport { get; set; }
        public Boolean candidate { get; set; }

        public Item(String cod, String name)
        {
            this.cod = cod;
            this.name = name;
        }

        public void IncreaserCount()
        {
            countSupport++;
        }
    }
}
