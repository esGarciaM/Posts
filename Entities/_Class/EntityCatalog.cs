using System.ComponentModel.DataAnnotations;

namespace Entities._Class
{
    public abstract class EntityCatalog: EntityBase
    {
        [Required]
        public string clave { get; set; }
        [Required]
        public string name { get; set; }


    }
}