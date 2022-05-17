using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SistemaContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SNCCH01LABF118\TEW_SQLEXPRESS;Database=Estacionamento;Trusted_Connection=True;");
        }
    }
}
