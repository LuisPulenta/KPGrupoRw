using Microsoft.EntityFrameworkCore;
using Web.Data.Entities;

namespace Web.Data
{
    public class DataContext2 : DbContext
    {
        public DataContext2(DbContextOptions<DataContext2> options) : base(options)
        {
        }
        public DbSet<UsuarioInv> Usuarios { get; set; }
        public DbSet<PEPedido> VistaPEPedidosFirmasPendientes { get; set; }
        public DbSet<PEPedidosFirma> PEPedidosFirmas { get; set; }
    }
}