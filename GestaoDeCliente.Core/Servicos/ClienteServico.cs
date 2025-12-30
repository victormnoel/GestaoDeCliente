using GestaoDeCliente.Core.Entidades;
using GestaoDeCliente.Core.Excecoes;
using GestaoDeCliente.Core.Repositorios;
using System.Text.RegularExpressions;

namespace GestaoDeCliente.Core.Servicos
{
    public class ClienteServico : IClienteServico
    {

        #region Propriedades

        private readonly IClienteRepositorio _clienteRepositorio;

        #endregion

        #region Construtor

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio; 
        }

        #endregion

        #region Servicos

        public async Task<bool> VerificarSeOCnpjEstaCadastrado(string cnpj)
        {
            string cnpjSemFomatacao = Regex.Replace(cnpj, @"[^\d]", "");

            if (string.IsNullOrWhiteSpace(cnpjSemFomatacao))
                throw new CnpjInvalidoException("O Cnpj informado não é valido!");

            Cliente? clienteComMesmoCnpj = await _clienteRepositorio.BuscarClientePorCnpj(cnpjSemFomatacao);
            return clienteComMesmoCnpj is null ? false : true;
        }

        #endregion
    }
}
