﻿using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoAutomovel : IServicoAutomovel
    {
        private readonly IRepositorioAutomovel _repositorioAutomovel;
        private readonly IValidadorAutomovel _validadorAutomovel;
        private readonly IContextoPersistencia _contextoPersistencia;

        public ServicoAutomovel(IRepositorioAutomovel repositorioAutomovel, IValidadorAutomovel validadorAutomovel,
            IContextoPersistencia contextoPersistencia)
        {
            _repositorioAutomovel = repositorioAutomovel;
            _validadorAutomovel = validadorAutomovel;
            _contextoPersistencia = contextoPersistencia;
        }

        #region CRUD
        public Result Inserir(Automovel automovelParaAdicionar)
        {
            Log.Debug("Tentando inserir o Automóvel '{PLACA}'", automovelParaAdicionar.Placa);

            Result resultado = ValidarRegistro(automovelParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar inserir o Automóvel '{PLACA}'", automovelParaAdicionar.Placa);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }

            try
            {
                _repositorioAutomovel.Inserir(automovelParaAdicionar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Inserido o Automóvel '{PLACA} #{ID}' com sucesso!", automovelParaAdicionar.Placa, automovelParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar inserir o Automóvel ", "Automovel", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{A}", automovelParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(Automovel automovelParaEditar)
        {
            Log.Debug("Tentando editar o Automóvel '{PLACA} #{ID}'", automovelParaEditar.Placa, automovelParaEditar.ID);

            Result resultado = ValidarRegistro(automovelParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Automóvel '{PLACA} #{ID}'", automovelParaEditar.Placa, automovelParaEditar.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioAutomovel.Editar(automovelParaEditar);

                _contextoPersistencia.GravarDados();

                Log.Debug("Editado o Automóvel '{PLACA} #{ID}' com sucesso!", automovelParaEditar.Placa, automovelParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar editar o Automóvel ", "Automovel", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{A}", automovelParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(Automovel automovelParaExcluir)
        {
            Log.Debug("Tentando excluir o Automóvel '{PLACA} #{ID}'", automovelParaExcluir.Placa, automovelParaExcluir.ID);

            if (_repositorioAutomovel.Existe(automovelParaExcluir, true) == false)
            {
                Log.Warning("Automóvel {ID} não encontrado para excluir", automovelParaExcluir.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail("Automóvel não encontrado");
            }

            try
            {
                _repositorioAutomovel.Excluir(automovelParaExcluir);

                _contextoPersistencia.GravarDados();

                Log.Debug("Excluído o Automóvel '{PLACA} #{ID}' com sucesso!", automovelParaExcluir.Placa, automovelParaExcluir.ID);

                return Result.Ok();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                List<IError> erros = AnalisarErros(automovelParaExcluir, sqlException);

                return Result.Fail(erros);
            }
            catch (InvalidOperationException ex)
            {
                List<IError> erros = AnalisarErros(automovelParaExcluir, ex);

                return Result.Fail(erros);
            }
        }

        private List<IError> AnalisarErros(Automovel automovelParaExcluir, Exception exception)
        {
            List<IError> erros = new();

            _contextoPersistencia.DesfazerAlteracoes();

            Log.Warning("Falha ao tentar excluir o Automóvel '{PLACA} #{ID}'", automovelParaExcluir.Placa, automovelParaExcluir.ID, exception);

            if (exception.Message.Contains("FK_TBAluguel_TBAutomovel") || exception.Message.Contains("'Automovel' and 'Aluguel'"))
                erros.Add(new CustomError("Esse Automóvel está relacionado a um Aluguel." +
                    " Primeiro exclua o Aluguel relacionado", "Automovel"));
            else
                erros.Add(new CustomError("Falha ao tentar excluir o Automóvel", "Automovel"));

            return erros;
        }
        #endregion

        public Automovel SelecionarRegistroPorID(Guid automovelID)
        {
            return _repositorioAutomovel.SelecionarPorID(automovelID);
        }

        public List<Automovel> SelecionarTodosOsRegistros()
        {
            return _repositorioAutomovel.SelecionarTodos();
        }

        public List<Automovel> FiltrarAutomoveisPorCategoria(CategoriaAutomoveis categoria)
        {
            return _repositorioAutomovel.SelecionarPorCategoria(categoria);
        }

        public Result VerificarDisponibilidade(Automovel automovelParaValidar)
        {
            if (_validadorAutomovel.VerificarSeAlugado(automovelParaValidar))
            {
                return new CustomError("Esse Automóvel está relacionado a um Aluguel em Aberto." +
                        " Primeiro conclua o Aluguel relacionado", "Automovel");
            }

            return Result.Ok();
        }

        public Result ValidarRegistro(Automovel automovelParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorAutomovel.Validate(automovelParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioAutomovel.Existe(automovelParaValidar))
                erros.Add(new CustomError("Esse Automóvel já existe", "Placa"));

            return Result.Fail(erros);
        }
    }
}
