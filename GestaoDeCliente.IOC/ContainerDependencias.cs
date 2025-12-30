using GestaoDeCliente.Core.Repositorios;
using GestaoDeCliente.Core.Servicos;
using GestaoDeCliente.infrastructure.Configuracoes.NHibernate;
using GestaoDeCliente.infrastructure.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            #endregion

            return servicos;
        }
    }
}
