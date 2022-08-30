
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        public static Pessoa p1 = new Pessoa("Ana Souza", "222.222.222", "1988-09-18");
        public static Pessoa p2 = new Pessoa("Bruno Rosa", "111.111.111", "1980-05-10");
        public static Pessoa p3 = new Pessoa("Paula Torres", "333.333.333", "2003-10-18");


        public static List<Pessoa> pessoas = new List<Pessoa>() { p1, p2, p3 };

        private readonly ILogger<PessoaController> _logger;
        private List<Pessoa> pessoasLog { get; set; }

        public PessoaController(ILogger<PessoaController> logger)
        {
            _logger = logger;
            pessoasLog = pessoas.Select(p => new Pessoa
            {
                Nome = p.Nome,
                Cpf = p.Cpf,
                DataNasc = p.DataNasc,

            }).ToList();


        }

        [HttpGet]
        public List<Pessoa> Listar()
        {
            return pessoas;
        }

        [HttpPost]
        public void Adicionar(string nome, string cpf, string data)
        {
            pessoas.Add(new Pessoa (nome, cpf, data));

        }

        [HttpPut]
        public List<Pessoa> Alterar(int i, Pessoa novop)
        {   var p = pessoas.Find(p => p.Id == i);
            p.Nome = novop.Nome;
            p.Cpf = novop.Cpf;
            p.DataNasc = novop.DataNasc;
            return pessoas;
        }

        [HttpDelete]
        public List<Pessoa> Deletar(int i)
        {
            Pessoa p  = pessoas.First(p => p.Id.Equals(i));
            pessoas.Remove(p);

            return pessoas;
        }



    }
}



