namespace GestaoDeCliente.Core.Excecoes
{
    public class CnpjInvalidoException : Exception
    {
        #region Construtor
        public CnpjInvalidoException(string mensagem) : base(mensagem)
        {}
        #endregion
    }
}
