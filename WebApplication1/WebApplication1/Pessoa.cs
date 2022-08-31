using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Pessoa
    {
        public static int id_value = 1;
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Campo {0} Obrigatório", AllowEmptyStrings = false)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(11, ErrorMessage = "Campo {0} deve conter 11 caracteres")]
        [MinLength(11, ErrorMessage = "Campo {0} deve conter 11 caracteres")]
        [StringLength(11, MinimumLength= 11)]

        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]

        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataNasc { get; set; } // o que é ?, se usar nao funciona

        public int Idade { get; private set; }

        public static List<Pessoa> pessoas = new List<Pessoa>();

        public Pessoa()
        {

        }

        public Pessoa(string nome, string cpf, string data)
        {
            Id = id_value++;
            Nome = nome;
            Cpf = cpf;
            DataNasc = Convert.ToDateTime(data);//.CultureInfo.InvariantCulture;
            Idade = GetAge();
        }
        //teste

        public static void AddPessoa(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }

        public int GetAge()
        {
            int idade = DateTime.Now.Year - DataNasc.Year;
            if (DateTime.Now.DayOfYear < DataNasc.DayOfYear)
            {
                idade--;
            }

            return idade;
        }


    }
}
