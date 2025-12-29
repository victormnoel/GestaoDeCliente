using GestaoDeCliente.Core.Entidades;
using GestaoDeCliente.Core.Repositorios;
using GestaoDeCliente.infrastructure.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeCliente.infrastructure.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        #region Propriedades
        private readonly GestaoDeClienteContexto _contexto;
        #endregion

        #region Construtor
        public ClienteRepositorio(GestaoDeClienteContexto contexto)
        {
            _contexto = contexto;
        }
        #endregion

        #region Servicos
        public Task<Cliente?> BuscarClientePorId(int clientId)
        {
            Cliente? clienteRetornado = _contexto.Clientes.FirstOrDefault(cl => cl.ClienteId == clientId);
            return Task.FromResult(clienteRetornado);
        }

        public Task<Cliente?> BuscarClientePorCnpj(string cnpj)
        {
            Cliente? clienteEncontrado = _contexto.Clientes.FirstOrDefault(cl => cl.Cnpj.Numero == cnpj);
            return Task.FromResult(clienteEncontrado);
        }

        public Task<bool> CadastrarCliente(Cliente novoCliente)
        {
            _contexto.Clientes.Add(novoCliente);
            return Task.FromResult(true);
        }
        #endregion
    }
}
