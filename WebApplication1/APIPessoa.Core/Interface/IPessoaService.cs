
using APIPessoa.Core.Model;

namespace APIPessoa.Core.Interface
{
    public interface IPessoaService
    {
        List<Pessoa> GetPessoas();

        Pessoa GetPessoabyCpf(string cpf);

        Pessoa GetPessoabyId(long id);


        bool InsertPessoa(Pessoa pessoa);

        bool UpdatePessoa(long id, Pessoa pessoa);

        bool DeletePessoa(long id);

    }
}
