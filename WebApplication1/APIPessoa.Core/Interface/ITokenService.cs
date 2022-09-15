using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPessoa.Core.Interface
{
        public interface ITokenService
        {
            string GenerateTokenEvent(string nome, string permissao);
        }
    
}
