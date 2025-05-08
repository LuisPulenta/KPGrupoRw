using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Data.Entities
{
    public class PEPedido
    {
        [Key]
        public int NroPedido { get; set; }
        public DateTime FECHA { get; set; }
        public string Estado { get; set; }
        public string NroPedidoObra { get; set; }
        public int TotalItemAprobados { get; set; }
        public decimal ImporteAprobados { get; set; }

    }
}
