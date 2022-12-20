using Entities._Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities._Entities
{
    public class Order : EntityBase
    {
        public int idCliente { get; set; }
        public string NumOrder { get; set; }
        public string OrderDesc { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ICollection<OrderDetails> Details { get; set; }
}
}
