using Common.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Data.Entities
{
    public class VehiculosCheckListsFoto
    {
        [Key]
        public int IDREGISTRO { get; set; }

        public int IDCHECKLISTCAB { get; set; }
        public string DESCRIPCION { get; set; }
        public string LINKFOTO { get; set; }

        public string ImageFullPath => string.IsNullOrEmpty(LINKFOTO)
        ? $"{Urls.BaseUrl}/images/CheckList/noimage.png"
        : $"{Urls.BaseUrl}{LINKFOTO.Substring(1)}";
    }
}