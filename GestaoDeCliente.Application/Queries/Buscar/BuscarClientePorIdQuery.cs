using GestaoDeCliente.Application.Modelos.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeCliente.Application.Queries.Buscar
{
    public class BuscarClientePorIdQuery : IRequest<ClienteViewModel?>
    {
        public int ClienteId { get; init; }
    }
}