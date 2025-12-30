using GestaoDeCliente.Core.Entidades;

namespace GestaoDeCliente.Core.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<Cliente?> BuscarClientePorCnpj(string cnpj);
        Task<bool> CadastrarCliente(Cliente novoCliente);
        Task<Cliente?> BuscarClientePorId(int clientId);
    }
}
