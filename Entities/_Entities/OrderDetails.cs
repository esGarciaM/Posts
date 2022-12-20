using Entities._Class;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities._Entities
{
    public class OrderDetails : EntityBase
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public string description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal price { get; set; }
        [Column(TypeName = "decimal(5,0)")]
        public decimal quantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal discount { get; set; }
        public virtual Order Order { get; set;}
}
}
