﻿using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    public partial class TelaPlanosCobrancasForm : Form, ITelaBase<PlanoCobranca>
    {
        private PlanoCobranca _planoCobranca;

        private Result _resultado;

        public event Func<PlanoCobranca, Result> OnGravarRegistro;
        public TelaPlanosCobrancasForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _resultado = new Result();

            _planoCobranca = new PlanoCobranca();

            numPrecoDiaria.Controls[0].Visible = false;
            numPrecoKm.Controls[0].Visible = false;
            numKmDisponivel.Controls[0].Visible = false;
        }

        public PlanoCobranca? Entidade
        {
            get => _planoCobranca;

            set
            {
                cmbCategoria.Text = value.CategoriaAutomoveis.Nome;
                cmbTipoPlano.Text = value.Plano.ToDescriptionString();
                numPrecoDiaria.Value = value.ValorDia;
                numPrecoKm.Value = value.ValorDia;
                numKmDisponivel.Value = value.ValorDia;
                _planoCobranca = value;
            }
        }

        public void CarregarCategorias(List<CategoriaAutomoveis> categorias)
        {
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nome";
            cmbCategoria.ValueMember = "ID";
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (_resultado.IsFailed)
                this.DialogResult = DialogResult.None;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            ResetarErros();

            _planoCobranca = ObterPlanoCobranca();

            _resultado = OnGravarRegistro(_planoCobranca);

            if (_resultado.IsFailed)
                MostrarErros();
        }

        private PlanoCobranca ObterPlanoCobranca()
        {
            _planoCobranca.CategoriaAutomoveis = cmbCategoria.SelectedItem as CategoriaAutomoveis;
            _planoCobranca.Plano = (TipoPlano)cmbTipoPlano.SelectedIndex;
            _planoCobranca.ValorDia = numPrecoDiaria.Value;
            _planoCobranca.ValorKmRodado = numPrecoKm.Value;
            _planoCobranca.KmLivre = (int)numKmDisponivel.Value;

            return _planoCobranca;
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors.Cast<CustomError>())
            {
                switch (item.PropertyName)
                {
                    case "CategoriaAutomoveis": lbErroCategoria.Text = item.ErrorMessage; lbErroCategoria.Visible = true; break;
                    case "ValorDia": lbErroPrecoDiaria.Text = item.ErrorMessage; lbErroPrecoDiaria.Visible = true; break;
                    case "ValorKmRodado": lbErroPrecoKm.Text = item.ErrorMessage; lbErroPrecoKm.Visible = true; break;
                    case "KmLivre": lbErroKmDisponivel.Text = item.ErrorMessage; lbErroKmDisponivel.Visible = true; break;
                    case "Plano": lbErroTipoPlano.Text = item.ErrorMessage; lbErroTipoPlano.Visible = true; break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroCategoria.Visible = false;
            lbErroPrecoDiaria.Visible = false;
            lbErroPrecoKm.Visible = false;
            lbErroKmDisponivel.Visible = false;
            lbErroKmDisponivel.Visible = false;
            lbErroTipoPlano.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }
    }
}
