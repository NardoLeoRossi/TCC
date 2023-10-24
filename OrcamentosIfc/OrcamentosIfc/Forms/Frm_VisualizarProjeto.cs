using OrcamentosIfc.Sinapi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        int starting = -1;

        public Frm_VisualizarProjeto()
        {
            InitializeComponent();

            _wpfControl = new WinformsAccessibleControl();
            _wpfControl.SelectionChanged += _wpfControl_SelectionChanged;
            ControlHost.Child = _wpfControl;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "IFC Files|*.ifc;*.ifczip;*.ifcxml|Xbim Files|*.xbim";
            dlg.Multiselect = false;
            var result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                var model = IfcStore.Open(dlg.FileName);

                var context = new Xbim3DModelContext(model);
                context.CreateContext();

                _wpfControl.ModelProvider.ObjectInstance = model;

                ifcMetaDataControl1.Model = model;
            }
        }

        private void ControlHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new Frm_SelecionarItemsSinapi();
            frm.Show();
        }
    }
}

