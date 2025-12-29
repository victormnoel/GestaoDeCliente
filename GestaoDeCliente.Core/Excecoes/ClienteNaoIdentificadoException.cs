using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
