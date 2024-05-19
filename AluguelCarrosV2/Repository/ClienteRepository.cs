using AluguelCarrosV2.Data;
using AluguelCarrosV2.Inteface.Repository;
using AluguelCarrosV2.Model;
using Microsoft.EntityFrameworkCore;

namespace AluguelCarrosV2.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SqlContext _context;

        public ClienteRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CreateCliente(Cliente cliente)
        {
            var ret = await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            ret.State = EntityState.Detached;
            return ret.Entity;
        }

        public async Task<bool> DeletarCliente(int clienteId)
        {
            var removido = await _context.Clientes.FindAsync(clienteId);
            _context.Clientes.Remove(removido);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cliente>> ListarCliente()
        {
            return await _context.Clientes.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<int> UpDateCliente(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
