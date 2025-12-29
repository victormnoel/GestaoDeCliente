using GestaoDeCliente.Core.Enums;
using GestaoDeCliente.Core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeCliente.Core.Entidades
{
    public class Cliente
    {
        #region Propriedades

        public int ClienteId { get; private set; }
        public string NomeFantasia { get; private set; }
        public CNPJ Cnpj { get; private set; }
        public StatusPadrao Status { get; private set; }

        #endregion

        #region Construtor

        private Cliente(int clienteId, string nomeFantasia, CNPJ cnpj, StatusPadrao status)
        {
            ClienteId = clienteId;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Status = status;
        }
        #endregion

        #region Regras de Negocio

        public static Cliente Criar(int clientId, string nomeFantasia, string cnpj)
        {
            ValidarNomeFantasia(nomeFantasia);
            CNPJ cnpjInformado = CNPJ.Criar(cnpj);
            return new Cliente(clientId, nomeFantasia, cnpjInformado, StatusPadrao.Ativo);
        }

        public void AtualizarInformacoes(Cliente clienteAtualizado)
        {
            if (clienteAtualizado == null)
                throw new ClienteNaoIdentificadoException("Não foi possivel validar os dados do cliente para atualização!");

            ValidarNomeFantasia(clienteAtualizado.NomeFantasia);
            AtualizarNomeFantasia(clienteAtualizado.NomeFantasia);
            AtualizarCNPJ(clienteAtualizado.Cnpj.Numero);
        }

        public void InativarCliente()
        {
            if (Status == StatusPadrao.Inativo)
                throw new TrocaDeStatusInvalidaException("O cliente já esta inativado!");
            Status = StatusPadrao.Inativo;
        }

        public void AtivarCliente()
        {
            if(Status == StatusPadrao.Ativo)
                throw new TrocaDeStatusInvalidaException("O cliente já esta ativado!");
            Status = StatusPadrao.Ativo;
        }

        public void AtualizarNomeFantasia(string nomeFantasia)
        {
            ValidarNomeFantasia(nomeFantasia);
            NomeFantasia = nomeFantasia.Trim();
        }

        public void AtualizarCNPJ(string cnpj)
        {
            Cnpj = CNPJ.Criar(cnpj);
        }

        #region Invarientes de Negocio

        private static void ValidarNomeFantasia(string nomeFantasia)
        {
            bool retornoDaValidacao = nomeFantasia switch
            {
                _ when string.IsNullOrWhiteSpace(nomeFantasia) => false,
                _ when nomeFantasia.Distinct().Count() == 1 => false,
                _ when nomeFantasia.Trim().Count() < 2 => false,
                _ => true
            };

            if(!retornoDaValidacao)
                throw new NomeFantasiaInvalidoException("O nome fantasia informado não é valido!");
        }

        // verificar se já existe um cliente com o CNPJ informado


        #endregion

        #endregion
    }
}
