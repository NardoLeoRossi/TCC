using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.Tools.Applications.Deployment;
using OrcamentosIfc.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrcamentosIfc.Sinapi
{
    public partial class Frm_SelecionarItemsSinapi : Form
    {

        private AppDbContext _appdbContext;

        public Frm_SelecionarItemsSinapi()
        {
            InitializeComponent();

            _appdbContext = new AppDbContext();

            Configure();
        }

        private void Configure()
        {
            Insumos_Configure();
            Sinteticas_Configure();

            LoadComboboxes();
        }

        #region Insumos

        private List<Insumo> _insumos;

        private void Insumos_Configure()
        {
            CriarFiltros(Lst_Insumos, Pnl_InsumosFiltros, TbInsumosFiltro_TextChanged);
            Insumos_Load();
        }
        private void TbInsumosFiltro_TextChanged(object sender, EventArgs e)
        {
            Insumos_Load();
        }

        private void Insumos_Load()
        {
            var codigo = ((TextBox)Lst_Insumos.Columns[0].Tag).Text.ToUpper();
            var descricao = ((TextBox)Lst_Insumos.Columns[1].Tag).Text.ToUpper();
            var unidade = ((TextBox)Lst_Insumos.Columns[2].Tag).Text.ToUpper();
            var origemPreceo = ((TextBox)Lst_Insumos.Columns[3].Tag).Text.ToUpper();
            var preco = ((TextBox)Lst_Insumos.Columns[4].Tag).Text.ToUpper();

            var insumos = _appdbContext.Insumos.ToList();

            var result = from i in insumos
                         where
                          (i.Codigo.ToUpper().Contains(codigo) || codigo == "")
                          && (i.Descricao.ToUpper().Contains(descricao) || descricao == "")
                          && (i.Unidade.ToUpper().Contains(unidade) || unidade == "")
                          && (i.OrigemPreco.ToUpper().Contains(origemPreceo) || origemPreceo == "")
                          && (i.Preco.ToString().Contains(preco) || preco == "")
                         select i;
            _insumos = result.Take(250).ToList();

            Insumos_Show();
        }

        private void Insumos_Show()
        {
            Lst_Insumos.Items.Clear();
            foreach (var i in _insumos)
            {
                var item = Lst_Insumos.Items.Add(i.Codigo);
                item.SubItems.Add(i.Descricao);
                item.SubItems.Add(i.Unidade);
                item.SubItems.Add(i.OrigemPreco);
                item.SubItems.Add(i.Preco.ToString());
                item.Tag = i;
            }
        }

        #endregion

        #region Composições Sintéticas

        private List<ComposicaoSintetica> _sinteticas;

        private void Sinteticas_Configure()
        {
            CriarFiltros(Lst_Sinteticas, Pnl_Sinteticas, TbSinteticasFiltro_TextChanged);
            Sinteticas_Load();
            Cbb_Classe.TextChanged += TbSinteticasFiltro_TextChanged;
            Cbb_Tipo.TextChanged += TbSinteticasFiltro_TextChanged;
        }

        private void TbSinteticasFiltro_TextChanged(object sender, EventArgs e)
        {
            Sinteticas_Load();
        }

        private void Sinteticas_Load()
        {
            var classe = Cbb_Classe.Text.ToUpper();
            var tipo = Cbb_Tipo.Text.ToUpper();

            var codigo = ((TextBox)Lst_Sinteticas.Columns[0].Tag).Text.ToUpper();
            var descricao = ((TextBox)Lst_Sinteticas.Columns[1].Tag).Text.ToUpper();
            var unidade = ((TextBox)Lst_Sinteticas.Columns[2].Tag).Text.ToUpper();
            var origemPreceo = ((TextBox)Lst_Sinteticas.Columns[3].Tag).Text.ToUpper();
            var preco = ((TextBox)Lst_Sinteticas.Columns[4].Tag).Text.ToUpper();

            var result = from s in _appdbContext.ComposicoesSinteticas
                         where
                          (s.CodigoComposicao.ToUpper().Contains(codigo) || codigo == "")
                          && (s.DescricaoComposicao.ToUpper().Contains(descricao) || descricao == "")
                          && (s.Unidade.ToUpper().Contains(unidade) || unidade == "")
                          && (s.OrigemPreco.ToUpper().Contains(origemPreceo) || origemPreceo == "")
                          && (s.CustoTotal.ToString().Contains(preco) || preco == "")
                         select s;

            _sinteticas = result.Take(250).ToList();

            Sinteticas_Show();
        }

        private void Sinteticas_Show()
        {
            Lst_Sinteticas.Items.Clear();
            foreach (var s in _sinteticas)
            {
                var item = Lst_Sinteticas.Items.Add(s.CodigoComposicao);
                item.SubItems.Add(s.DescricaoComposicao);
                item.SubItems.Add(s.Unidade);
                item.SubItems.Add(s.OrigemPreco);
                item.SubItems.Add(s.CustoTotal.ToString());
                item.Tag = s;
            }
        }

        #endregion

        #region Funcoes Comuns

        private void Lst_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            ListView lsv = (ListView)sender;
            ColumnHeader col = lsv.Columns[0];
            TextBox tb = (TextBox)col.Tag;
            AjustarLargurasColunas((Panel)tb.Parent);
        }

        private void AjustarLargurasColunas(Panel pnl)
        {
            int left = 0;
            foreach (Control ctrl in pnl.Controls)
            {
                ColumnHeader ch = (ColumnHeader)ctrl.Tag;
                ctrl.Left = left;
                ctrl.Width = ch.Width - 2;
                left += ch.Width;
            }
        }

        private void CriarFiltros(ListView lst, Panel pnl, EventHandler textChanged)
        {
            pnl.Width = lst.Width;
            pnl.Left = lst.Left;
            pnl.Controls.Clear();

            lst.ColumnWidthChanged += Lst_ColumnWidthChanged;

            foreach (ColumnHeader col in lst.Columns)
            {
                var tb = new TextBox();
                pnl.Controls.Add(tb);
                tb.Tag = col;
                col.Tag = tb;
                tb.TextAlign = col.TextAlign;
                tb.TextChanged += textChanged;
            }

            AjustarLargurasColunas(pnl);
        }

        private void LoadComboboxes()
        {
            var classes = _appdbContext.ComposicoesSinteticas.Select(s => s.DescricaoClasse).Distinct().ToList();
            var tipos = _appdbContext.ComposicoesSinteticas.Select(s => s.DescricaoTipo1).Distinct().ToList();
            Cbb_Classe.Items.AddRange(classes.ToArray());
            Cbb_Classe.SelectedIndex = 0;
            Cbb_Tipo.Items.AddRange(tipos.ToArray());
            Cbb_Tipo.SelectedIndex = 0;
        }

        #endregion 
    }
}
