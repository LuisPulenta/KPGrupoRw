using System.ComponentModel.DataAnnotations;

namespace Common.Models.Request
{
    public class Vehiculo2Request
    {
        [Required]
        public int Id { get; set; }

        public int? KMHSACTUAL { get; set; }
    }
}