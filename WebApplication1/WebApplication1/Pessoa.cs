namespace WebApplication1
{
    public class Pessoa
    {
        public static int id_value = 1;
        public int Id { get; private set; }
        public string Nome { get; set; }
       
        public string Cpf { get; set; }

        public DateTime DataNasc { get; set; }

        public int Idade { get; private set; }

        public static List<Pessoa> pessoas = new List<Pessoa>();

        public Pessoa(string nome, string cpf, string data)
        {
            Id = id_value++;
            Nome = nome;
            Cpf = cpf;
            DataNasc = Convert.ToDateTime(data);//.CultureInfo.InvariantCulture;
            Idade = DateTime.Now.Year - DataNasc.Year;
        }

        public static void AddPessoa(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }

    }
}
