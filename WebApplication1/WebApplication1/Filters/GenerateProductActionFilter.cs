using APIPessoa.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIPessoa.Filters
{
    public class GenerateProductActionFilter : ActionFilterAttribute
        //VALIDAÇÃO OCORRE ANTES DE CHEGAR NO METODO

    // precisa registrar o filtro como serviço no program devido a injeçao de dep.
    {
        public IPessoaService _pessoaService; //acessar repo via service via injeção

        public GenerateProductActionFilter(IPessoaService pessoaService)    
        {
            _pessoaService = pessoaService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //context.argumnet  acessa as variaveis via dic e retorna obj, fazer cast
            //o paramentro em questao tem q estar no metodo q receber o filtro
            long idPessoa = (long)context.ActionArguments["id"];

           if(_pessoaService.GetPessoabyId(idPessoa) == null) 
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }
        }

      /* public override void OnActionExecuting(ActionExecutingContext context)
        {
        
            string cpfPessoa = (string)context.ActionArguments["cpf"];

            if (_pessoaService.GetPessoabyCpf(cpfPessoa) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
                //tenho BadRequest no metodo, pq diferentes retornos???
            }
        } */
    }
}
