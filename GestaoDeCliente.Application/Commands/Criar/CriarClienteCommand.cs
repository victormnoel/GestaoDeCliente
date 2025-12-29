using GestaoDeCliente.Application.Modelos.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeCliente.Application.Commands.Criar
{
    public class CriarClienteCommand : IRequest<ResultadoDaOperacaoViewModel>
    {
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }

    }
}
