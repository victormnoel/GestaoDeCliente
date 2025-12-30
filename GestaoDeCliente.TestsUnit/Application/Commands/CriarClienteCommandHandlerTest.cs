using Bogus;
using Bogus.Extensions.Brazil;
using FakeItEasy;
using GestaoDeCliente.Application.Commands.Criar;
using GestaoDeCliente.Application.Modelos.ViewModels;
using GestaoDeCliente.Core.Entidades;
using GestaoDeCliente.Core.Excecoes;
using GestaoDeCliente.Core.Repositorios;
using GestaoDeCliente.Core.Servicos;

namespace GestaoDeCliente.TestsUnit.Application.Commands
{
    public class CriarClienteCommandHandlerTest
    {
        #region Propriedades

        private readonly IClienteServico _clienteServicoMock;
        private readonly IClienteRepositorio _clienteRepositorioMock;
        private readonly Faker _faker;
        private readonly CriarClienteCommandHandler _commandHandler;

        #endregion

        #region Construtor
        public CriarClienteCommandHandlerTest()
        {
            _clienteServicoMock = A.Fake<IClienteServico>();
            _clienteRepositorioMock = A.Fake<IClienteRepositorio>();
            _faker = new Faker();
            _commandHandler = new CriarClienteCommandHandler(_clienteRepositorioMock, _clienteServicoMock);
        }
        #endregion

        #region Testes

        [Fact]
        public async Task SendoInformadoDadosValidos_QuandoOProcessoDeCriacaoForExecutado_DeveSerRetornadoSucesso()
        {
            string nomeFantasiaInformado = _faker.Company.CompanyName();
            string CnpjInformado = _faker.Company.Cnpj();
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaInformado, Cnpj = CnpjInformado };
            A.CallTo(() => _clienteServicoMock.VerificarSeOCnpjEstaCadastrado(A<string>._)).Returns(false);
            A.CallTo(() => _clienteRepositorioMock.CadastrarCliente(A<Cliente>._)).Returns(true);
            ResultadoDaOperacaoViewModel retornoDaOperacao = await _commandHandler.Handle(command, CancellationToken.None);
            Assert.True(retornoDaOperacao.Sucesso);
            Assert.Equal("Operação realizada com sucesso", retornoDaOperacao.Mensagem);
        }

        [Fact]
        public async Task SendoOCnpjInformadoJaCadastrado_QuandoOProcessoDeCriacaoForExecutado_DeveSerRetornadoUmErroComAMensagemIndicativa()
        {
            string nomeFantasiaInformado = _faker.Company.CompanyName();
            string CnpjInformado = _faker.Company.Cnpj();
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaInformado, Cnpj = CnpjInformado };
            A.CallTo(() => _clienteServicoMock.VerificarSeOCnpjEstaCadastrado(A<string>._)).Returns(true);
            A.CallTo(() => _clienteRepositorioMock.CadastrarCliente(A<Cliente>._)).Returns(true);
            ResultadoDaOperacaoViewModel retornoDaOperacao = await _commandHandler.Handle(command, CancellationToken.None);
            Assert.False(retornoDaOperacao.Sucesso);
            Assert.Equal("O Cnpj informado já foi cadastrado!", retornoDaOperacao.Mensagem);
        }

        [Fact]
        public async Task SendoInformadoUmCnpjInvalido_QuandoOProcessoDeCriacaoForExecutado_DeveSerLançadaACnpjInvalidoException()
        {
            string nomeFantasiaInformado = _faker.Company.CompanyName();
            string cnpjInvalido = "11111111111111";
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaInformado, Cnpj = cnpjInvalido };
            await Assert.ThrowsAsync<CnpjInvalidoException>(async () => await _commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task SendoInformadoONomeFantasiaInvalido_QuandoOProcessoDeCriacaoForExecutado_DeveSerLançadaNomeFantasiaInvalidoException()
        {
            string nomeFantasiaInvalido = "aaaaaaaaaa";
            string cnpjInformado = _faker.Company.Cnpj();
            CriarClienteCommand command = new CriarClienteCommand() { Cnpj = cnpjInformado, NomeFantasia = nomeFantasiaInvalido };
            await Assert.ThrowsAsync<NomeFantasiaInvalidoException>(async () => await _commandHandler.Handle(command, CancellationToken.None));
        }


        [Fact]
        public async Task CasoOCadastroDoClienteNaoTenhaSidoArmazenado_QuandoOProcessoDeCriacaoForFinalizado_DeveSerRetornadoUmErroComAMensagemIndicativa()
        {
            string nomeFantasiaInformado = _faker.Company.CompanyName();
            string cnpjInformado = _faker.Company.Cnpj();
            CriarClienteCommand command = new CriarClienteCommand() { Cnpj = cnpjInformado, NomeFantasia = nomeFantasiaInformado };
            A.CallTo(() => _clienteServicoMock.VerificarSeOCnpjEstaCadastrado(A<string>._)).Returns(false);
            A.CallTo(() => _clienteRepositorioMock.CadastrarCliente(A<Cliente>._)).Returns(false);
            ResultadoDaOperacaoViewModel retornoDaOperacao = await _commandHandler.Handle(command, CancellationToken.None);
            Assert.False(retornoDaOperacao.Sucesso);
            Assert.Equal("Ocorreu um inesperado durante o processamento do cadastro! Por favor, tente novamente.", retornoDaOperacao.Mensagem);
        }

        [Fact]
        public async Task SendoInformadoUmCnpjVazio_QuandoOProcessoDeCriacaoForExecutado_DeveSerLançadaACnpjInvalidoException()
        {
            string nomeFantasiaInformado = _faker.Company.CompanyName();
            string cnpjVazio = string.Empty;
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaInformado, Cnpj = cnpjVazio };
            await Assert.ThrowsAsync<CnpjInvalidoException>(async () => await _commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task SendoInformadoUmNomeFantasiaVazio_QuandoOProcessoDeCriacaoForExecutado_DeveSerLançadaNomeFantasiaInvalidoException()
        {
            string nomeFantasiaVazio = string.Empty;
            string cnpjInformado = _faker.Company.Cnpj();
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaVazio, Cnpj = cnpjInformado };
            await Assert.ThrowsAsync<NomeFantasiaInvalidoException>(async () => await _commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task SendoInformadoUmNomeFantasiaComApenasEspacos_QuandoOProcessoDeCriacaoForExecutado_DeveSerLançadaNomeFantasiaInvalidoException()
        {
            string nomeFantasiaComEspacos = "     ";
            string cnpjInformado = _faker.Company.Cnpj();
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaComEspacos, Cnpj = cnpjInformado };
            await Assert.ThrowsAsync<NomeFantasiaInvalidoException>(async () => await _commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task SendoInformadoUmNomeFantasiaComApenasUmCaracter_QuandoOProcessoDeCriacaoForExecutado_DeveSerLançadaNomeFantasiaInvalidoException()
        {
            string nomeFantasiaUmCaracter = "A";
            string cnpjInformado = _faker.Company.Cnpj();
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaUmCaracter, Cnpj = cnpjInformado };
            await Assert.ThrowsAsync<NomeFantasiaInvalidoException>(async () => await _commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task SendoInformadoDadosValidos_QuandoOProcessoDeCriacaoForExecutado_OServicoDeveVerificarSeOCnpjEstaCadastrado()
        {
            string nomeFantasiaInformado = _faker.Company.CompanyName();
            string cnpjInformado = _faker.Company.Cnpj();
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaInformado, Cnpj = cnpjInformado };
            A.CallTo(() => _clienteServicoMock.VerificarSeOCnpjEstaCadastrado(cnpjInformado)).Returns(false);
            A.CallTo(() => _clienteRepositorioMock.CadastrarCliente(A<Cliente>._)).Returns(true);
            await _commandHandler.Handle(command, CancellationToken.None);
            A.CallTo(() => _clienteServicoMock.VerificarSeOCnpjEstaCadastrado(cnpjInformado)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task SendoOCnpjJaCadastrado_QuandoOProcessoDeCriacaoForExecutado_ORepositorioNaoDeveSerChamado()
        {
            string nomeFantasiaInformado = _faker.Company.CompanyName();
            string cnpjInformado = _faker.Company.Cnpj();
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaInformado, Cnpj = cnpjInformado };
            A.CallTo(() => _clienteServicoMock.VerificarSeOCnpjEstaCadastrado(A<string>._)).Returns(true);
            await _commandHandler.Handle(command, CancellationToken.None);
            A.CallTo(() => _clienteRepositorioMock.CadastrarCliente(A<Cliente>._)).MustNotHaveHappened();
        }

        [Fact]
        public async Task SendoInformadoDadosValidos_QuandoOProcessoDeCriacaoForExecutado_ORepositorioDeveCadastrarOCliente()
        {
            string nomeFantasiaInformado = _faker.Company.CompanyName();
            string cnpjInformado = _faker.Company.Cnpj();
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaInformado, Cnpj = cnpjInformado };
            A.CallTo(() => _clienteServicoMock.VerificarSeOCnpjEstaCadastrado(A<string>._)).Returns(false);
            A.CallTo(() => _clienteRepositorioMock.CadastrarCliente(A<Cliente>._)).Returns(true);
            await _commandHandler.Handle(command, CancellationToken.None);
            A.CallTo(() => _clienteRepositorioMock.CadastrarCliente(A<Cliente>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task SendoInformadoUmCnpjComCaracteresEspeciais_QuandoOProcessoDeCriacaoForExecutado_DeveSerLançadaACnpjInvalidoException()
        {
            string nomeFantasiaInformado = _faker.Company.CompanyName();
            string cnpjComCaracteresEspeciais = "@@.###.$$$/@@@-##";
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaInformado, Cnpj = cnpjComCaracteresEspeciais };
            await Assert.ThrowsAsync<CnpjInvalidoException>(async () => await _commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task SendoInformadoUmCnpjComTamanhoInvalido_QuandoOProcessoDeCriacaoForExecutado_DeveSerLançadaACnpjInvalidoException()
        {
            string nomeFantasiaInformado = _faker.Company.CompanyName();
            string cnpjTamanhoInvalido = "123456";
            CriarClienteCommand command = new CriarClienteCommand() { NomeFantasia = nomeFantasiaInformado, Cnpj = cnpjTamanhoInvalido };
            await Assert.ThrowsAsync<CnpjInvalidoException>(async () => await _commandHandler.Handle(command, CancellationToken.None));
        }

        #endregion
    }
}
