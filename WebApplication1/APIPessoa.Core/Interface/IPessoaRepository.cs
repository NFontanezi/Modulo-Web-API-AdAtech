

using APIPessoa.Core.Model;

namespace APIPessoa.Core.Interface
{
    public interface IPessoaRepository
    {
      List<Pessoa> GetPessoas();

      Pessoa GetPessoabyCpf(string cpf);


      bool InsertPessoa(Pessoa pessoa);

         bool UpdatePessoa(long id, Pessoa pessoa);

         bool DeletePessoa(long id);

    }
}
