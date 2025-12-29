using GestaoDeCliente.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
