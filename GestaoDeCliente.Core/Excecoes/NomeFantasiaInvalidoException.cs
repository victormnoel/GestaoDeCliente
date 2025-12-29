using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
