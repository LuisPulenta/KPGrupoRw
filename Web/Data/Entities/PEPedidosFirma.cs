using System.ComponentModel.DataAnnotations;
using System;

namespace Web.Data.Entities
{
    public class PEPedidosFirma
    {
        [Key]
        public int IDFIRMA { get; set; }
        public int IDPEPEDIDO { get; set; }
        public int NROUNIDADNEGOCIO { get; set; }
        public int IDUSUARIO { get; set; }
        public DateTime? FECHA { get; set; }
        public int HS { get; set; }
        public string MEDIOFIRMA { get; set; }
    }
}
