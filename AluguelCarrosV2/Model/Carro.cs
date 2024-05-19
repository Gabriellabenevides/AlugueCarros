namespace AluguelCarrosV2.Model
{
    public class Carro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public bool Disponivel { get; set; }
    }
}
