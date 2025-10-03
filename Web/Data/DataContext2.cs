using Microsoft.EntityFrameworkCore;
using Web.Data.Entities;

namespace Web.Data
{
    public class DataContext2 : DbContext
    {
        public DataContext2(DbContextOptions<DataContext2> options) : base(options)
        {
        }

        public DbSet<Causante> VistaCausantesApp { get; set; }
        public DbSet<UsuarioInv> Usuarios { get; set; }
        public DbSet<PEPedido> PEPedidos { get; set; }
        public DbSet<PEPedidosFirma> PEPedidosFirmas { get; set; }
        public DbSet<VistaPEPedidosFirmasPendiente> VistaPEPedidosFirmasPendientes { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<VehiculosKilometraje> VehiculosKilometrajes { get; set; }
        public DbSet<VehiculosProgramaPrev> VehiculosProgramasPrev { get; set; }
        public DbSet<VFlotaApp> VFlotaApps { get; set; }
        public DbSet<VFlotaPreventivo> VFlotaPreventivos { get; set; }
        public DbSet<VehiculosSiniestro> VehiculosSiniestros { get; set; }
        public DbSet<VehiculosSiniestrosFoto> VehiculosSiniestrosFotos { get; set; }
        public DbSet<VehiculosCheckList> VehiculosCheckLists { get; set; }
        public DbSet<VistaFlotasChecklistAPP> VistaFlotasChecklistAPP { get; set; }
        public DbSet<VehiculosCheckListsFoto> VehiculosCheckListsFotos { get; set; }
        public DbSet<VehiculosPartesTurno> VehiculosPartesTurnos { get; set; }
    }
}