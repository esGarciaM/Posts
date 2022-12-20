using Entities._Class;
using Entities._Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities._Entities
{
    public class Client: EntityCatalog
    {
        //public int vacante { get; set; }
        [Required]
        public string? razonsocial { get; set; }
        public string rfc { get; set; }
    }
}
