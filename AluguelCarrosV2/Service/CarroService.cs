using AluguelCarrosV2.Inteface.Repository;
using AluguelCarrosV2.Inteface.Service;
using AluguelCarrosV2.Model;

namespace AluguelCarrosV2.Service
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }
        public async Task<string> AlugarCarro(string nomeCarro, string nomeCliente)
        {
            var result = await _carroRepository.AlugarCarro(nomeCarro, nomeCliente);
            return result;
        }

        public async Task<bool> CreateCarro(Carro carro)
        {
            var result = await _carroRepository.CreateCarro(carro);
            return result != null;
        }

        public async Task<bool> DeletarCarro(int carroId)
        {
            await _carroRepository.DeletarCarro(carroId);
            return true;
        }

        public async Task<List<Carro>> ListarCarro()
        {
            var carros = await _carroRepository.ListarCarro();
            return carros;
        }

        public async Task<int> UpDateCarro(Carro carro)
        {
            return await _carroRepository.UpDateCarro(carro);
        }
    }
}
