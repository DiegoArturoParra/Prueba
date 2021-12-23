using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba.Models
{
    [Table("gato")]
    public class Gato
    {
        [Key]
        public string id { get; set; }
        [Column("breeds", TypeName = "json")]
        public object[] breeds { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

}
