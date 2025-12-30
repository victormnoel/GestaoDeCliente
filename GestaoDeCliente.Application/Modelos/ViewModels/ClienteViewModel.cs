using GestaoDeCliente.Core.Entidades;

namespace GestaoDeCliente.Application.Modelos.ViewModels
{
    public class ClienteViewModel
    {
        #region Propriedades
        public int ClienteId { get; set; }
        public string NomeFantasia { get; set; } = string.Empty;
        public string cnpj { get; set; } = string.Empty;

        #endregion

        #region Construtor
        public ClienteViewModel(Cliente cliente)
        {
            ClienteId = cliente.ClienteId;
            NomeFantasia = cliente.NomeFantasia;
            cnpj = cliente.Cnpj.NumeroFormatado;
        }
        #endregion
    }
}
