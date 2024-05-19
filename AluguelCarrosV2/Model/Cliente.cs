namespace AluguelCarrosV2.Model
{
    public class Cliente
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set;}
        public int? CarroId { get; set; }
    }
}
