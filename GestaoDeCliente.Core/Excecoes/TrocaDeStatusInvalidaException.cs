namespace GestaoDeCliente.Core.Excecoes
{
    public class TrocaDeStatusInvalidaException : Exception
    {
        #region Construtor

        public TrocaDeStatusInvalidaException(string mensagem) : base(mensagem)
        {}

        #endregion
    }
}
