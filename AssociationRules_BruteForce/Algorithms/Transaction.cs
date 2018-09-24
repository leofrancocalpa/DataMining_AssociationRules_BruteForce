using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Transaction
    {
        public List<Item> items { get; set; }
        public String date { get; set; }
        public String codCliente { get; set; }
        public String cod { get; set; }

        public Transaction(String codCliente, String cod, String date)
        {
            items = new List<Item>();
            this.date = date;
            this.cod = cod;
            this.codCliente = codCliente;
        }
    }
}
