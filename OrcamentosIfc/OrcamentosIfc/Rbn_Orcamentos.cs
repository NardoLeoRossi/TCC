using OrcamentosIfc.Forms;
using OrcamentosIfc.Sinapi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;


namespace OrcamentosIfc
{
    [ComVisible(true)]
    public class Rbn_Orcamentos : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public Rbn_Orcamentos()
        {
        }
        public void Btn_LoadProejto_Click(Office.IRibbonControl control)
        {
            var frm = new Frm_VisualizarProjeto();
            frm.ShowDialog();
        }

        public void Btn_LoadSinapi_Click(Office.IRibbonControl control)
        {
            LoadSinapi.LoadNewSinapi();
        }

        #region Membros de IRibbonExtensibility

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("OrcamentosIfc.Rbn_Orcamentos.xml");
        }

        #endregion

        #region Retornos de Chamada da Faixa de Opções
        //Crie métodos de retorno de chamada aqui. Para obter mais informações sobre como adicionar métodos de retorno de chamada, visite https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Auxiliares

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
