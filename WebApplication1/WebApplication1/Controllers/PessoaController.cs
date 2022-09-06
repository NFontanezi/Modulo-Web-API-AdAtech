
using APIPessoa.Core.Interface;
using APIPessoa.Core.Model;
using APIPessoa.Filters;
using Microsoft.AspNetCore.Mvc;


namespace APIPessoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")] //só consome json
    [Produces("application/json")] //só produz
    [TypeFilter(typeof(LogResourceFilter))] // aplica em todos os metodos auto-reosuce-action desta controller
    public class PessoaController : ControllerBase
    {
        /* CONSTRUTOR SEM BD
     * 
    public static Pessoa p1 = new Pessoa("Ana Souza", "222.222.222", "1988-09-18");
    public static Pessoa p2 = new Pessoa("Bruno Rosa", "111.111.111", "1980-05-10");
    public static Pessoa p3 = new Pessoa("Paula Torres", "333.333.333", "2003-10-18");


    public static List<Pessoa> pessoas = new List<Pessoa>() { p1, p2, p3 };

    private List<Pessoa> pessoasLog { get; set; }

    private readonly ILogger<PessoaController> _logger;

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
    */



        private readonly IPessoaService _pessoaService;


        public PessoaController(IPessoaService service)
        {

            _pessoaService = service;
           
        }


        [HttpGet("/pessoa/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [TypeFilter(typeof(LogActionFilter))] //sem injeção
        [TypeFilter(typeof(LogAuthorizationFilter))]
        
        public ActionResult<List<Pessoa>> GetPessoa()
        {
            return Ok(_pessoaService.GetPessoas());
        }

        [HttpGet("pessoa/consultar/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Pessoa>> GetPessoaByCpf(string cpf)
        {
            if (_pessoaService.GetPessoabyCpf(cpf) == null)
            {
                return BadRequest();
            }
            return Ok(_pessoaService.GetPessoabyCpf(cpf));
        }

        [HttpPost("pessoa/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(ValidateCpfActionFilter))]

        public ActionResult<Pessoa> PostPessoa(Pessoa p)
        {
            if (!_pessoaService.InsertPessoa(p))
            {
                return BadRequest();
            }
          
            return CreatedAtAction(nameof(PostPessoa), p); 

        }


        [HttpPut("pessoa/alterar/id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(GenerateProductActionFilter))] //confirma se id existe
        public ActionResult<Pessoa> PutPessoa(long id, Pessoa p)
        {
            if (!_pessoaService.UpdatePessoa(id, p))
            {
                return BadRequest();
            }
            else
            {
              

            return CreatedAtAction(nameof(PutPessoa), p);
            }

        }


        [HttpDelete("pessoa/deletar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(GenerateProductActionFilter))] 

        public ActionResult<List<Pessoa>> DeletePessoa(long id)
        {
            if (!_pessoaService.DeletePessoa(id))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); //encontrou ja o ID

            }
            return NoContent();
        }




        /*METODOS CRUD SEM BD
 ******************METODOS CRUD SEM BD

 [HttpGet]
 [ProducesResponseType(StatusCodes.Status200OK)]
 public IActionResult GetPessoa() 
 {
     return Ok(pessoas);
 }



 [HttpGet]
 [ProducesResponseType(StatusCodes.Status200OK)]
 public IActionResult Listar2() // com interface sem tipar o objeto de retorno
 {
     return Ok(pessoas);
 }

 [HttpGet("/pessoas/consultar")]
 [ProducesResponseType(StatusCodes.Status200OK)]
 public ActionResult<List<Pessoa>> Listar3() // sem interface para tipar o objeto de retorno
 {
     return Ok(pessoas);
 }


 [HttpGet("/pessoas/{Cpf}/consulta")]            //  parametro Rota é obrigatorio, senao desconstroi a rota, query pode ser opcional
 [ProducesResponseType(StatusCodes.Status200OK)] // neste caso o parametro é da rota, se nao tivesse escrito da query
 [ProducesResponseType(StatusCodes.Status404NotFound)]
 public IActionResult ListarByCpf(string cpf)
 {
     Pessoa p = pessoasLog.Find(p => p.Cpf == cpf);
     if (p != null)
     {
         return Ok(p);
     }
     return NotFound();

 }


 [HttpPost("/pessoas/cadastrar")]
 [ProducesResponseType(StatusCodes.Status201Created)]
 public IActionResult Adicionar2(string nome, string cpf, string data)
 {
     var p = new Pessoa(nome, cpf, data);
     pessoas.Add(p);
     return CreatedAtAction(nameof(Adicionar2), p);
 }

 [HttpPost("/pessoas/cadastrar3")] // nao tem paramentro somente no body
 [ProducesResponseType(StatusCodes.Status201Created)]
 public IActionResult Adicionar3([FromBody] Pessoa p)
 {
     pessoas.Add(p);
     return CreatedAtAction(nameof(Adicionar2), p); //nameof - devolve a URI que deveria navegar, por ex metedo q ja recebe um id e fica na pag logado
 }

 [HttpPost("/pessoas/cadastrar4")]
 [ProducesResponseType(StatusCodes.Status204NoContent)]
 public IActionResult Adicionar4([FromBody] Pessoa p)
 {
     pessoas.Add(p);
     return NoContent();
 }

 [HttpPost("/pessoas/cadastrar31")]
 [ProducesResponseType(StatusCodes.Status204NoContent)]
 [ProducesResponseType(StatusCodes.Status400BadRequest)]
 public ActionResult<Pessoa> Adicionar31([FromBody] Pessoa p) //interface para retorna 2 obj?
 {
     if (!ModelState.IsValid) // não é necessário, annotations faz as validações automaticamente se nao suprimir
     {
         return BadRequest();
     }
     pessoas.Add(p);
     return CreatedAtAction(nameof(Adicionar2), p);
 }



 [HttpPut("/pessoas/{id}/atualizar")]
 public ActionResult<List<Pessoa>> Alterar(int i, Pessoa novop)
 {
     var p = pessoas.Find(p => p.Id == i);
     p.Nome = novop.Nome;
     p.Cpf = novop.Cpf;
     p.DataNasc = novop.DataNasc;
     return pessoas;
 }

 [HttpPut("/pessoas/{id}/atualizar2")]
 [ProducesResponseType(StatusCodes.Status200OK)]
 [ProducesResponseType(StatusCodes.Status400BadRequest)]
 public IActionResult Alterar2(int i, Pessoa novop)
 {
     var p = pessoas.Find(p => p.Id == i);

     if (p == null)
     {
         return BadRequest("ID não encontrado");
     }
     p.Nome = novop.Nome;
     p.Cpf = novop.Cpf;
     p.DataNasc = novop.DataNasc;
     return Ok(pessoas); //return p
 }


 [HttpDelete("/pessoas/{id}/deletar2")]
 [ProducesResponseType(StatusCodes.Status200OK)]
 [ProducesResponseType(StatusCodes.Status400BadRequest)]
 public ActionResult<List<Pessoa>> Deletar2(int i)

 {
     Pessoa p = pessoas.First(p => p.Id.Equals(i));
     if (p == null)
     {
         return BadRequest("ID não encontrado");
     }

     pessoas.Remove(p);
     return Ok(pessoas);
 }
 [HttpDelete("/pessoas/{id}/deletar3")]
 [ProducesResponseType(StatusCodes.Status200OK)]
 [ProducesResponseType(StatusCodes.Status400BadRequest)]
 public IActionResult Deletar3(int i)
 {
     Pessoa p = pessoas.First(p => p.Id.Equals(i));
     if (p == null)
     {
         return BadRequest("ID não encontrado");
     }

     pessoas.Remove(p);
     return Ok();
 }
 */


    }
}


