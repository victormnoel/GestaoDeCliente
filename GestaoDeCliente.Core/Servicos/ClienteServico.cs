using GestaoDeCliente.Core.Entidades;
using GestaoDeCliente.Core.Repositorios;
using GestaoDeCliente.Core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                throw new ArgumentException("O Cnpj informado não é valido!");

            Cliente clienteComMesmoCnpj = await _clienteRepositorio.BuscarClientePorCnpj(cnpjSemFomatacao);
            return clienteComMesmoCnpj is null ? true : false;
        }

        #endregion
    }
}
