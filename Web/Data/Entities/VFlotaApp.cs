using System.ComponentModel.DataAnnotations;

namespace Web.Data.Entities
{
    public class VFlotaApp
    {
        [Key]
        public string NUMCHA { get; set; }

        public string GrupoV { get; set; }
        public string CausanteV { get; set; }
    }
}