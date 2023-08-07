﻿namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    partial class TelaAluguelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbFuncionario = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cmbCliente = new ComboBox();
            label3 = new Label();
            cmbCategoriaAutomoveis = new ComboBox();
            label4 = new Label();
            cmbPlanoCobranca = new ComboBox();
            label5 = new Label();
            cmbCondutor = new ComboBox();
            label6 = new Label();
            cmbAutomovel = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            txtKmAutomovel = new NumericUpDown();
            dateLocacao = new DateTimePicker();
            dateDevolucao = new DateTimePicker();
            label9 = new Label();
            label10 = new Label();
            txtCupom = new TextBox();
            btnCupom = new Button();
            lbErroCliente = new Label();
            lbErroFuncionario = new Label();
            lbErroGrupoAutomoveis = new Label();
            lbErroPlanoCobranca = new Label();
            lbErroDataLocacao = new Label();
            lbErroDataDevolucao = new Label();
            lbErroCondutor = new Label();
            lbErroAutomovel = new Label();
            lbErroKmAutomovel = new Label();
            tbTaxas = new TabPage();
            listTaxas = new CheckedListBox();
            tbControlTaxasAdicionadas = new TabControl();
            btnCancelar = new Button();
            btnGravar = new Button();
            label12 = new Label();
            lbValorTotal = new Label();
            lbErroCupom = new Label();
            lbErroTaxas = new Label();
            lbErroValorTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)txtKmAutomovel).BeginInit();
            tbTaxas.SuspendLayout();
            tbControlTaxasAdicionadas.SuspendLayout();
            SuspendLayout();
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(138, 33);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(154, 23);
            cmbFuncionario.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 36);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 1;
            label1.Text = "Funcionário:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 85);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 3;
            label2.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(138, 82);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(154, 23);
            cmbCliente.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 133);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 5;
            label3.Text = "Grupo de Automóveis:";
            // 
            // cmbCategoriaAutomoveis
            // 
            cmbCategoriaAutomoveis.FormattingEnabled = true;
            cmbCategoriaAutomoveis.Location = new Point(138, 130);
            cmbCategoriaAutomoveis.Name = "cmbCategoriaAutomoveis";
            cmbCategoriaAutomoveis.Size = new Size(154, 23);
            cmbCategoriaAutomoveis.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 183);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 7;
            label4.Text = "Plano de Cobrança:";
            // 
            // cmbPlanoCobranca
            // 
            cmbPlanoCobranca.FormattingEnabled = true;
            cmbPlanoCobranca.Location = new Point(138, 180);
            cmbPlanoCobranca.Name = "cmbPlanoCobranca";
            cmbPlanoCobranca.Size = new Size(154, 23);
            cmbPlanoCobranca.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(398, 85);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 9;
            label5.Text = "Condutor:";
            // 
            // cmbCondutor
            // 
            cmbCondutor.FormattingEnabled = true;
            cmbCondutor.Location = new Point(465, 82);
            cmbCondutor.Name = "cmbCondutor";
            cmbCondutor.Size = new Size(121, 23);
            cmbCondutor.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(390, 136);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 11;
            label6.Text = "Automóvel:";
            // 
            // cmbAutomovel
            // 
            cmbAutomovel.FormattingEnabled = true;
            cmbAutomovel.Location = new Point(465, 133);
            cmbAutomovel.Name = "cmbAutomovel";
            cmbAutomovel.Size = new Size(121, 23);
            cmbAutomovel.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(352, 183);
            label7.Name = "label7";
            label7.Size = new Size(107, 15);
            label7.TabIndex = 12;
            label7.Text = "KM do Automóvel:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 247);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 13;
            label8.Text = "Data Locação:";
            // 
            // txtKmAutomovel
            // 
            txtKmAutomovel.Enabled = false;
            txtKmAutomovel.Location = new Point(465, 180);
            txtKmAutomovel.Name = "txtKmAutomovel";
            txtKmAutomovel.Size = new Size(120, 23);
            txtKmAutomovel.TabIndex = 14;
            // 
            // dateLocacao
            // 
            dateLocacao.Format = DateTimePickerFormat.Short;
            dateLocacao.Location = new Point(138, 241);
            dateLocacao.Name = "dateLocacao";
            dateLocacao.Size = new Size(154, 23);
            dateLocacao.TabIndex = 15;
            // 
            // dateDevolucao
            // 
            dateDevolucao.Format = DateTimePickerFormat.Short;
            dateDevolucao.Location = new Point(465, 239);
            dateDevolucao.Name = "dateDevolucao";
            dateDevolucao.Size = new Size(154, 23);
            dateDevolucao.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(349, 243);
            label9.Name = "label9";
            label9.Size = new Size(110, 15);
            label9.TabIndex = 16;
            label9.Text = "Devolução Prevista:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(82, 313);
            label10.Name = "label10";
            label10.Size = new Size(50, 15);
            label10.TabIndex = 18;
            label10.Text = "Cupom:";
            // 
            // txtCupom
            // 
            txtCupom.Location = new Point(138, 305);
            txtCupom.Name = "txtCupom";
            txtCupom.Size = new Size(106, 23);
            txtCupom.TabIndex = 19;
            // 
            // btnCupom
            // 
            btnCupom.Location = new Point(267, 299);
            btnCupom.Name = "btnCupom";
            btnCupom.Size = new Size(106, 32);
            btnCupom.TabIndex = 20;
            btnCupom.Text = "Aplicar Cupom";
            btnCupom.UseVisualStyleBackColor = true;
            // 
            // lbErroCliente
            // 
            lbErroCliente.AutoSize = true;
            lbErroCliente.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCliente.Location = new Point(138, 64);
            lbErroCliente.Name = "lbErroCliente";
            lbErroCliente.Size = new Size(156, 15);
            lbErroCliente.TabIndex = 74;
            lbErroCliente.Text = "*Campo Cliente em branco*";
            lbErroCliente.Visible = false;
            // 
            // lbErroFuncionario
            // 
            lbErroFuncionario.AutoSize = true;
            lbErroFuncionario.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroFuncionario.Location = new Point(138, 9);
            lbErroFuncionario.Name = "lbErroFuncionario";
            lbErroFuncionario.Size = new Size(182, 15);
            lbErroFuncionario.TabIndex = 75;
            lbErroFuncionario.Text = "*Campo Funcionário em branco*";
            lbErroFuncionario.Visible = false;
            // 
            // lbErroGrupoAutomoveis
            // 
            lbErroGrupoAutomoveis.AutoSize = true;
            lbErroGrupoAutomoveis.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroGrupoAutomoveis.Location = new Point(138, 112);
            lbErroGrupoAutomoveis.Name = "lbErroGrupoAutomoveis";
            lbErroGrupoAutomoveis.Size = new Size(235, 15);
            lbErroGrupoAutomoveis.TabIndex = 76;
            lbErroGrupoAutomoveis.Text = "*Campo Grupo de Automóveis em branco*";
            lbErroGrupoAutomoveis.Visible = false;
            // 
            // lbErroPlanoCobranca
            // 
            lbErroPlanoCobranca.AutoSize = true;
            lbErroPlanoCobranca.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroPlanoCobranca.Location = new Point(138, 163);
            lbErroPlanoCobranca.Name = "lbErroPlanoCobranca";
            lbErroPlanoCobranca.Size = new Size(219, 15);
            lbErroPlanoCobranca.TabIndex = 77;
            lbErroPlanoCobranca.Text = "*Campo Plano de Cobrança em branco*";
            lbErroPlanoCobranca.Visible = false;
            // 
            // lbErroDataLocacao
            // 
            lbErroDataLocacao.AutoSize = true;
            lbErroDataLocacao.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroDataLocacao.Location = new Point(138, 223);
            lbErroDataLocacao.Name = "lbErroDataLocacao";
            lbErroDataLocacao.Size = new Size(190, 15);
            lbErroDataLocacao.TabIndex = 78;
            lbErroDataLocacao.Text = "*Campo Data Locação em branco*";
            lbErroDataLocacao.Visible = false;
            // 
            // lbErroDataDevolucao
            // 
            lbErroDataDevolucao.AutoSize = true;
            lbErroDataDevolucao.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroDataDevolucao.Location = new Point(465, 221);
            lbErroDataDevolucao.Name = "lbErroDataDevolucao";
            lbErroDataDevolucao.Size = new Size(202, 15);
            lbErroDataDevolucao.TabIndex = 79;
            lbErroDataDevolucao.Text = "*Campo Data Devolução em branco*";
            lbErroDataDevolucao.Visible = false;
            // 
            // lbErroCondutor
            // 
            lbErroCondutor.AutoSize = true;
            lbErroCondutor.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCondutor.Location = new Point(465, 59);
            lbErroCondutor.Name = "lbErroCondutor";
            lbErroCondutor.Size = new Size(170, 15);
            lbErroCondutor.TabIndex = 80;
            lbErroCondutor.Text = "*Campo Condutor em branco*";
            lbErroCondutor.Visible = false;
            // 
            // lbErroAutomovel
            // 
            lbErroAutomovel.AutoSize = true;
            lbErroAutomovel.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroAutomovel.Location = new Point(465, 115);
            lbErroAutomovel.Name = "lbErroAutomovel";
            lbErroAutomovel.Size = new Size(178, 15);
            lbErroAutomovel.TabIndex = 81;
            lbErroAutomovel.Text = "*Campo Automóvel em branco*";
            lbErroAutomovel.Visible = false;
            // 
            // lbErroKmAutomovel
            // 
            lbErroKmAutomovel.AutoSize = true;
            lbErroKmAutomovel.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroKmAutomovel.Location = new Point(465, 163);
            lbErroKmAutomovel.Name = "lbErroKmAutomovel";
            lbErroKmAutomovel.Size = new Size(199, 15);
            lbErroKmAutomovel.TabIndex = 82;
            lbErroKmAutomovel.Text = "*Campo KM Automóvel em branco*";
            lbErroKmAutomovel.Visible = false;
            // 
            // tbTaxas
            // 
            tbTaxas.Controls.Add(listTaxas);
            tbTaxas.Location = new Point(4, 24);
            tbTaxas.Name = "tbTaxas";
            tbTaxas.Padding = new Padding(3);
            tbTaxas.Size = new Size(620, 182);
            tbTaxas.TabIndex = 0;
            tbTaxas.Text = "Taxas Selecionadas";
            tbTaxas.UseVisualStyleBackColor = true;
            // 
            // listTaxas
            // 
            listTaxas.Dock = DockStyle.Fill;
            listTaxas.FormattingEnabled = true;
            listTaxas.Location = new Point(3, 3);
            listTaxas.Name = "listTaxas";
            listTaxas.Size = new Size(614, 176);
            listTaxas.TabIndex = 0;
            // 
            // tbControlTaxasAdicionadas
            // 
            tbControlTaxasAdicionadas.Controls.Add(tbTaxas);
            tbControlTaxasAdicionadas.Location = new Point(36, 346);
            tbControlTaxasAdicionadas.Name = "tbControlTaxasAdicionadas";
            tbControlTaxasAdicionadas.SelectedIndex = 0;
            tbControlTaxasAdicionadas.Size = new Size(628, 210);
            tbControlTaxasAdicionadas.TabIndex = 83;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(575, 588);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 37);
            btnCancelar.TabIndex = 85;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(484, 588);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(85, 37);
            btnGravar.TabIndex = 84;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(43, 578);
            label12.Name = "label12";
            label12.Size = new Size(109, 15);
            label12.TabIndex = 86;
            label12.Text = "Valor Total Previsto:";
            // 
            // lbValorTotal
            // 
            lbValorTotal.AutoSize = true;
            lbValorTotal.Location = new Point(169, 578);
            lbValorTotal.Name = "lbValorTotal";
            lbValorTotal.Size = new Size(20, 15);
            lbValorTotal.TabIndex = 87;
            lbValorTotal.Text = "R$";
            // 
            // lbErroCupom
            // 
            lbErroCupom.AutoSize = true;
            lbErroCupom.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroCupom.Location = new Point(133, 281);
            lbErroCupom.Name = "lbErroCupom";
            lbErroCupom.Size = new Size(159, 15);
            lbErroCupom.TabIndex = 88;
            lbErroCupom.Text = "*Campo Cupom em branco*";
            lbErroCupom.Visible = false;
            // 
            // lbErroTaxas
            // 
            lbErroTaxas.AutoSize = true;
            lbErroTaxas.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroTaxas.Location = new Point(517, 328);
            lbErroTaxas.Name = "lbErroTaxas";
            lbErroTaxas.Size = new Size(147, 15);
            lbErroTaxas.TabIndex = 89;
            lbErroTaxas.Text = "*Campo Taxas em branco*";
            lbErroTaxas.Visible = false;
            // 
            // lbErroValorTotal
            // 
            lbErroValorTotal.AutoSize = true;
            lbErroValorTotal.ForeColor = Color.FromArgb(192, 0, 0);
            lbErroValorTotal.Location = new Point(173, 559);
            lbErroValorTotal.Name = "lbErroValorTotal";
            lbErroValorTotal.Size = new Size(173, 15);
            lbErroValorTotal.TabIndex = 90;
            lbErroValorTotal.Text = "*Campo Valor Total em branco*";
            lbErroValorTotal.Visible = false;
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 637);
            Controls.Add(lbErroValorTotal);
            Controls.Add(lbErroTaxas);
            Controls.Add(lbErroCupom);
            Controls.Add(lbValorTotal);
            Controls.Add(label12);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(tbControlTaxasAdicionadas);
            Controls.Add(lbErroKmAutomovel);
            Controls.Add(lbErroAutomovel);
            Controls.Add(lbErroCondutor);
            Controls.Add(lbErroDataDevolucao);
            Controls.Add(lbErroDataLocacao);
            Controls.Add(lbErroPlanoCobranca);
            Controls.Add(lbErroGrupoAutomoveis);
            Controls.Add(lbErroFuncionario);
            Controls.Add(lbErroCliente);
            Controls.Add(btnCupom);
            Controls.Add(txtCupom);
            Controls.Add(label10);
            Controls.Add(dateDevolucao);
            Controls.Add(label9);
            Controls.Add(dateLocacao);
            Controls.Add(txtKmAutomovel);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cmbAutomovel);
            Controls.Add(label5);
            Controls.Add(cmbCondutor);
            Controls.Add(label4);
            Controls.Add(cmbPlanoCobranca);
            Controls.Add(label3);
            Controls.Add(cmbCategoriaAutomoveis);
            Controls.Add(label2);
            Controls.Add(cmbCliente);
            Controls.Add(label1);
            Controls.Add(cmbFuncionario);
            Name = "TelaAluguelForm";
            ShowIcon = false;
            Text = "Cadastro de Aluguel";
            ((System.ComponentModel.ISupportInitialize)txtKmAutomovel).EndInit();
            tbTaxas.ResumeLayout(false);
            tbControlTaxasAdicionadas.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbFuncionario;
        private Label label1;
        private Label label2;
        private ComboBox cmbCliente;
        private Label label3;
        private ComboBox cmbCategoriaAutomoveis;
        private Label label4;
        private ComboBox cmbPlanoCobranca;
        private Label label5;
        private ComboBox cmbCondutor;
        private Label label6;
        private ComboBox cmbAutomovel;
        private Label label7;
        private Label label8;
        private NumericUpDown txtKmAutomovel;
        private DateTimePicker dateLocacao;
        private DateTimePicker dateDevolucao;
        private Label label9;
        private Label label10;
        private TextBox txtCupom;
        private Button btnCupom;
        private Label lbErroCliente;
        private Label lbErroFuncionario;
        private Label lbErroGrupoAutomoveis;
        private Label lbErroPlanoCobranca;
        private Label lbErroDataLocacao;
        private Label lbErroDataDevolucao;
        private Label lbErroCondutor;
        private Label lbErroAutomovel;
        private Label lbErroKmAutomovel;
        private TabPage tbTaxas;
        private TabControl tbControlTaxasAdicionadas;
        private CheckedListBox listTaxas;
        private Button btnCancelar;
        private Button btnGravar;
        private Label label12;
        private Label lbValorTotal;
        private Label lbErroCupom;
        private Label lbErroTaxas;
        private Label lbErroValorTotal;
    }
}