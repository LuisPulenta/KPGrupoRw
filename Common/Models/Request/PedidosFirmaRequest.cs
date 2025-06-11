using System.ComponentModel.DataAnnotations;

namespace Common.Models.Request
{
    public class PedidosFirmaRequest
    {
        [Required]
        public int IDFIRMA { get; set; }
    }
}