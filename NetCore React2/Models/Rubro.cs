using System.ComponentModel.DataAnnotations;

namespace NetCore_React2.Models
{
    public class Rubro
    {
        [Key]
        public int RubroID { get; set; }
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
    }
}
