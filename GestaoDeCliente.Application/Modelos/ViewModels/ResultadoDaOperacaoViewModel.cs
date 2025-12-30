namespace GestaoDeCliente.Application.Modelos.ViewModels
{
    public class ResultadoDaOperacaoViewModel
    {
        #region Propriedades/Constantes
        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public IEnumerable<string> Erros { get; private set; }

        private const string MENSAGEM_DE_SUCESSO = "Operação realizada com sucesso";

        #endregion

        #region construtor

        private ResultadoDaOperacaoViewModel(bool sucesso, string mensagem, IEnumerable<string> erros)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Erros = erros ?? new List<string>();
        }

        #endregion

        #region Metodos

        public static ResultadoDaOperacaoViewModel RetornoDeSucesso(string mensagem = MENSAGEM_DE_SUCESSO)
        {
            return new ResultadoDaOperacaoViewModel(true, mensagem, null);
        }

        public static ResultadoDaOperacaoViewModel RetornoDeErro(string mensagem, IEnumerable<string> erros = null)
        {
            return new ResultadoDaOperacaoViewModel(false, mensagem, erros);
        }

        public static ResultadoDaOperacaoViewModel RetornoDeErro(string mensagem, string erro)
        {
            return new ResultadoDaOperacaoViewModel(false, mensagem, new List<string> { erro });
        }

        #endregion
    }
}
