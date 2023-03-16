using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Requests;
using WebApi.Application.Interfaces;
using WebApi.Presentation.Filters;

namespace WebApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PessoaController : Controller
    {
        public PessoaController(ICriarPessoaUseCase criarPessoaUseCase)
        {
            this._criarPessoaUseCase = criarPessoaUseCase;
        }
        private readonly ICriarPessoaUseCase _criarPessoaUseCase;

        [HttpPost]
        [AcceptProfiles("admin", "professor")]
        public IActionResult Post([FromBody]CriarPessoaRequest request)
        {
            var response = _criarPessoaUseCase.Execute(request);

            if(response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return StatusCode((int)response.StatusCode, response.Data);
            }

            return StatusCode((int)response.StatusCode, response.Messages);
        }
    }
}