using Microsoft.EntityFrameworkCore;
using CadastroClientes.Domain.Entities;

namespace CadastroClientes.Infrastructure.Data
{
    public class CadastroClientesDbContext : DbContext
    {
        public CadastroClientesDbContext(DbContextOptions<CadastroClientesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Enderecos)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.TipoEndereco)
                .HasConversion<string>();
        }
    }
}
