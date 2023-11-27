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
    public partial class Frm_DetalhesComposicao : Form
    {
        private Composicao _composicao;

        public Frm_DetalhesComposicao(Composicao composicao)
        {
            _composicao = composicao;
            InitializeComponent();
            LoadComposicao();
        }

        private void LoadComposicao()
        {
            _composicao.LoadItens();
            Lbl_Descricao.Text = _composicao.DescricaoComposicao;

            Lsv_Itens.Items.Clear();
            if (_composicao.Itens != null)
            {
                foreach (var i in _composicao.Itens)
                {
                    var item = Lsv_Itens.Items.Add(i.ItemTipo);
                    item.SubItems.Add(i.ComposicaoCodigoComposicao);
                    item.SubItems.Add(i.ItemDescricao);
                    item.SubItems.Add(i.ItemUnidade);
                    item.SubItems.Add(i.ItemPrecoUnitario.ToString());
                    item.SubItems.Add(i.ItemCoeficiente.ToString());
                    item.SubItems.Add(i.ItemCustoTotal.ToString());
                    item.Tag = i;
                }
            }
        }

        private void Btn_DetalharComposicao_Click(object sender, EventArgs e)
        {
            var item = (ComposicaoItens)Lsv_Itens.SelectedItems[0].Tag;
            if(!item.ItemTipo.ToUpper().Equals("INSUMO"))
            { 
                var frm = new Frm_DetalhesComposicao(item.Composicao);
                frm.Show();
            }
        }
    }
}
