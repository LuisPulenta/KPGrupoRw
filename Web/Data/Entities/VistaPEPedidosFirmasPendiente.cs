using System.ComponentModel.DataAnnotations;
using System;

namespace Web.Data.Entities
{
    public class VistaPEPedidosFirmasPendiente
    {
        [Key]
        public int NroPedido { get; set; }
        public string Estado { get; set; }
        public DateTime FECHA { get; set; }        
        public string NroPedidoObra { get; set; }
        public int TotalItemAprobados { get; set; }
        public decimal ImporteAprobados { get; set; }
        public int IDUSUARIO { get; set; }
        public int IDFIRMA { get; set; }
    }
}
