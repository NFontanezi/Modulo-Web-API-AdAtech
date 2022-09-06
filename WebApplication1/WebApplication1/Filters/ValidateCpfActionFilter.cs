using APIPessoa.Core.Interface;
using APIPessoa.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIPessoa.Filters
{
    public class ValidateCpfActionFilter : ActionFilterAttribute
    {

        public IPessoaService _pessoaService;

        public ValidateCpfActionFilter(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

    
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            string cpfPessoa = (string)context.ActionArguments["cpf"];
            

            if (_pessoaService.GetPessoabyCpf(cpfPessoa) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);

            }


            else if (_pessoaService.GetPessoabyCpf(cpfPessoa).Cpf==cpfPessoa)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }



        }

    }
}

