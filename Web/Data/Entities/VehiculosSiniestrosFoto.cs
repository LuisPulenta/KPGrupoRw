using Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace Web.Data.Entities
{
    public class VehiculosSiniestrosFoto
    {
        [Key]
        public int IDFOTOSINIESTRO { get; set; }

        public int NROSINIESTROCAB { get; set; }
        public string OBSERVACION { get; set; }
        public string LINKFOTO { get; set; }
        public string CORRESPONDEA { get; set; }

        public string ImageFullPath => string.IsNullOrEmpty(LINKFOTO)
        ? $"{Urls.BaseUrl}/images/Siniestros/noimage.png"
        : $"{Urls.BaseUrl}/RowingAppApi{LINKFOTO.Substring(1)}";
    }
}