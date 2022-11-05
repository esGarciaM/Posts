using Entities._Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities._Entities
{
    public class Post:EntityBase
    {
        public int userid { get; set; }
        public string title { get; set; }
        public string body { get; set; }

    }
}
