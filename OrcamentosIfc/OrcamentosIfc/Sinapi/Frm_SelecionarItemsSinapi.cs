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
using System.Windows.Media.Animation;
using MoreLinq;
using System.IO.Packaging;
using OrcamentosIfc.Utils;

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
            LBL_Referência.Text = Parametros.PeriodoSinapiSelecionado;
            Insumos_Configure();
            Sinteticas_Configure();
            Analiticas_Configure();
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
                         (i.Prefixo == Parametros.PeriodoSinapiSelecionado)
                          && (i.Codigo.ToUpper().Contains(codigo) || codigo == "")
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

        private void Btn_InsumosAdd_Click(object sender, EventArgs e)
        {
            if (Lst_Insumos.SelectedItems.Count == 0) return;
            var insumo = (Insumo)Lst_Insumos.SelectedItems[0].Tag;
            OnItemSelecionado(new CustomEventArgs(insumo));
        }

        #endregion

        #region Composições Sintéticas

        private List<ComposicaoSintetica> _sinteticas;

        private void Sinteticas_Configure()
        {
            CriarFiltros(Lst_Sinteticas, Pnl_Sinteticas, TbSinteticasFiltro_TextChanged);
            Sinteticas_Load();
            Cbb_SinteticaClasse.TextChanged += TbSinteticasFiltro_TextChanged;
            Cbb_SinteticaTipo.TextChanged += TbSinteticasFiltro_TextChanged;
        }

        private void TbSinteticasFiltro_TextChanged(object sender, EventArgs e)
        {
            Sinteticas_Load();
        }

        private void Sinteticas_Load()
        {
            var classe = Cbb_SinteticaClasse.Text.ToUpper();
            var tipo = Cbb_SinteticaTipo.Text.ToUpper();

            var codigo = ((TextBox)Lst_Sinteticas.Columns[0].Tag).Text.ToUpper();
            var descricao = ((TextBox)Lst_Sinteticas.Columns[1].Tag).Text.ToUpper();
            var unidade = ((TextBox)Lst_Sinteticas.Columns[2].Tag).Text.ToUpper();
            var origemPreceo = ((TextBox)Lst_Sinteticas.Columns[3].Tag).Text.ToUpper();
            var preco = ((TextBox)Lst_Sinteticas.Columns[4].Tag).Text.ToUpper();

            var result = from s in _appdbContext.ComposicoesSinteticas
                         where
                            (s.Prefixo == Parametros.PeriodoSinapiSelecionado)
                            && s.DescricaoClasse.ToUpper() == classe
                            && s.DescricaoTipo1.ToUpper() == tipo
                            && (s.CodigoComposicao.ToUpper().Contains(codigo) || codigo == "")
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

        private void Btn_SinteticasAdd_Click(object sender, EventArgs e)
        {
            if (Lst_Sinteticas.SelectedItems.Count == 0) return;
            var comp = (ComposicaoSintetica)Lst_Sinteticas.SelectedItems[0].Tag;
            OnItemSelecionado(new CustomEventArgs(comp));
        }

        #endregion

        #region Composições analiticas

        private List<ComposicaoAnalitica> _analiticas;

        private void Analiticas_Configure()
        {
            CriarFiltros(Lst_Analiticas, Pnl_Analiticas, TbAnaliticasFiltro_TextChanged);
            Analiticas_Load();
            Cbb_AnaliticaClasse.TextChanged += TbAnaliticasFiltro_TextChanged;
            Cbb_AnaliticaTipo.TextChanged += TbAnaliticasFiltro_TextChanged;
        }

        private void TbAnaliticasFiltro_TextChanged(object sender, EventArgs e)
        {
            Analiticas_Load();
        }

        private void Analiticas_Load()
        {
            var classe = Cbb_AnaliticaClasse.Text.ToUpper();
            var tipo = Cbb_AnaliticaTipo.Text.ToUpper();

            var codigo = ((TextBox)Lst_Analiticas.Columns[0].Tag).Text.ToUpper();
            var descricao = ((TextBox)Lst_Analiticas.Columns[1].Tag).Text.ToUpper();
            var unidade = ((TextBox)Lst_Analiticas.Columns[2].Tag).Text.ToUpper();
            var origemPreceo = ((TextBox)Lst_Analiticas.Columns[3].Tag).Text.ToUpper();
            var preco = ((TextBox)Lst_Analiticas.Columns[4].Tag).Text.ToUpper();

            var result = from s in _appdbContext.ComposicoesAnaliticas
                         where
                            (s.Prefixo == Parametros.PeriodoSinapiSelecionado)
                            && s.DescricaoClasse.ToUpper() == classe
                            && s.DescricaoTipo1.ToUpper() == tipo
                            && (s.CodigoComposicao.ToUpper().Contains(codigo) || codigo == "")
                            && (s.DescricaoComposicao.ToUpper().Contains(descricao) || descricao == "")
                            && (s.Unidade.ToUpper().Contains(unidade) || unidade == "")
                            && (s.OrigemPreco.ToUpper().Contains(origemPreceo) || origemPreceo == "")
                            && (s.CustoTotal.ToString().Contains(preco) || preco == "")
                         select s;

            _analiticas = result.DistinctBy(c => c.CodigoComposicao).Take(250).ToList();

            Analiticas_Show();
        }

        private void Analiticas_Show()
        {
            Lst_Analiticas.Items.Clear();
            foreach (var s in _analiticas)
            {
                var item = Lst_Analiticas.Items.Add(s.CodigoComposicao);
                item.SubItems.Add(s.DescricaoComposicao);
                item.SubItems.Add(s.Unidade);
                item.SubItems.Add(s.OrigemPreco);
                item.SubItems.Add(s.CustoTotal.ToString());
                item.Tag = s;
            }
        }

        private void Btn_AnaliticasAdd_Click(object sender, EventArgs e)
        {
            if (Lst_Analiticas.SelectedItems.Count == 0) return;
            var comp = (ComposicaoAnalitica)Lst_Analiticas.SelectedItems[0].Tag;
            OnItemSelecionado(new CustomEventArgs(comp));
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
            Cbb_SinteticaClasse.SelectedIndexChanged += LoadComboboxTipo;
            Cbb_AnaliticaClasse.SelectedIndexChanged += LoadComboboxTipo;

            Cbb_SinteticaClasse.Tag = Cbb_SinteticaTipo;
            Cbb_AnaliticaClasse.Tag = Cbb_AnaliticaTipo;

            //Criar tupla sinteticas
            var tuplaS = _appdbContext.ComposicoesSinteticas
                            .Select(s => Tuple.Create(s.DescricaoClasse, s.DescricaoTipo1));
            var classesS = tuplaS
                                .Select(s => s.Item1)
                                .DistinctBy(s => s.ToString())
                                .ToList()
                                .OrderBy(s => s.ToString());
            Cbb_SinteticaClasse.Items.AddRange(classesS.ToArray());
            Cbb_SinteticaTipo.Tag = tuplaS.ToList();

            //Criar tupla analiticas
            var tuplaA = _appdbContext.ComposicoesAnaliticas
                            .Select(a => Tuple.Create(a.DescricaoClasse, a.DescricaoTipo1));
            var classesA = tuplaA
                                .Select(a => a.Item1)
                                .DistinctBy(a => a.ToString())
                                .ToList()
                                .OrderBy(a => a.ToString());
            Cbb_AnaliticaClasse.Items.AddRange(classesA.ToArray());
            Cbb_AnaliticaTipo.Tag = tuplaA.ToList();

            Cbb_SinteticaClasse.SelectedIndex = 0;
            Cbb_AnaliticaClasse.SelectedIndex = 0;
        }

        private void LoadComboboxTipo(object sender, EventArgs e)
        {
            var cbClasse = (ComboBox)sender;
            var cb = (ComboBox)cbClasse.Tag;
            var tuple = (List<Tuple<string, string>>)cb.Tag;

            var t = (from c in tuple
                     where
                        c.Item1 == cbClasse.Text.ToString()
                     select c)
                    .Select(c => c.Item2)
                    .Distinct()
                    .ToList();

            t = t.OrderBy(c => c.ToString()).ToList();

            cb.Items.Clear();
            cb.Items.AddRange(t.ToArray());
            cb.SelectedIndex = -1;
            if (cb.Items.Count > 0) cb.SelectedIndex = 0;
        }

        #endregion

        public delegate void ItemSelecionadoEventArgs(object sender, CustomEventArgs e);

        public event ItemSelecionadoEventArgs ItemSelecionado;

        protected virtual void OnItemSelecionado(CustomEventArgs e)
        {
            var handler = ItemSelecionado;
            if (handler != null) handler(this, e);
        }
    }
}
