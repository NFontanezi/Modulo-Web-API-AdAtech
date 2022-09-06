using System.ComponentModel.DataAnnotations;

namespace APIPessoa.Core.Model

{
    public class Pessoa
    {
        //public static long id_value = 1;
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo {0} Obrigatório", AllowEmptyStrings = false)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(11, ErrorMessage = "Campo {0} deve conter 11 caracteres")]
        [MinLength(11, ErrorMessage = "Campo {0} deve conter 11 caracteres")]
        [StringLength(11, MinimumLength= 11)]

        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataNascimento { get; set; } // o que é ?, se usar nao funciona

        public int Idade { get { return GetAge(); } }

        public static List<Pessoa> pessoas = new List<Pessoa>();

  

        public static void AddPessoa(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }

        public int GetAge()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
            {
                idade--;
            }

            return idade;
        }


    }
}
