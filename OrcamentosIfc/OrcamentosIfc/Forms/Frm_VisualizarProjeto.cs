using MoreLinq.Extensions;
using OrcamentosIfc.Data;
using OrcamentosIfc.Data.Interfaces;
using OrcamentosIfc.Data.Models;
using OrcamentosIfc.IFC;
using OrcamentosIfc.Sinapi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xbim.Common;
using Xbim.Ifc;
using Xbim.ModelGeometry.Scene;

namespace OrcamentosIfc.Forms
{
    public partial class Frm_VisualizarProjeto : Form
    {

        private WinformsAccessibleControl _wpfControl;

        private IPersistEntity _entidadeSelecionada;

        public Frm_VisualizarProjeto()
        {
            InitializeComponent();

            _wpfControl = new WinformsAccessibleControl();
            _wpfControl.SelectionChanged += _wpfControl_SelectionChanged;
            ControlHost.Child = _wpfControl;

            ifcMetaDataControl1 = new Xbim.Presentation.IfcMetaDataControl();
        }

        private void Frm_VisualizarProjeto_Load(object sender, EventArgs e)
        {
            LoadProjetoModel();
        }

        private void LoadProjetoModel()
        {
            var path = Path.Combine(AppConfiguration.GetProjectsPath(), Parametros.ProjetoSelecionado);
            var model = IfcStore.Open(path);
            var context = new Xbim3DModelContext(model);
            context.CreateContext();
            _wpfControl.ModelProvider.ObjectInstance = model;
            ifcMetaDataControl1.Model = model;
        }

        private void _wpfControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _entidadeSelecionada = e.AddedItems[0] as IPersistEntity;
            RefreshItens();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new Frm_SelecionarItemsSinapi();
            frm.ItemSelecionado += Frm_ItemSelecionado;
            frm.Show();
        }

        private void Frm_ItemSelecionado(object sender, Utils.CustomEventArgsItemSinapiSelecionado e)
        {
            var projeto = Parametros.ProjetoSelecionado;
            var ifcId = _wpfControl.SelectedElement.EntityLabel.ToString();

            //Carregar o elemento projeto
            var elemento = Parametros.AppDbContext.ElementosProjeto.FirstOrDefault(x => x.IfcId.ToUpper() == ifcId.ToUpper() && x.NomeProjeto.ToUpper() == projeto.ToUpper());
            if (elemento == null)
            {
                elemento = new ElementoProjeto();
                elemento.IfcId = ifcId;
                elemento.NomeProjeto = projeto;
                Parametros.AppDbContext.ElementosProjeto.Add(elemento);
                Parametros.AppDbContext.SaveChanges();
            }

            elemento.AddItemCusto(e.Tag as IItemSinapi, e.Qntd);

            RefreshItens();
        }

        private void RefreshItens()
        {
            Lsv_CustosElemento.Items.Clear();
            Lbl_CustoTotal.Text = "Custo Total R$ 0,00";

            if (_entidadeSelecionada == null) return;

            var projeto = Parametros.ProjetoSelecionado;
            var ifcId = _entidadeSelecionada.EntityLabel.ToString();
            var elemento = Parametros.AppDbContext.ElementosProjeto.FirstOrDefault(x => x.IfcId.ToUpper() == ifcId.ToUpper() && x.NomeProjeto.ToUpper() == projeto.ToUpper());
            if (elemento == null) return;

            elemento.LoadCustos();

            decimal custoTotal = 0;

            if (elemento.Insumos != null)
                foreach (var item in elemento.Insumos)
                {
                    var i = new ListViewItem("Insumo");
                    i.Tag = item;
                    i.SubItems.Add(item.Insumo.Descricao);
                    i.SubItems.Add(item.Insumo.Preco.ToString());
                    i.SubItems.Add(item.Quantidade.ToString());
                    i.SubItems.Add((item.Insumo.Preco * item.Quantidade).ToString());

                    custoTotal += item.Insumo.Preco * item.Quantidade;

                    Lsv_CustosElemento.Items.Add(i);
                }

            if (elemento.ComposicoesAnaliticas != null)
                foreach (var item in elemento.ComposicoesAnaliticas)
                {
                    var i = new ListViewItem("Composição Analitica");
                    i.Tag = item;
                    i.SubItems.Add(item.ComposicaoAnalitica.DescricaoComposicao);
                    i.SubItems.Add(item.ComposicaoAnalitica.CustoTotal.ToString());
                    i.SubItems.Add(item.Quantidade.ToString());
                    i.SubItems.Add((item.ComposicaoAnalitica.CustoTotal * item.Quantidade).ToString());

                    custoTotal += item.ComposicaoAnalitica.CustoTotal * item.Quantidade;

                    Lsv_CustosElemento.Items.Add(i);
                }

            if (elemento.ComposicoesSinteticas != null)
                foreach (var item in elemento.ComposicoesSinteticas)
                {
                    var i = new ListViewItem("Composição Sintética");
                    i.Tag = item;
                    i.SubItems.Add(item.ComposicaoSintetica.DescricaoComposicao);
                    i.SubItems.Add(item.ComposicaoSintetica.CustoTotal.ToString());
                    i.SubItems.Add(item.Quantidade.ToString());
                    i.SubItems.Add((item.ComposicaoSintetica.CustoTotal * item.Quantidade).ToString());

                    custoTotal += item.ComposicaoSintetica.CustoTotal * item.Quantidade;

                    Lsv_CustosElemento.Items.Add(i);
                }

            Lbl_CustoTotal.Text = "Custo Total R$ " + custoTotal.ToString();
        }

        private void Btn_RemoverCusto_Click(object sender, EventArgs e)
        {
            if (Lsv_CustosElemento.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione os Itens que desejas remover", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_entidadeSelecionada == null) return;

            var projeto = Parametros.ProjetoSelecionado;
            var ifcId = _entidadeSelecionada.EntityLabel.ToString();

            var elemento = Parametros.AppDbContext.ElementosProjeto.FirstOrDefault(x => x.IfcId.ToUpper() == ifcId.ToUpper() && x.NomeProjeto.ToUpper() == projeto.ToUpper());
            if (elemento == null) return;

            foreach (ListViewItem item in Lsv_CustosElemento.SelectedItems)
            {
                elemento.RemoveCusto(item.Tag);
            }
            RefreshItens();
        }
    }
}

