using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.Requests;

namespace WebApi.Application.Interfaces
{
    public interface ICriarPessoaUseCase
    {
        ApiResponse Execute(CriarPessoaRequest request);
    }
}