﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class EstacionamentoContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Acesso> Acesso { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SNCCH01LABF118\TEW_SQLEXPRESS;Database=Estacionamento;Trusted_Connection=True;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
