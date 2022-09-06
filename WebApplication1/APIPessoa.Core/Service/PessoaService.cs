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

        public bool InsertPessoa(Pessoa pessoa)
        {
            return _pessoaRepository.InsertPessoa(pessoa);
        }

        public bool UpdatePessoa(long id, Pessoa pessoa)
        {
            return _pessoaRepository.UpdatePessoa(id, pessoa);
        }

        public bool DeletePessoa(long id)
        {
            return _pessoaRepository.DeletePessoa(id);
        }
    }
}
