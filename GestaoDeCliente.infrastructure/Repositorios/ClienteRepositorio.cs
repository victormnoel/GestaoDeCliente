using GestaoDeCliente.Core.Entidades;
using GestaoDeCliente.Core.Repositorios;
using GestaoDeCliente.infrastructure.Excecoes;
using NHibernate;
using NHibernate.Linq;

namespace GestaoDeCliente.infrastructure.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        #region Propriedades

        private readonly ISession _sessaoBd;

        #endregion

        #region Construtor
        public ClienteRepositorio(ISession sessaoBd)
        {
            _sessaoBd = sessaoBd;
        }
        #endregion

        #region Servicos
        public async Task<Cliente?> BuscarClientePorId(int clientId)
        {
            Cliente? clienteRetornado = await _sessaoBd.GetAsync<Cliente>(clientId);
            return clienteRetornado;
        }

        public async Task<Cliente?> BuscarClientePorCnpj(string cnpj)
        {

            Cliente? clienteRetornado = await _sessaoBd.Query<Cliente>()
                .Where(cl => cl.Cnpj.Numero == cnpj)
                .FirstOrDefaultAsync();
            return clienteRetornado;

        }

        public async Task<bool> CadastrarCliente(Cliente novoCliente)
        {
            ITransaction transacao = null;

            try
            {
                transacao = _sessaoBd.BeginTransaction();
                await _sessaoBd.SaveAsync(novoCliente);
                await transacao.CommitAsync();
                return true;
            }
            catch (Exception excecao)
            {
                await transacao?.RollbackAsync();
                throw new RepositorioException("Ocorreu um erro durante o processamento de cadastro");
            }
            finally
            {
                transacao?.Dispose();
            }
        }
        #endregion
    }
}
