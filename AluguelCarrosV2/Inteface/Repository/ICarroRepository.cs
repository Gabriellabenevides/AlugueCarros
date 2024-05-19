using AluguelCarrosV2.Model;

namespace AluguelCarrosV2.Inteface.Repository
{
    public interface ICarroRepository
    {
        Task<Carro> CreateCarro(Carro Carro);
        Task<int> UpDateCarro(Carro Carro);
        Task<bool> DeletarCarro(int CarroId);
        Task<List<Carro>> ListarCarro();
        Task<string> AlugarCarro(string nomeCarro, string nomeCliente);
    }
}
