using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GestaoDeCliente.infrastructure.Configuracoes.NHibernate.Mapeamento;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace GestaoDeCliente.infrastructure.Configuracoes.NHibernate
{
    public static class NHibernateDependencia
    {
        #region Metodo
        public static IServiceCollection AdicionarNHibernate(this IServiceCollection servicos, string stringDeConexao)
        {
            var fabricaDeSessao = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .ConnectionString(stringDeConexao)
                    .ShowSql()
                    .FormatSql())
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<ClienteMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();

            servicos.AddSingleton<ISessionFactory>(fabricaDeSessao);
            servicos.AddScoped(fabrica => fabricaDeSessao.OpenSession());
            
            return servicos;
        }
        #endregion
    }
}
