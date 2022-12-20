using Entities._Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities._Entities
{
    public class Product:EntityCatalog
    {
        public int providerid;
        public virtual Provider provider { get; set; }
    }
}
