using System.ComponentModel.DataAnnotations;

namespace Common.Models.Request
{
    public class Vehiculo3Request
    {
        [Required]
        public int NroInterno { get; set; }

        public int? KMHSACTUAL { get; set; }
    }
}