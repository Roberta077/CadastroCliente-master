using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CadastroClientes.Infrastructure.Context
{
    public class CadastroClientesContextFactory : IDesignTimeDbContextFactory<CadastroClientesContext>
    {
        public CadastroClientesContext CreateDbContext(string[] args = null)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CadastroClientesContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new CadastroClientesContext(optionsBuilder.Options);
        }
    }
}
