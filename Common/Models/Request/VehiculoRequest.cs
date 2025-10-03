using System.ComponentModel.DataAnnotations;

namespace Common.Models.Request
{
    public class VehiculoRequest
    {
        [Required]
        public string NUMCHA { get; set; }
    }
}