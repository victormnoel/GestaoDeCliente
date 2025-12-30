namespace GestaoDeCliente.Core.Excecoes
{
    public class ClienteNaoIdentificadoException : Exception
    {
        #region Construtor
        public ClienteNaoIdentificadoException(string mensagem) : base(mensagem)
        {}
        #endregion
    }
}
