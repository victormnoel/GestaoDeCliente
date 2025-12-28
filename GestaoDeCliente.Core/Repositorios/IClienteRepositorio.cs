using GestaoDeCliente.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeCliente.Core.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<Cliente> BuscarClientePorCnpj(string cnpj);
        Task<bool> CadastrarClient(Cliente novoCliente);
        Task<Cliente> BuscarCliente(int clientId);
    }
}
