using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class EstacionamentoContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Acesso> Acesso { get; set; }
        public DbSet<Carteira> Carteira { get; set; }
        public DbSet<LocalEst> LocalEst { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SERVIDOR\SQLEXPRESS01;Database=Estacionamento;Trusted_Connection=True;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<LocalEst>(
                    eb =>
                    {
                        eb.HasKey(v => v.IdLocal);
                    });

            modelBuilder
                .Entity<Carteira>(
                eb =>
                {
                    eb.HasNoKey();
                });
            
            modelBuilder
                .Entity<Acesso>(
                    eb => {
                        eb.HasKey(v => v.idAcesso);
                    });
            
            modelBuilder
                .Entity<Veiculo>(
                    eb =>
                    {
                        eb.HasKey(v=>v.idVeiculo);
                        //eb.ToView("View_BlogPostCounts");
                       //eb.Property(v => v.Modelo).HasColumnName("Name");
                    });
            
            modelBuilder.Entity<Usuario>(eb =>
            {
                eb.HasNoKey();
            });
        }
    }
}
