using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeCliente.Core.Servicos
{
    public interface IClienteServico
    {
        Task<bool> VerificarSeOCnpjEstaCadastrado(string cnpj);
    }
}
