using GestaoDeCliente.Core.Repositorios;
using GestaoDeCliente.Core.Servicos;
using GestaoDeCliente.infrastructure.Contexto;
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
        public static IServiceCollection AdicionarServicos(this IServiceCollection servicos, IConfiguration configuracoes)
        {
            #region Conexao com banco de dados

            string stringDeConexao = configuracoes.GetConnectionString("StringDeConexao")!;
            servicos.AdicionarNHibernate(stringDeConexao);

            #endregion

            #region Repostorios

            servicos.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            #endregion

            #region Servico de Dominio

            servicos.AddScoped<IClienteServico, ClienteServico>();
            servicos.AddScoped<GestaoDeClienteContexto>();

            #endregion

            return servicos;
        }
    }
}
