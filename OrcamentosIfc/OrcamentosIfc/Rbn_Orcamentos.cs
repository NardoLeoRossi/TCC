using Microsoft.Office.Core;
using MoreLinq;
using OrcamentosIfc.Forms;
using OrcamentosIfc.Sinapi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;


namespace OrcamentosIfc
{
    [ComVisible(true)]
    public class Rbn_Orcamentos : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private AppDbContext _appDbContext;

        public Rbn_Orcamentos()
        {
            _appDbContext = new AppDbContext();
            LoadCombobox();
        }

        private List<string> _periodos;

        private void LoadCombobox()
        {
            _periodos = _appDbContext.Insumos
                                .Select(x => x.Prefixo)
                                .DistinctBy(x => x.ToString())
                                .ToList()
                                .OrderBy(x => x.ToString())
                                .ToList();
        }

        public int Cbb_PeriodoSinapi_GetItemCount(IRibbonControl control)
        {
            return _periodos.Count;
        }

        public string Cbb_PeriodoSinapi_GetItemLabel(IRibbonControl control, int index)
        {
            return _periodos[index];
        }

        public void Cbb_PeriodoSinapi_OnChange(IRibbonControl control, string text)
        {
            Parametros.PeriodoSinapi = text;
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
