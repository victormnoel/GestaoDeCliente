namespace GestaoDeCliente.infrastructure.Excecoes
{
    public class RepositorioException : Exception
    {
        #region Construtor
        public RepositorioException(string mensagem) : base(mensagem)
        {}
        #endregion
    }
}
