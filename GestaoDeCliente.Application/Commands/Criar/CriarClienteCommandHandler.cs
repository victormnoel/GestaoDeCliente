using GestaoDeCliente.Application.Modelos.ViewModels;
using GestaoDeCliente.Core.Entidades;
using GestaoDeCliente.Core.Repositorios;
using GestaoDeCliente.Core.Servicos;
using MediatR;

namespace GestaoDeCliente.Application.Commands.Criar
{
    public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, ResultadoDaOperacaoViewModel>
    {
        #region Propriedades

        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IClienteServico _clienteServico;
        #endregion

        #region Construtor

        public CriarClienteCommandHandler(IClienteRepositorio clienteRepositorio, IClienteServico clienteServico)
        {
            _clienteRepositorio = clienteRepositorio;
            _clienteServico = clienteServico;
        }

        #endregion

        #region Handler

        public async Task<ResultadoDaOperacaoViewModel> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            bool clienteComMesmoCnpj =  await _clienteServico.VerificarSeOCnpjEstaCadastrado(request.Cnpj);
            if (clienteComMesmoCnpj)
                return ResultadoDaOperacaoViewModel
                    .RetornoDeErro("O Cnpj informado já foi cadastrado!");
            Cliente novoCliente = Cliente.Criar(request.NomeFantasia, request.Cnpj);
            return await _clienteRepositorio.CadastrarCliente(novoCliente) 
                ? ResultadoDaOperacaoViewModel.RetornoDeSucesso() 
                : ResultadoDaOperacaoViewModel.RetornoDeErro("Ocorreu um inesperado durante o processamento do cadastro! Por favor, tente novamente.");
        }

        #endregion
    }
}
