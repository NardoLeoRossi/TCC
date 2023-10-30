using OrcamentosIfc.Data;
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

        public Frm_VisualizarProjeto()
        {
            InitializeComponent();

            _wpfControl = new WinformsAccessibleControl();
            _wpfControl.SelectionChanged += _wpfControl_SelectionChanged;
            ControlHost.Child = _wpfControl;

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
            var ent = e.AddedItems[0] as IPersistEntity;
            if (ent == null)
                label1.Text = "";
            else
            {
                ifcMetaDataControl1.SelectedEntity = ent;
                label1.Text = ent.EntityLabel.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new Frm_SelecionarItemsSinapi();
            frm.Show();
        }
    }
}

