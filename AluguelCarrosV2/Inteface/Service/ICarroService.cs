using AluguelCarrosV2.Model;

namespace AluguelCarrosV2.Inteface.Service
{
    public interface ICarroService
    {
        Task<bool> CreateCarro(Carro Carro);
        Task<int> UpDateCarro(Carro Carro);
        Task<bool> DeletarCarro(int carroId);
        Task<List<Carro>> ListarCarro();
        Task<string> AlugarCarro(string nomeCarro, string nomeCliente);
    }
}
