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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Xbim.Common;
using Xbim.Ifc;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.QuantityResource;
using Xbim.Ifc2x3.StructuralElementsDomain;
using Xbim.ModelGeometry.Scene;
using Xbim.Geometry;
using Xbim.Common.Geometry;
using Xbim.Geometry.Engine.Interop;
using Xbim.Ifc2x3.Interfaces;
using OrcamentosIfc.Utils;
using Microsoft.EntityFrameworkCore;

namespace OrcamentosIfc.Forms
{
    public partial class Frm_VisualizarProjeto : Form
    {

        private WinformsAccessibleControl _wpfControl;

        private IPersistEntity _entidadeSelecionada;

        private IIfcElement _elementoSelecionado;

        private IfcStore _model;

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
            _model = IfcStore.Open(path);
            var context = new Xbim3DModelContext(_model);
            context.CreateContext();
            _wpfControl.ModelProvider.ObjectInstance = _model;
            ifcMetaDataControl1.Model = _model;
        }

        private void _wpfControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _entidadeSelecionada = e.AddedItems[0] as IPersistEntity;
            _elementoSelecionado = e.AddedItems[0] as IIfcElement;

            //CarregarPropriedades(_elementoSelecionado);

            if (_entidadeSelecionada != null)
            {
                OnItemSelecionado(new CostumEventArgsElementoIfcSelecionado(_elementoSelecionado, _model));
            }

            if (_elementoSelecionado != null)
                Txt_NomeElemento.Text = _elementoSelecionado.Name;
            else
                Txt_NomeElemento.Text = string.Empty;

            RefreshItens();
        }

        //private void CarregarPropriedades(IIfcElement element)
        //{
        //    if (element == null) return;

        //    var context = new Xbim3DModelContext(_model);
        //    context.CreateContext();

        //    foreach (var item in context.ShapeInstances())
        //    {
        //        if (item.IfcProductLabel == element.EntityLabel)
        //        {
        //            Debug.Print($"GlobalID: {element.GlobalId}");
        //            Debug.Print($"EntityLabel: {element.EntityLabel}");
        //            Debug.Print($"Volume: {item.BoundingBox.Volume.ToString()}");
        //            Debug.Print($"X: {item.BoundingBox.SizeX.ToString()}");
        //            Debug.Print($"Y: {item.BoundingBox.SizeY.ToString()}");
        //            Debug.Print($"Z: {item.BoundingBox.SizeZ.ToString()}");
        //        }
        //    }

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new Frm_SelecionarItemsSinapi();
            frm.ItemSelecionado += Frm_ItemSelecionado;
            this.ElementoSelecionadoChange += frm.ElementoSelecionadoChange;
            frm.Show();
            if (_entidadeSelecionada != null)
            {
                OnItemSelecionado(new CostumEventArgsElementoIfcSelecionado(_elementoSelecionado, _model));
            }
        }

        private void Frm_ItemSelecionado(object sender, Utils.CustomEventArgsItemSinapiSelecionado e)
        {
            var projeto = Parametros.ProjetoSelecionado;
            var elementIfc = _wpfControl.SelectedElement as IIfcElement;

            if (elementIfc == null) return;

            var ifcId = elementIfc.GlobalId.ToString();
            var ifcName = elementIfc.Name;

            //Carregar o elemento projeto
            var elemento = Parametros.AppDbContext.ElementosProjeto.FirstOrDefault(x => x.IfcId.ToUpper() == ifcId.ToUpper() && x.NomeProjeto.ToUpper() == projeto.ToUpper());
            if (elemento == null)
            {
                elemento = new ElementoProjeto();
                elemento.IfcId = ifcId;
                elemento.NomeElementoIfc = ifcName;
                elemento.NomeProjeto = projeto;
                Parametros.AppDbContext.ElementosProjeto.Add(elemento);
                Parametros.AppDbContext.SaveChanges();
            }

            elemento.AddItemCusto(e.Tag as IItemSinapi, e.Dimensao, (decimal)e.Qntd);

            RefreshItens();
        }

        private void RefreshItens()
        {
            Lsv_CustosElemento.Items.Clear();
            Lbl_CustoTotal.Text = "Custo Total R$ 0,00";

            if (_entidadeSelecionada == null) return;

            var projeto = Parametros.ProjetoSelecionado;
            var ifcId = _elementoSelecionado.GlobalId.ToString();
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
                    i.SubItems.Add(item.Dimensao);
                    i.SubItems.Add(item.Quantidade.ToString());
                    i.SubItems.Add((item.Insumo.Preco * item.Quantidade).ToString());

                    custoTotal += item.Insumo.Preco * item.Quantidade;

                    Lsv_CustosElemento.Items.Add(i);
                }

            if (elemento.Composicoes != null)
                foreach (var item in elemento.Composicoes)
                {
                    var i = new ListViewItem("Composição");
                    i.Tag = item;
                    i.SubItems.Add(item.Composicao.DescricaoComposicao);
                    i.SubItems.Add(item.Composicao.CustoTotal.ToString());
                    i.SubItems.Add(item.Dimensao);
                    i.SubItems.Add(item.Quantidade.ToString());
                    i.SubItems.Add((item.Composicao.CustoTotal * item.Quantidade).ToString());

                    custoTotal += item.Composicao.CustoTotal * item.Quantidade;

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
            var ifcId = _elementoSelecionado.GlobalId.ToString();

            var elemento = Parametros.AppDbContext.ElementosProjeto.FirstOrDefault(x => x.IfcId.ToUpper() == ifcId.ToUpper() && x.NomeProjeto.ToUpper() == projeto.ToUpper());
            if (elemento == null) return;

            foreach (ListViewItem item in Lsv_CustosElemento.SelectedItems)
            {
                elemento.RemoveCusto(item.Tag);
            }
            RefreshItens();
            Parametros.AtualizarVisaoGrafica();
        }

        public delegate void ItemSelecionadoEventArgs(object sender, CostumEventArgsElementoIfcSelecionado e);

        public event ItemSelecionadoEventArgs ElementoSelecionadoChange;

        protected virtual void OnItemSelecionado(CostumEventArgsElementoIfcSelecionado e)
        {
            var handler = ElementoSelecionadoChange;
            if (handler != null) handler(this, e);
        }

        private void Txt_NomeElemento_Leave(object sender, EventArgs e)
        {
            using (var tr = _model.BeginTransaction("Adicionar Propriedade"))
            {
                var element = _model.Instances.FirstOrDefault<IfcElement>(x => x.GlobalId == _elementoSelecionado.GlobalId);

                if (element != null)
                {
                    if (element.Name != Txt_NomeElemento.Text)
                    {
                        element.Name = Txt_NomeElemento.Text;
                        _elementoSelecionado.Name = Txt_NomeElemento.Text;
                        tr.Commit();

                        var path = Path.Combine(AppConfiguration.GetProjectsPath(), Parametros.ProjetoSelecionado);
                        _model.SaveAs(path);

                        var sql = $@"
                                UPDATE ElementosProjeto SET 
                                    NomeElementoIfc = '{Txt_NomeElemento.Text}'
                                    WHERE
                                        IfcId = '{element.GlobalId}'";

                        Parametros.AppDbContext.Database.ExecuteSqlRaw(sql);
                        Parametros.AppDbContext.SaveChanges();
                    }
                }
            }
        }

        private void Frm_VisualizarProjeto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Parametros.AtualizarVisaoGrafica();
        }
    }
}
