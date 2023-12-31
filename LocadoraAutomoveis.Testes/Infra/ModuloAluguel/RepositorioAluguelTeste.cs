﻿using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloAluguel
{
    [TestClass]
    public class RepositorioAluguelTeste
    {
        private RepositorioAluguel _repositorioAluguel;

        private ContextoDados _contexto;

        private Aluguel _aluguel;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioAluguel = new RepositorioAluguel(_contexto);

            _contexto.RemoveRange(_repositorioAluguel.SelecionarTodos());
            _contexto.RemoveRange(new RepositorioAutomovel(_contexto).SelecionarTodos());
            _contexto.RemoveRange(new RepositorioCondutores(_contexto).SelecionarTodos());
            _contexto.RemoveRange(new RepositorioCliente(_contexto).SelecionarTodos());
            _contexto.RemoveRange(new RepositorioFuncionario(_contexto).SelecionarTodos());
            _contexto.RemoveRange(new RepositorioCupom(_contexto).SelecionarTodos());
            _contexto.RemoveRange(new RepositorioParceiro(_contexto).SelecionarTodos());
            _contexto.RemoveRange(new RepositorioTaxaEServico(_contexto).SelecionarTodos());
            _contexto.RemoveRange(new RepositorioPlanosCobrancas(_contexto).SelecionarTodos());
            _contexto.RemoveRange(new RepositorioCategoriaAutomoveis(_contexto).SelecionarTodos());

            BuilderSetup.SetCreatePersistenceMethod<Aluguel>(_repositorioAluguel.Inserir);

            Funcionario funcionario = Builder<Funcionario>.CreateNew().Build();
            Cliente cliente = Builder<Cliente>.CreateNew().Build();
            CategoriaAutomoveis categoria = Builder<CategoriaAutomoveis>.CreateNew().Build();
            PlanoCobranca plano = Builder<PlanoCobranca>.CreateNew().With(c => c.CategoriaAutomoveis = categoria).Build();
            Condutor condutor = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente).Build();
            Automovel automovel = Builder<Automovel>.CreateNew().With(a => a.Categoria = categoria).With(c => c.Imagem = new byte[12]).Build();
            Parceiro parceiro = Builder<Parceiro>.CreateNew().Build();
            Cupom cupom = Builder<Cupom>.CreateNew().With(c => c.Parceiro = parceiro).Build();
            List<TaxaEServico> listTaxa = Builder<TaxaEServico>.CreateListOfSize(5).Build().ToList();
            DateTime dataLocacao = DateTime.Now;
            DateTime dataPrevista = dataLocacao.AddDays(1);
            DateTime dataDevolucao = dataLocacao.AddDays(2);
            decimal quilometrosRodados = 100;
            NivelTanque nivelTanque = NivelTanque.MeioTanque;
            decimal valorTotal = 1000;

            _aluguel = new Aluguel(funcionario, cliente, categoria, plano, condutor,
                automovel, cupom, listTaxa, dataLocacao, dataPrevista, dataDevolucao,
                quilometrosRodados, nivelTanque, valorTotal, true, TipoPlano.Diario);
        }

        [TestMethod]
        public void Deve_adicionar_um_Aluguel()
        {
            //action
            _repositorioAluguel.Inserir(_aluguel);
            _contexto.SaveChanges();

            //assert
            _repositorioAluguel.SelecionarPorID(_aluguel.ID).Should().Be(_aluguel);
        }

        [TestMethod]
        public void Deve_editar_um_Aluguel()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            _contexto.SaveChanges();
            var aluguel2 = _repositorioAluguel.SelecionarPorID(_aluguel.ID);
            aluguel2.DataPrevistaRetorno = new DateTime(2023, 8, 10);

            //action
            _repositorioAluguel.Editar(aluguel2);
            _contexto.SaveChanges();

            //assert
            var aluguelSelecionado = _repositorioAluguel.SelecionarPorID(_aluguel.ID);
            _repositorioAluguel.SelecionarTodos().Should().HaveCount(1);
            aluguelSelecionado.Should().Be(aluguel2);
        }

        [TestMethod]
        public void Deve_excluir_um_Aluguel()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            _contexto.SaveChanges();
            var aluguelSelecionado = _repositorioAluguel.SelecionarPorID(_aluguel.ID);

            //action
            _repositorioAluguel.Excluir(aluguelSelecionado);
            _contexto.SaveChanges();

            //assert
            _repositorioAluguel.SelecionarTodos().Should().HaveCount(0);
        }

        [TestMethod]
        public void Deve_selecionar_por_ID_um_Aluguel()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            _contexto.SaveChanges();

            //action
            var aluguelSelecionado = _repositorioAluguel.SelecionarPorID(_aluguel.ID);

            //assert
            aluguelSelecionado.Should().Be(_aluguel);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_alugueis()
        {
            //arrange
            Funcionario funcionario1 = Builder<Funcionario>.CreateNew().Build();
            Cliente cliente1 = Builder<Cliente>.CreateNew().Build();
            CategoriaAutomoveis categoria1 = Builder<CategoriaAutomoveis>.CreateNew().Build();
            PlanoCobranca plano1 = Builder<PlanoCobranca>.CreateNew().With(c => c.CategoriaAutomoveis = categoria1).Build();
            Condutor condutor1 = Builder<Condutor>.CreateNew().With(c => c.Cliente = cliente1).Build();
            Automovel automovel1 = Builder<Automovel>.CreateNew().With(a => a.Categoria = categoria1).With(c => c.Imagem = new byte[12]).Build();
            Parceiro parceiro1 = Builder<Parceiro>.CreateNew().Build();
            Cupom cupom1 = Builder<Cupom>.CreateNew().With(c => c.Parceiro = parceiro1).Build();
            List<TaxaEServico> taxas1 = Builder<TaxaEServico>.CreateListOfSize(5).Build().ToList();
            DateTime dataLocacao = DateTime.Now;
            DateTime dataPrevista = dataLocacao.AddDays(1);
            DateTime dataDevolucao = dataLocacao.AddDays(2);
            decimal quilometrosRodados = 100;
            NivelTanque nivelTanque = NivelTanque.MeioTanque;
            decimal valorTotal = 1000;

            Aluguel aluguel1 = new(funcionario1, cliente1, categoria1, plano1, condutor1, automovel1, cupom1, taxas1, dataLocacao, dataPrevista, dataDevolucao, quilometrosRodados, nivelTanque, valorTotal, false, TipoPlano.Diario);
            Aluguel aluguel2 = new(funcionario1, cliente1, categoria1, plano1, condutor1, automovel1, cupom1, taxas1, new DateTime(2023, 8, 5), new DateTime(2023, 8, 6), new DateTime(2023, 8, 6), quilometrosRodados, nivelTanque, valorTotal, false, TipoPlano.Diario);
            Aluguel aluguel3 = new(funcionario1, cliente1, categoria1, plano1, condutor1, automovel1, cupom1, taxas1, new DateTime(2023, 8, 5), new DateTime(2023, 8, 6), new DateTime(2023, 8, 6), quilometrosRodados, nivelTanque, valorTotal, false, TipoPlano.Diario);
            Aluguel aluguel4 = new(funcionario1, cliente1, categoria1, plano1, condutor1, automovel1, cupom1, taxas1, new DateTime(2023, 8, 5), new DateTime(2023, 8, 6), new DateTime(2023, 8, 6), quilometrosRodados, nivelTanque, valorTotal, false, TipoPlano.Diario);

            _repositorioAluguel.Inserir(aluguel1);
            _contexto.SaveChanges();
            _repositorioAluguel.Inserir(aluguel2);
            _contexto.SaveChanges();
            _repositorioAluguel.Inserir(aluguel3);
            _contexto.SaveChanges();
            _repositorioAluguel.Inserir(aluguel4);
            _contexto.SaveChanges();

            //action
            var listaAluguels = _repositorioAluguel.SelecionarTodos();

            //assert
            listaAluguels[0].Should().Be(aluguel1);
            listaAluguels[3].Should().Be(aluguel4);
            listaAluguels.Should().HaveCount(4);
        }

        [TestMethod]
        public void Deve_retornar_true_se_Aluguel_existe_validacao()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            _contexto.SaveChanges();
            var aluguel2 = new Aluguel(_aluguel.Funcionario, _aluguel.Cliente, _aluguel.CategoriaAutomoveis, _aluguel.PlanoCobranca, _aluguel.Condutor, _aluguel.Automovel,
                _aluguel.Cupom, _aluguel.ListaTaxasEServicos, _aluguel.DataLocacao, _aluguel.DataPrevistaRetorno, _aluguel.DataDevolucao, _aluguel.QuilometrosRodados,
                _aluguel.CombustivelRestante, _aluguel.ValorTotal, _aluguel.Concluido, _aluguel.Plano);

            Aluguel teste1 = new();

            var teste = _repositorioAluguel.SelecionarPorID(_aluguel.ID);
            teste.ID = teste1.ID;
            //action
            bool resultado = _repositorioAluguel.Existe(aluguel2);

            //assert
            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_retornar_false_se_Aluguel_equals_e_ID_igual_validacao()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            _contexto.SaveChanges();
            var aluguel2 = _repositorioAluguel.SelecionarPorID(_aluguel.ID);

            //action
            bool resultado = _repositorioAluguel.Existe(aluguel2);

            //assert
            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_verificar_se_Aluguel_existe_exclusao()
        {
            //arrange
            _repositorioAluguel.Inserir(_aluguel);
            _contexto.SaveChanges();
            var aluguel2 = _repositorioAluguel.SelecionarPorID(_aluguel.ID);

            //action
            bool resultado = _repositorioAluguel.Existe(aluguel2, true);

            //assert
            resultado.Should().BeTrue();
        }
    }
}
