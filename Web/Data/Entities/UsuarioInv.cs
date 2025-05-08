using System.ComponentModel.DataAnnotations;

namespace Web.Data.Entities
{
    public class UsuarioInv
    {
        [Key]
        public int IdUsuario { get; set; }
        public bool Estado { get; set; }
        public bool Compras { get; set; }    
    }
}
