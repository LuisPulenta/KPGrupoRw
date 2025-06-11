using System.ComponentModel.DataAnnotations;

namespace Common.Models.Request
{
    public class PedidoRequest
    {
        [Required]
        public int NroPedido { get; set; }
    }
}