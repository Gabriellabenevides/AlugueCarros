using AluguelCarrosV2.Inteface.Repository;
using AluguelCarrosV2.Inteface.Service;
using AluguelCarrosV2.Model;

namespace AluguelCarrosV2.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<bool> CreateCliente(Cliente cliente)
        {
            var result = await _clienteRepository.CreateCliente(cliente);
            return result != null;
        }

        public async Task<bool> DeletarCliente(int ClienteId)
        {
            await _clienteRepository.DeletarCliente(ClienteId);
            return true;
        }

        public async Task<List<Cliente>> ListarCliente()
        {
            var cliente = await _clienteRepository.ListarCliente();
            return cliente;
        }

        public async Task<int> UpDateCliente(Cliente cliente)
        {
            return await _clienteRepository.UpDateCliente(cliente);
        }
    }
}
