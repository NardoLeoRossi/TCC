using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Windows.Controls.Primitives;

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
            var itens = AppDbContext.ItensVisaoGrafica.Where(x => x.Nome_Projeto.ToUpper().Equals(ProjetoSelecionado.ToUpper())).ToList();

            //Apagar os dados anteriores
            foreach (ListObject lb in Globals.wsTbDados.ListObjects)
            {
                if (lb.DataBodyRange != null)
                {
                    lb.DataBodyRange.Clear();
                }
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
                dados[i, 1] = item.Nome_Projeto;
                dados[i, 2] = item.Nome_Elemento;
                dados[i, 3] = item.Descricao_Item_Sinapi;
                dados[i, 4] = item.Unidade;
                dados[i, 5] = item.Dimensao_Associada;
                dados[i, 6] = item.Quantidade;
                dados[i, 7] = item.Preco_Unitario;
                dados[i, 8] = item.Preco_Total;
                i++;
            }


            // Descarregar os dados
            Range startCell = Globals.wsTbDados.Cells[2, 1];
            Range endCell = Globals.wsTbDados.Cells[2 + itens.Count - 1 , 9];
            Range writeRange = Globals.wsTbDados.Range[startCell, endCell];
            writeRange.Value2 = dados;

            Globals.ThisWorkbook.RefreshAll();
        }
    }
}
