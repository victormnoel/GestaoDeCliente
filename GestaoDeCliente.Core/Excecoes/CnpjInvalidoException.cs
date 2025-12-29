using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
