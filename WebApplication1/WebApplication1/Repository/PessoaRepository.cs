using Dapper;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Repository
   
{
    public class PessoaRepository
    {
        private readonly IConfiguration _configuration;

        public PessoaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //METODOS DE ACESSO

        public List<Pessoa> GetPessoas()
        {
            var query = "SELECT * FROM clientes";

            var connectionString = _configuration.GetConnectionString("DefaultConnection"); //link appsetting
            
            using var conn =new SqlConnection(connectionString); //cria connexao db
           
            return conn.Query<Pessoa>(query).ToList();
        }

        public Pessoa GetPessoabyCpf(string cpf)
        {
            var query = "SELECT * FROM clientes WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var conn = new SqlConnection(connectionString); 

            return conn.QueryFirstOrDefault<Pessoa>(query, parameters);

        }

        public bool InsertPessoa(Pessoa pessoa) //post
        {
            var query = "INSERT INTO clientes VALUES ( @cpf, @nome, @datanascimento, @idade)";

            var parameters = new DynamicParameters(pessoa);


            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;

        }

        public bool UpdatePessoa(long id, Pessoa pessoa) //put
        {
            var query = @"UPDATE clientes set nome = @nome, cpf = @cpf, datanascimento = @datanascimento, idade = @idade
                        where id = @id";

            pessoa.Id = id;
            var parameters = new DynamicParameters(pessoa);
           /* parameters.Add("id", pessoa.Id);
            parameters.Add("nome", pessoa.Nome);
            parameters.Add("cpf", pessoa.Cpf);
            parameters.Add("datanascimento", pessoa.DataNascimento);
            parameters.Add("idade", pessoa.Idade);*/

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeletePessoa(long id)
        {
            var query = "DELETE FROM clientes WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

    }

    
}
