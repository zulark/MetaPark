using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class EstacionamentoContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SERVIDOR\SQLEXPRESS01;Database=Estacionamento;Trusted_Connection=True;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Veiculo>(
                    eb =>
                    {
                        eb.HasNoKey();
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
