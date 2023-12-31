﻿using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloCliente
{
    public partial class TelaClienteForm : Form, ITelaBase<Cliente>
    {
        private Cliente _cliente;

        private Result _resultado;

        public event Func<Cliente, Result> OnGravarRegistro;

        public TelaClienteForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            _resultado = new Result();

            _cliente = new Cliente();

            txtNumero.Controls[0].Visible = false;
            txtCNPJ.Enabled = false;
        }

        public Cliente? Entidade
        {
            get => _cliente;

            set
            {
                txtNome.Text = value.Nome;
                txtEmail.Text = value.Email;
                txtTelefone.Text = value.Telefone;
                rdbPessoaJuridica.Checked = value.TipoCliente == TipoDocumento.CNPJ;
                txtCPF.Text = value.Documento;
                txtCNPJ.Text = value.Documento;
                txtEstado.Text = value.Estado;
                txtCidade.Text = value.Cidade;
                txtBairro.Text = value.Bairro;
                txtRua.Text = value.Rua;
                txtNumero.Text = value.Numero.ToString();
                _cliente = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidarCampos(sender, e);

            if (_resultado.IsFailed)
                this.DialogResult = DialogResult.None;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            ResetarErros();

            _cliente = ObterCliente();

            _resultado = OnGravarRegistro(_cliente);

            if (_resultado.IsFailed)
                MostrarErros();
        }

        private Cliente ObterCliente()
        {
            _cliente.Nome = txtNome.Text;
            _cliente.Email = txtEmail.Text;
            _cliente.Telefone = txtTelefone.Text;
            _cliente.TipoCliente = rdbPessoaFisica.Checked ? TipoDocumento.CPF : TipoDocumento.CNPJ;
            _cliente.Documento = rdbPessoaFisica.Checked ? txtCPF.Text : txtCNPJ.Text;
            _cliente.Estado = txtEstado.Text;
            _cliente.Cidade = txtCidade.Text;
            _cliente.Bairro = txtBairro.Text;
            _cliente.Rua = txtRua.Text;
            _cliente.Numero = (int)txtNumero.Value;

            return _cliente;
        }

        private void MostrarErros()
        {
            foreach (CustomError item in _resultado.Errors)
            {
                switch (item.PropertyName)
                {
                    case "Nome": lbErroNome.Text = item.ErrorMessage; lbErroNome.Visible = true; txtNome.Focus(); break;
                    case "Email": lbErroEmail.Text = item.ErrorMessage; lbErroEmail.Visible = true; txtEmail.Focus(); break;
                    case "Telefone": lbErroTelefone.Text = item.ErrorMessage; lbErroTelefone.Visible = true; txtTelefone.Focus(); break;
                    case "CPF": lbErroCPF.Text = item.ErrorMessage; lbErroCPF.Visible = true; txtCPF.Focus(); break;
                    case "CNPJ": lbErroCNPJ.Text = item.ErrorMessage; lbErroCNPJ.Visible = true; txtCNPJ.Focus(); break;
                    case "Estado": lbErroEstado.Text = item.ErrorMessage; lbErroEstado.Visible = true; txtEstado.Focus(); break;
                    case "Cidade": lbErroCidade.Text = item.ErrorMessage; lbErroCidade.Visible = true; txtCidade.Focus(); break;
                    case "Bairro": lbErroBairro.Text = item.ErrorMessage; lbErroBairro.Visible = true; txtBairro.Focus(); break;
                    case "Rua": lbErroRua.Text = item.ErrorMessage; lbErroRua.Visible = true; txtRua.Focus(); break;
                    case "Numero": lbErroNumero.Text = item.ErrorMessage; lbErroNumero.Visible = true; txtNumero.Focus(); break;
                }
            }
        }

        private void ResetarErros()
        {
            lbErroNome.Visible = false;
            lbErroEmail.Visible = false;
            lbErroTelefone.Visible = false;
            lbErroCPF.Visible = false;
            lbErroCNPJ.Visible = false;
            lbErroEstado.Visible = false;
            lbErroCidade.Visible = false;
            lbErroBairro.Visible = false;
            lbErroRua.Visible = false;
            lbErroNumero.Visible = false;

            _resultado.Errors.Clear();
            _resultado.Reasons.Clear();
        }

        private void rdbPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPessoaFisica.Checked)
            {
                txtCPF.Enabled = true;
                txtCNPJ.Enabled = false;
                txtCNPJ.Text = "";
            }
        }

        private void rdbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPessoaJuridica.Checked)
            {
                txtCNPJ.Enabled = true;
                txtCPF.Enabled = false;
                txtCPF.Text = "";
            }
        }

        private void selecaoAutomaticaNumericUpDown_Enter(object sender, EventArgs e)
        {
            ((TextBox)((NumericUpDown)sender).Controls[1]).SelectAll();
        }

        private void selecaoAutomaticaNumericUpDown_Click(object sender, EventArgs e)
        {
            if (((NumericUpDown)sender).Controls[1].Text == "0,00" || ((NumericUpDown)sender).Controls[1].Text == "0")
                ((TextBox)((NumericUpDown)sender).Controls[1]).SelectAll();
        }
    }
}
