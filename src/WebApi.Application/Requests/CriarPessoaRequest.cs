using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.Requests
{
    public class CriarPessoaRequest
    {
        public CriarPessoaRequest()
        {
            
        }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string? NomeMae { get; set; }
    }
}