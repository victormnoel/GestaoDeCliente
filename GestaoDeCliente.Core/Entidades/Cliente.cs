using GestaoDeCliente.Core.Enums;
using GestaoDeCliente.Core.Excecoes;
using GestaoDeCliente.Core.ValuesObjects;

namespace GestaoDeCliente.Core.Entidades
{
    public class Cliente
    {
        #region Propriedades

        public virtual int ClienteId { get; protected set; }
        public virtual string NomeFantasia { get; protected set; }
        public virtual CNPJ Cnpj { get; protected set; }
        public virtual StatusPadrao Status { get; protected set; }

        #endregion

        #region Construtor

        protected Cliente() { } // Construtor para ser utilizado pelo NHibernate

        private Cliente(string nomeFantasia, CNPJ cnpj, StatusPadrao status)
        {
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Status = status;
        }
        #endregion

        #region Regras de Negocio

        public static Cliente Criar(string nomeFantasia, string cnpj)
        {
            ValidarNomeFantasia(nomeFantasia);
            CNPJ cnpjInformado = CNPJ.Criar(cnpj);
            return new Cliente(nomeFantasia, cnpjInformado, StatusPadrao.Ativo);
        }

        public virtual void AtualizarInformacoes(Cliente clienteAtualizado)
        {
            if (clienteAtualizado == null)
                throw new ClienteNaoIdentificadoException("Não foi possivel validar os dados do cliente para atualização!");

            ValidarNomeFantasia(clienteAtualizado.NomeFantasia);
            AtualizarNomeFantasia(clienteAtualizado.NomeFantasia);
            AtualizarCNPJ(clienteAtualizado.Cnpj.Numero);
        }

        public virtual void InativarCliente()
        {
            if (Status == StatusPadrao.Inativo)
                throw new TrocaDeStatusInvalidaException("O cliente já esta inativado!");
            Status = StatusPadrao.Inativo;
        }

        public virtual void AtivarCliente()
        {
            if(Status == StatusPadrao.Ativo)
                throw new TrocaDeStatusInvalidaException("O cliente já esta ativado!");
            Status = StatusPadrao.Ativo;
        }

        public virtual void AtualizarNomeFantasia(string nomeFantasia)
        {
            ValidarNomeFantasia(nomeFantasia);
            NomeFantasia = nomeFantasia.Trim();
        }

        public virtual void AtualizarCNPJ(string cnpj)
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

        #endregion

        #endregion
    }
}
