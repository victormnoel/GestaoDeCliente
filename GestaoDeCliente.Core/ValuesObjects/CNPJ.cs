using GestaoDeCliente.Core.Excecoes;
using System.Text.RegularExpressions;

namespace GestaoDeCliente.Core.ValuesObjects
{
    public record CNPJ
    {
        #region Propriedades

        public virtual string Numero { get; protected set; }
        public string NumeroFormatado => $"{Numero.Substring(0, 2)}.{Numero.Substring(2, 3)}.{Numero.Substring(5, 3)}/{Numero.Substring(8, 4)}-{Numero.Substring(12, 2)}";

        #endregion

        #region Construtor

        protected CNPJ() { } // Construtor quere sera utilizado pelo NHibernate

        private CNPJ(string cnpj)
        {
            Numero = cnpj;
        }

        #endregion

        #region Regras de negocio (Estruturais)

        public static CNPJ Criar(string cnpj)
        {
            string cnpjFormatado = LimparFormatacao(cnpj);
            if (!ValidarCNPJ(cnpjFormatado))
                throw new CnpjInvalidoException("O Cnpj informado não é valido!");

            return new CNPJ(cnpjFormatado);
        }

        #region Invariantes de negocio
        private static string LimparFormatacao(string cnpj) => Regex.Replace(cnpj, @"[^\d]", "");

        private static bool ValidarCNPJ(string cnpj)
        {
            return cnpj switch
            {
                _ when string.IsNullOrWhiteSpace(cnpj) => false,
                _ when cnpj.Length != 14 => false,
                _ when cnpj.Distinct().Count() == 1 => false,
                _ => true
            };
        }

        #endregion

        #endregion

    }
}
