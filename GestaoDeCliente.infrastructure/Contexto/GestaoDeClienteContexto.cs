using GestaoDeCliente.Core.Entidades;
using GestaoDeCliente.Core.Enums;
using GestaoDeCliente.Core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeCliente.infrastructure.Contexto
{
    public class GestaoDeClienteContexto
    {
        // Representacao do BD
        private static List<Cliente> clientesBd = 
        [
            Cliente.Criar("Empresa A", "41234567890122"),
        ];

        // Representacao da interface de Manipulacao do BD
        public List<Cliente> Clientes => clientesBd;
    }
}
