namespace GestaoDeCliente.Core.Excecoes
{
    public class NomeFantasiaInvalidoException : Exception
    {
        #region Construtor
        public NomeFantasiaInvalidoException(string mensagem) : base(mensagem)
        {}
        #endregion
    }
}
