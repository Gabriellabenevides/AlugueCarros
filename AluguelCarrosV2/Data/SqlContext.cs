using AluguelCarrosV2.Model;
using Microsoft.EntityFrameworkCore;

namespace AluguelCarrosV2.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> opts) : base(opts)
        {
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
