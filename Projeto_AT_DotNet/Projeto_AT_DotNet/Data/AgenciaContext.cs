using Microsoft.EntityFrameworkCore;
using Projeto_AT_DotNet.Models; 

namespace Projeto_AT_DotNet.Data
{
    public class AgenciaContext : DbContext
    {
        public AgenciaContext(DbContextOptions<AgenciaContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<PacoteTuristico> PacotesTuristico { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<DestinoPacote> DestinoPacotes { get; set; }
        public object Reserva { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DestinoPacote>()
                .HasKey(dp => new { dp.PacoteTuristicoId, dp.DestinoId });

            modelBuilder.Entity<DestinoPacote>()
                .HasOne(dp => dp.PacoteTuristico)
                .WithMany(p => p.DestinosIncluidos)
                .HasForeignKey(dp => dp.PacoteTuristicoId);

            modelBuilder.Entity<DestinoPacote>()
                .HasOne(dp => dp.Destino)
                .WithMany(d => d.PacotesAssociados)
                .HasForeignKey(dp => dp.DestinoId);
        }
    }
}