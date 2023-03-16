using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.Interfaces;
using WebApi.Application.Requests;
using WebApi.Domain;

namespace WebApi.Application.UseCases
{
    public class CriarPessoaUseCase : ICriarPessoaUseCase
    {
        public CriarPessoaUseCase()
        {
            
        }
        public ApiResponse Execute(CriarPessoaRequest request)
        {
            try
            {
                var pessoa = new Pessoa(
                    request.Nome,
                    request.Cidade,
                    request.NomeMae
                    );
                
                if(!pessoa.IsValid)
                {
                    return new ApiResponse
                    {
                        StatusCode = System.Net.HttpStatusCode.Conflict,
                        Messages = pessoa.Messages
                    };
                }

                 // if (ja existe pessoa ... )...
                 // salva pessoa
                 return new ApiResponse
                 {
                    StatusCode = System.Net.HttpStatusCode.Created,
                    Data = pessoa
                 };
            }
            catch (System.Exception ex)
            {
                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Messages = new List<string> { ex.Message }
                };
            }
        }
    }
}