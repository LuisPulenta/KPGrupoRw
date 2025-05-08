using Microsoft.EntityFrameworkCore;
using Web.Data.Entities;

namespace Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<ObrasDocumento> ObrasDocumentos { get; set; }
        public DbSet<WebSesio> WebSesion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Company>().HasIndex(x => x.Name).IsUnique();
            //modelBuilder.Entity<Survey>().HasIndex("Name", "CompanyId").IsUnique();


            modelBuilder.Entity<Obra>()
                .HasKey(o => o.NroObra); //el nombre de la PK de la tabla PRIMARIA

            modelBuilder.Entity<ObrasDocumento>()
                .HasKey(od => od.NROREGISTRO); // el nombre de la PK de la tabla VARIOS O RELACIONADA

            modelBuilder.Entity<Obra>()
                .HasMany(o => o.ObrasDocumentos)
                .WithOne() // Sin propiedad de navegación inversa
                .HasForeignKey(od => od.NROOBRA)
                .OnDelete(DeleteBehavior.Cascade); // o lo que n
        }
    }
}