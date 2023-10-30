using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OrcamentosIfc.Data;

namespace OrcamentosIfc.IFC
{
    public static class LoadProjetos
    {
        public static void LoadProjeto()
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "IFC Files|*.ifc;*.ifczip;*.ifcxml|Xbim Files|*.xbim";
            dlg.Multiselect = false;
            var result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                var newPath = Path.Combine(AppConfiguration.GetProjectsPath(), Path.GetFileName(dlg.FileName));
                if (File.Exists(newPath))
                {
                    if (MessageBox.Show($@"Já existe um projeto chamado {Path.GetFileName(dlg.FileName)} em trabalho. Você deseja substituir ele?") != DialogResult.Yes)
                        return;
                }
                File.Copy(dlg.FileName, newPath, true);
                Rbn_Orcamentos.Instance.LoadCombobox();
            }
        }
    }
}
