using GestaoDeCliente.Application.Modelos.ViewModels;
using MediatR;

namespace GestaoDeCliente.Application.Queries.Buscar
{
    public class BuscarClientePorIdQuery : IRequest<ClienteViewModel?>
    {
        public int ClienteId { get; init; }
    }
}