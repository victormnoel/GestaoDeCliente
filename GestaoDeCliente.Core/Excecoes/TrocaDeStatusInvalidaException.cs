using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
