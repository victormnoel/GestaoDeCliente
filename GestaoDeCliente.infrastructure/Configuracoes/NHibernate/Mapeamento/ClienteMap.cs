using FluentNHibernate.Mapping;
using GestaoDeCliente.Core.Entidades;

namespace GestaoDeCliente.infrastructure.Configuracoes.NHibernate.Mapeamento
{
    public class ClienteMap : ClassMap<Cliente>
    {
        #region Construtor
        public ClienteMap()
        {
            Table("Clientes");

            Id(x => x.ClienteId)
                .Column("ClienteId")
                .GeneratedBy.Identity();

            Map(x => x.NomeFantasia).Length(200)
                .Not.Nullable();

            Component(x => x.Cnpj, c =>
            {
                c.Map(x => x.Numero)
                    .Column("Cnpj")
                    .Length(14)
                    .Not.Nullable();
            });

            Map(x => x.Status)
                .CustomType<int>()
                .Not.Nullable();
        }
        #endregion
    }
}
