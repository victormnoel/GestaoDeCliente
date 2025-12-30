using GestaoDeCliente.Application.Modelos.ViewModels;
using MediatR;

namespace GestaoDeCliente.Application.Queries.Buscar
{
    public class BuscarClientePorIdQuery : IRequest<ClienteViewModel?>
    {
        #region Propriedades

        public int ClienteId { get; init; }

        #endregion

    }
}