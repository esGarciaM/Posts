using Entities._Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities._Class
{
    public abstract class EntityBase: IEntidadBase
    {
        public int id { get; set; }
        [JsonIgnore]
        public DateTime? Added { get; set; }
        [JsonIgnore]
        public DateTime? Updated { get; set; }
        public bool Active { get; set; } = true;

    }
}