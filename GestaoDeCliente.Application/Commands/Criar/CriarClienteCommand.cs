using GestaoDeCliente.Application.Modelos.ViewModels;
using MediatR;

namespace GestaoDeCliente.Application.Commands.Criar
{
    public class CriarClienteCommand : IRequest<ResultadoDaOperacaoViewModel>
    {
        #region Propriedades

        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }

        #endregion
    }
}
