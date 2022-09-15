using APIPessoa.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIPessoa.Controllers
{
    public class TokenController : Controller
    {

        private readonly IPessoaService _pessoaService;
        private readonly ITokenService _tokenService;

        public TokenController(IPessoaService service, ITokenService tokenService)
        {

            _pessoaService = service;
            _tokenService = tokenService;


        }
        [HttpGet]
        public IActionResult CreateToken(string cpf)
        {
            var pessoa = _pessoaService.GetPessoabyCpf(cpf);
            if(pessoa == null)
            {
                return BadRequest();
            }

            return Ok(_tokenService.GenerateTokenEvent(pessoa.Nome, pessoa.Permissao));



        }
    }
}
