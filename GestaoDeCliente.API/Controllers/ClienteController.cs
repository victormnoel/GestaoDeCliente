using GestaoDeCliente.Application.Commands.Criar;
using GestaoDeCliente.Application.Modelos.ViewModels;
using GestaoDeCliente.Application.Queries.Buscar;
using GestaoDeCliente.Core.Excecoes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeCliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        #region Propriedades/Constantes

        private readonly IMediator _mediator;
        private const string MENSAGEM_DE_ERRO = "Ocorreu um erro inesperado durante o processamento!";

        #endregion

        #region Construtor
        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Endpoints


        [HttpGet("Buscar/{id}")]
        public async Task<IActionResult> BuscarCliente(int id)
        {
            try
            {
                ClienteViewModel? clienteEncontrado = await _mediator.Send(new BuscarClientePorIdQuery() { ClienteId = id });
                return clienteEncontrado is null
                    ? NotFound("Não foi possível encontrar o cliente referenciado!")
                    : Ok(clienteEncontrado);
            }
            catch (Exception excecao)
            {
                return BadRequest(MENSAGEM_DE_ERRO);
            }
           
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarCliente(CriarClienteCommand dadosCadastrais)
        {
            try
            {
                ResultadoDaOperacaoViewModel retornoDoCadastro = await _mediator.Send(dadosCadastrais);
                return retornoDoCadastro.Sucesso 
                    ? Ok(retornoDoCadastro.Mensagem) 
                    : BadRequest(retornoDoCadastro.Mensagem);
            }
            catch (NomeFantasiaInvalidoException excecao)
            {
                return BadRequest(excecao.Message);
            }
            catch (CnpjInvalidoException excecao)
            {
                return BadRequest(excecao.Message);
            }
            catch (Exception excecao)
            {
                return BadRequest(MENSAGEM_DE_ERRO);
            }
        }

        #endregion

    }
}
