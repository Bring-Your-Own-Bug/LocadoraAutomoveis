﻿using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.WinApp.Extensions;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    public partial class TabelaPlanosCobrancasControl : UserControl, ITabelaBase<PlanoCobranca>
    {
        public TabelaPlanosCobrancasControl()
        {
            InitializeComponent();

            gridPlanosCobrancas.ConfigurarTabelaGrid("ID", "Categoria de Automóvel");
        }

        public void AtualizarLista(List<PlanoCobranca> planosCobrancas)
        {
            gridPlanosCobrancas.Rows.Clear();

            foreach (PlanoCobranca item in planosCobrancas)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridPlanosCobrancas, item.ID, item.CategoriaAutomoveis.Nome);
                row.Cells[0].Tag = item;
                gridPlanosCobrancas.Rows.Add(row);
            }

            gridPlanosCobrancas.Columns[0].Visible = false;

            TelaPrincipalForm.AtualizarStatus($"Visualizando {planosCobrancas.Count} Planos de Cobrança");
        }

        public DataGridView ObterGrid()
        {
            return gridPlanosCobrancas;
        }

        public PlanoCobranca ObterRegistroSelecionado()
        {
            return (PlanoCobranca)gridPlanosCobrancas.SelectedRows[0].Cells[0].Tag;
        }
    }
}
