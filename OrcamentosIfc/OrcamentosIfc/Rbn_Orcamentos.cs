using Microsoft.Office.Core;
using MoreLinq;
using OrcamentosIfc.Data;
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
using OrcamentosIfc.IFC;

namespace OrcamentosIfc
{
    [ComVisible(true)]
    public class Rbn_Orcamentos : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private AppDbContext _appDbContext;

        public static Rbn_Orcamentos Instance;

        public Rbn_Orcamentos()
        {
            _appDbContext = new AppDbContext();
            Instance = this;
            LoadCombobox();
        }

        public void LoadCombobox()
        {
            LoadPeriodos();
            LoadProjetos();
        }

        #region SINAPI selecionado

        private List<string> _periodosSinapi;

        private void LoadPeriodos()
        {
            if (File.Exists(AppConfiguration.GetDataBasePath()))
            {
                _periodosSinapi = _appDbContext.Insumos
                                    .Select(x => x.Prefixo)
                                    .DistinctBy(x => x.ToString())
                                    .ToList()
                                    .OrderBy(x => x.ToString())
                                    .ToList();
            }
        }

        public int Cbb_PeriodoSinapi_GetItemCount(IRibbonControl control)
        {
            if (_periodosSinapi == null)
                return 0;
            return _periodosSinapi.Count;
        }

        public string Cbb_PeriodoSinapi_GetItemLabel(IRibbonControl control, int index)
        {
            if (_periodosSinapi == null)
                return "";
            return _periodosSinapi[index];
        }

        public void Cbb_PeriodoSinapi_OnChange(IRibbonControl control, string text)
        {
            Parametros.PeriodoSinapiSelecionado = text;
        }

        #endregion

        #region Projeto Selecionado

        private List<string> _projetos;

        private void LoadProjetos()
        {
            _projetos = new List<string>();
            var path = AppConfiguration.GetProjectsPath();
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if(Path.GetExtension(file).ToUpper().Equals(".IFC"))
                {
                    _projetos.Add(Path.GetFileName(file));
                }
            }
        }

        public int Cbb_ProjetoSelecionado_GetItemCount(IRibbonControl control)
        {
            if (_projetos == null)
                return 0;
            return _projetos.Count;
        }

        public string Cbb_ProjetoSelecionado_GetItemLabel(IRibbonControl control, int index)
        {
            if (_projetos == null)
                return "";
            return _projetos[index];
        }

        public void Cbb_ProjetoSelecionado_OnChange(IRibbonControl control, string text)
        {
            Parametros.ProjetoSelecionado = text;
        }

        #endregion

        public void Btn_LoadSinapi_Click(Office.IRibbonControl control)
        {
            LoadSinapi.LoadNewSinapi();
        }

        public void Btn_LoadProejto_Click(Office.IRibbonControl control)
        {
            OrcamentosIfc.IFC.LoadProjetos.LoadProjeto();
        }

        public void Btn_CustearElementos_Click(Office.IRibbonControl control)
        {
            var frm = new Frm_VisualizarProjeto();
            frm.ShowDialog();
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
