namespace GestaoDeCliente.Core.Servicos
{
    public interface IClienteServico
    {
        Task<bool> VerificarSeOCnpjEstaCadastrado(string cnpj);
    }
}
