﻿using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloParceiro
{
    public partial class TabelaParceiroControl : UserControl, ITabelaBase<Parceiro>
    {
        public TabelaParceiroControl()
        {
            InitializeComponent();

            gridParceiro.ConfigurarTabelaGrid("ID", "Nome");
        }

        public void AtualizarLista(List<Parceiro> parceiros)
        {
            gridParceiro.Rows.Clear();

            foreach (Parceiro item in parceiros)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridParceiro, item.ID, item.Nome);
                row.Cells[0].Tag = item;
                gridParceiro.Rows.Add(row);
            }

            gridParceiro.Columns[0].Visible = false;
            string msg = parceiros.Count >= 1 ? "Parceiros" : "Parceiro";
            TelaPrincipalForm.AtualizarStatus($"Visualizando {parceiros.Count} {msg}");
        }

        public DataGridView ObterGrid()
        {
            return gridParceiro;
        }

        public Parceiro ObterRegistroSelecionado()
        {
            return (Parceiro)gridParceiro.SelectedRows[0].Cells[0].Tag;
        }
    }
}
