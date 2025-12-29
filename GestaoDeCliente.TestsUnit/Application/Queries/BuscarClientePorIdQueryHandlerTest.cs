using AutoFixture;
using Bogus;
using Bogus.Extensions.Brazil;
using FakeItEasy;
using GestaoDeCliente.Application.Modelos.ViewModels;
using GestaoDeCliente.Application.Queries.Buscar;
using GestaoDeCliente.Core.Entidades;
using GestaoDeCliente.Core.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeCliente.TestsUnit.Application.Queries
{
    public class BuscarClientePorIdQueryHandlerTest
    {
        #region Propriedades

        private readonly IClienteRepositorio _clienteRepositorioMock;
        private readonly Faker _faker;
        private readonly IFixture _fixture;
        private readonly BuscarClientePorIdQueryHandler _queryHandler;

        #endregion

        #region Construtor
        public BuscarClientePorIdQueryHandlerTest()
        {
            _clienteRepositorioMock = A.Fake<IClienteRepositorio>();
            _queryHandler = new BuscarClientePorIdQueryHandler(_clienteRepositorioMock);
            _faker = new Faker();
            _fixture = new Fixture();
        }
        #endregion

        #region Testes

        [Fact]
        public async Task SendoInformadoOIdDeUmClienteExistente_QuandoABuscaForRealizada_OClienteDeveSerRetornado()
        {
            int clienteIdInformado = 1;
            Cliente clientePesquisado = Cliente.Criar(
                _faker.Company.CompanyName(),
                _faker.Company.Cnpj());
            BuscarClientePorIdQuery query = new BuscarClientePorIdQuery() { ClienteId = clienteIdInformado };
            A.CallTo(() => _clienteRepositorioMock.BuscarClientePorId(query.ClienteId)).Returns(clientePesquisado);
            ClienteViewModel? clienteRetornado = await _queryHandler.Handle(query, CancellationToken.None);
            Assert.NotNull(clienteRetornado);
        }

        [Fact]
        public async Task SendoInformadoOIdDeUmClienteInexistente_QuandoABuscaForRealizada_OClienteDeveSerRetornadoNulo()
        {
            int clienteIdInformado = 001;
            A.CallTo(() => _clienteRepositorioMock.BuscarClientePorId(clienteIdInformado)).Returns<Cliente?>(null);
            BuscarClientePorIdQuery query = new BuscarClientePorIdQuery() { ClienteId = clienteIdInformado };
            ClienteViewModel? clienteRetornado = await _queryHandler.Handle(query, CancellationToken.None);
            Assert.Null(clienteRetornado);
        }

        [Fact]
        public async Task SendoInformadoOIdDeUmClienteExistente_QuandoABuscaForRealizada_OsDadosDoClienteDevemEstarCorretos()
        {
            int clienteIdInformado = 1;
            string nomeFantasiaEsperado = _faker.Company.CompanyName();
            string cnpjEsperado = _faker.Company.Cnpj();
            Cliente clientePesquisado = Cliente.Criar(
                nomeFantasiaEsperado,
                cnpjEsperado);
            BuscarClientePorIdQuery query = new BuscarClientePorIdQuery() { ClienteId = clienteIdInformado };
            A.CallTo(() => _clienteRepositorioMock.BuscarClientePorId(query.ClienteId)).Returns(clientePesquisado);
            ClienteViewModel? clienteRetornado = await _queryHandler.Handle(query, CancellationToken.None);
            Assert.NotNull(clienteRetornado);
            Assert.Equal(nomeFantasiaEsperado, clienteRetornado.NomeFantasia);
            Assert.Equal(clientePesquisado.Cnpj.NumeroFormatado, clienteRetornado.cnpj);
        }

        [Fact]
        public async Task SendoInformadoOIdZero_QuandoABuscaForRealizada_OClienteDeveSerRetornadoNulo()
        {
            int clienteIdInformado = 0;
            A.CallTo(() => _clienteRepositorioMock.BuscarClientePorId(clienteIdInformado)).Returns<Cliente?>(null);
            BuscarClientePorIdQuery query = new BuscarClientePorIdQuery() { ClienteId = clienteIdInformado };
            ClienteViewModel? clienteRetornado = await _queryHandler.Handle(query, CancellationToken.None);
            Assert.Null(clienteRetornado);
        }

        [Fact]
        public async Task SendoInformadoOIdNegativo_QuandoABuscaForRealizada_OClienteDeveSerRetornadoNulo()
        {
            int clienteIdInformado = -1;
            A.CallTo(() => _clienteRepositorioMock.BuscarClientePorId(clienteIdInformado)).Returns<Cliente?>(null);
            BuscarClientePorIdQuery query = new BuscarClientePorIdQuery() { ClienteId = clienteIdInformado };
            ClienteViewModel? clienteRetornado = await _queryHandler.Handle(query, CancellationToken.None);
            Assert.Null(clienteRetornado);
        }
        #endregion
    }
}
