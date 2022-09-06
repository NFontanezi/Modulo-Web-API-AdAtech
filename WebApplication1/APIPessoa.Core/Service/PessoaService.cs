using APIPessoa.Core.Interface;
using APIPessoa.Core.Model;

namespace APIPessoa.Core.Service
{
    public class PessoaService : IPessoaService

    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

       public List<Pessoa> GetPessoas()
        {
            return _pessoaRepository.GetPessoas();
        }

        public Pessoa GetPessoabyCpf(string cpf)
        {

            return _pessoaRepository.GetPessoabyCpf(cpf);
         }

        public Pessoa GetPessoabyId(long id)
        {

            return _pessoaRepository.GetPessoabyId(id);
        }

        public bool InsertPessoa(Pessoa pessoa)
        {
            return _pessoaRepository.InsertPessoa(pessoa);
        }

        public bool UpdatePessoa(long id, Pessoa pessoa)
        {
            /* try
             {

                 pessoa = null;
                 pessoa.Id = id;
             }

             catch (NullReferenceException ex) //retorna bool
             {
                 var tipoExcecao = ex.GetType().Name;
                 var msg = ex.Message;
                 var caminho = ex.InnerException.StackTrace;
                 //faz log
                 Console.WriteLine($"Tipo exceção {tipoExcecao}, mensagem {msg}, stack trace {caminho}");
                 throw;

             }
             catch (Exception ex) //retorna bool
             {
                 var tipoExcecao = ex.GetType().Name;
                 var msg = ex.Message;
                 var caminho = ex.InnerException.StackTrace;
                 //faz log
                 Console.WriteLine($"Tipo exceção {tipoExcecao}, mensagem {msg}, stack trace {caminho}");
                 return false;

             }*/
            pessoa.Id = id;
            return _pessoaRepository.UpdatePessoa(id, pessoa);
        }

        public bool DeletePessoa(long id)
        {
            return _pessoaRepository.DeletePessoa(id);
        }
    }
}
