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
            Cliente.Criar(1, "Empresa A", "41234567890122"),
            Cliente.Criar(2, "Empresa B", "12345678901234"),
            Cliente.Criar(3, "Empresa C", "98765432109876")
        ];

        // Representacao da interface de Manipulacao do BD
        public List<Cliente> Clientes => clientesBd;
    }
}
