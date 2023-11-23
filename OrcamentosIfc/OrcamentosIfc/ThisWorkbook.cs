using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using OrcamentosIfc.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace OrcamentosIfc
{
    public partial class ThisWorkbook
    {

        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
            //Criação do banco de dados
            AppConfiguration.CreateDataBaseSqlLite();            
            
            //Ajustar nomes das planilhas
            Globals.wsVisaoGrafica.Name = "Visão Gráfica";
            Globals.wsTbd.Name = "Tabelas dinâmicas";
            Globals.wsTbDados.Name = "Base de Dados";
        }

        private void ThisWorkbook_Shutdown(object sender, System.EventArgs e)
        {
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Rbn_Orcamentos();
        }

        #region Código gerado pelo Designer VSTO

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisWorkbook_Startup);
            this.Shutdown += new System.EventHandler(ThisWorkbook_Shutdown);
        }

        #endregion

    }
}
