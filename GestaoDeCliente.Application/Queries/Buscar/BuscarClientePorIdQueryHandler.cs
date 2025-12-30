using GestaoDeCliente.Application.Modelos.ViewModels;
using GestaoDeCliente.Core.Entidades;
using GestaoDeCliente.Core.Repositorios;
using MediatR;

namespace GestaoDeCliente.Application.Queries.Buscar
{
    public class BuscarClientePorIdQueryHandler : IRequestHandler<BuscarClientePorIdQuery, ClienteViewModel?>
    {
        #region Propriedades
        private readonly IClienteRepositorio _clienteRepositorio;
        #endregion

        #region Construtor
        public BuscarClientePorIdQueryHandler(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        #endregion

        #region Servico

        public async Task<ClienteViewModel?> Handle(BuscarClientePorIdQuery request, CancellationToken cancellationToken)
        {
            Cliente? clienteEncontrado = await _clienteRepositorio.BuscarClientePorId(request.ClienteId);
            return clienteEncontrado is null 
                ? null 
                : new ClienteViewModel(clienteEncontrado);
        }

        #endregion
    }
}
