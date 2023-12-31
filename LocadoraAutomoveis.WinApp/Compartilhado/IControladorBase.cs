﻿namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public interface IControladorBase
    {
        string ToolTipAdicionar { get; }

        string ToolTipEditar { get; }

        string ToolTipExcluir { get; }

        void Inserir();

        void Editar();

        void Excluir();

        void CarregarRegistros();

        string ObterTipoCadastro();

        DataGridView ObterGrid();
    }
}
