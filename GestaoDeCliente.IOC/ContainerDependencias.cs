using GestaoDeCliente.Core.Repositorios;
using GestaoDeCliente.Core.Servicos;
using GestaoDeCliente.infrastructure.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeCliente.IOC
{
    public static class ContainerDependencias
    {

        public static IServiceCollection AdicionarServicos(this IServiceCollection servicos)
        {
            #region Conexao com banco de dados

            #endregion

            #region Repostorios

            servicos.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            #endregion

            #region Servico de Dominio

            servicos.AddScoped<IClienteServico, ClienteServico>();

            #endregion

            #region Fluent Validation


            #endregion

            return servicos;
        }
    }
}
