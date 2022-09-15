using APIPessoa.Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace APIPessoa.Core.Service
{
    public class TokenService : ITokenService
    {
         
        public IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateTokenEvent(string nome, string permissao)
        {
            //Chave secreta para validação do Token
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("secretKey"));

            //Corpo do JWT
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "APIPessoa.com", //Adicionando informação do issuer (quem gera o token)
                Audience = "APIEvent.com", //Adicionando informação do audience (quem recebe/utiliza o token)
                Expires = DateTime.UtcNow.AddMinutes(15), //Quanto tempo vai expirar o token
                Subject = new ClaimsIdentity(new Claim[] //Claims do usuario
                {
                    new Claim(ClaimTypes.Name, nome), //Claim de nome padrão
                    new Claim(ClaimTypes.Role, permissao), //Claim de role padrão
                    new Claim("teste", "123") //Claim personalizada
                }),
                SigningCredentials = new SigningCredentials( //Adicionando tipo de credencial
                    new SymmetricSecurityKey(key),           //Adicionando chave de validação do token
                    SecurityAlgorithms.HmacSha256Signature)  //Adicionando algoritmo de segurança do token
            };

            // Classe para manipular e gerar o token
            var tokenHandler = new JwtSecurityTokenHandler();

            //Criando a estrutura do token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Serializa o token, transforma o token criado, criptografa
            return tokenHandler.WriteToken(token);
        }
    }
}

