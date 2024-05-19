using AluguelCarrosV2.Data;
using AluguelCarrosV2.Inteface.Repository;
using AluguelCarrosV2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AluguelCarrosV2.Repository
{
    public class CarroRepository : ICarroRepository

    {
        private readonly SqlContext _context;

        public CarroRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<string> AlugarCarro(string nomeCarro, string nomeCliente)
        {
            Carro carro = await _context.Carros.Where(x => x.Nome == nomeCarro).FirstOrDefaultAsync();
            Cliente cliente = await _context.Clientes.Where(x => x.Nome == nomeCliente).FirstOrDefaultAsync();

            if (carro == null || cliente == null)
            {
                return "Não existe esse carro ou cliente no banco de dados!";
            }
            else if (carro.Disponivel == false)
            {
                return $"{nomeCarro} já foi alugado por outra pessoa.";
            }
            else if (cliente.CarroId > 0)
            {
                return $"{cliente.Nome} já alugou o carro.";
            }
            else
            {
                cliente.CarroId = carro.Id;
                carro.Disponivel = false;
                await _context.SaveChangesAsync();
                return "Carro alugado com sucesso!";
            }
        }

        public async Task<Carro> CreateCarro(Carro carro)
        {
            var ret = await _context.Carros.AddAsync(carro);
            await _context.SaveChangesAsync();
            ret.State = EntityState.Detached;
            return ret.Entity;

        }

        public async Task<bool> DeletarCarro(int carroId)
        {
            var removido = await _context.Carros.FindAsync(carroId);
            _context.Carros.Remove(removido);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Carro>> ListarCarro()
        {
            return await _context.Carros.OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<int> UpDateCarro(Carro carro)
        {
            _context.Entry(carro).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
