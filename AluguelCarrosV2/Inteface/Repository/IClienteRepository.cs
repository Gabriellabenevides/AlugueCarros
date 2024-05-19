using AluguelCarrosV2.Model;

namespace AluguelCarrosV2.Inteface.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> CreateCliente(Cliente Cliente);
        Task<int> UpDateCliente(Cliente Cliente);
        Task<bool> DeletarCliente(int ClienteId);
        Task<List<Cliente>> ListarCliente();
    }
}
