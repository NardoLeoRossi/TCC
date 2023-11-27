using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Windows.Controls.Primitives;
using OrcamentosIfc.Data.Models;

namespace OrcamentosIfc
{
    public static class Parametros
    {
        private static AppDbContext _dbContext;

        public static string _periodoSinapiSelecionado;

        public static string _projetoSelecionado;

        public static string PeriodoSinapiSelecionado
        {
            get => _periodoSinapiSelecionado;
            set
            {
                _periodoSinapiSelecionado = value;
                AtualizarVisaoGrafica();
            }
        }

        public static string ProjetoSelecionado
        {
            get => _projetoSelecionado;
            set
            {
                _projetoSelecionado = value;
                AtualizarVisaoGrafica();
            }
        }

        public static AppDbContext AppDbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new AppDbContext();
                }
                return _dbContext;
            }
        }

        public static void AtualizarVisaoGrafica()
        {

            //Apagar os dados anteriores
            foreach (ListObject lb in Globals.wsTbDados.ListObjects)
            {
                if (lb.DataBodyRange != null)
                {
                    lb.DataBodyRange.Clear();
                }
            }
            Globals.ThisWorkbook.RefreshAll();

            List<VisaoGrafica> itens;
            try
            {
                itens = AppDbContext.ItensVisaoGrafica.ToList();
                itens = itens.Where(x => x.NomeProjeto == ProjetoSelecionado && x.Prefixo == PeriodoSinapiSelecionado).ToList();
            }
            catch
            {
                return;
            }

            if (itens.Count == 0)
            {
                Globals.ThisWorkbook.RefreshAll();
                return;
            }

            object[,] dados = new object[itens.Count, 9];
            var i = 0;

            //Montar a matriz de dados
            foreach (var item in itens)
            {
                dados[i, 0] = item.Tipo;
                dados[i, 1] = item.NomeProjeto;
                dados[i, 2] = item.NomeElementoIfc;
                dados[i, 3] = item.Descricao;
                dados[i, 4] = item.Unidade;
                dados[i, 5] = item.Dimensao;
                dados[i, 6] = item.Quantidade;
                dados[i, 7] = item.Preco;
                dados[i, 8] = item.PrecoTotal;
                i++;
            }

            // Descarregar os dados
            Range startCell = Globals.wsTbDados.Cells[2, 1];
            Range endCell = Globals.wsTbDados.Cells[2 + itens.Count - 1 , 9];
            Range writeRange = Globals.wsTbDados.Range[startCell, endCell];

            try
            {
                writeRange.Value2 = dados;
            }
            catch (Exception ex)
            {
                try
                {
                    writeRange.Value2 = dados;
                }
                catch (Exception e){}
            }

            Globals.ThisWorkbook.RefreshAll();
        }
    }
}
