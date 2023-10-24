using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using OrcamentosIfc.Data.Models;
using OrcamentosIfc.Data;
using System.Data.OleDb;

namespace OrcamentosIfc.Sinapi
{
    public static class LoadSinapi
    {

        public static void LoadNewSinapi()
        {
            //Solicitar a seleção de uma pasta
            var dlg = new OpenFileDialog();
            dlg.Filter = "zip files|*.zip";
            dlg.Multiselect = false;
            var result = dlg.ShowDialog();

            if (result != DialogResult.OK) return;

            LoadSinapiData(dlg.FileName);
        }

        private static void LoadSinapiData(string pathZip)
        {
            //Criar um lista com os arquivos de excel extraidos
            var destinationPath = Path.GetTempPath();
            var list = new List<string>();
            using (var archive = ZipFile.OpenRead(pathZip))
            {

                foreach (var file in archive.Entries)
                {
                    if (Path.GetExtension(file.FullName).ToUpper().Equals(".XLSX"))
                    {
                        var fullPath = Path.Combine(destinationPath, file.FullName);
                        if (File.Exists(fullPath)) File.Delete(fullPath);
                        file.ExtractToFile(fullPath);
                        list.Add(fullPath);
                    }
                }
            }

            //Definir o prefixo dos arquivos
            var wb = Globals.ThisWorkbook.Application.ActiveWorkbook;
            var prefix = GetPrefix(list.FirstOrDefault());

            //Insumos
            var insumos = list.FirstOrDefault(x => x.ToUpper().Contains("_INSUMOS_"));
            LoadInsumos(insumos, prefix);

            //Composições sintetico
            var compSint = list.FirstOrDefault(x => x.ToUpper().Contains("_COMPOSICOES_SINTETICO_"));
            LoadComposicoesSintetico(compSint, prefix);

            //Composições Analitico
            var compAnal = list.FirstOrDefault(x => x.ToUpper().Contains("_COMPOSICOES_ANALITICO_"));
            LoadComposicoesAnalitico(compAnal, prefix);
        }

        private static string GetPrefix(string fileName)
        {

            var pattern = "[A-Z]{2}_[0-9]{6}";

            var match = Regex.Match(fileName.ToUpper(), pattern);

            if (match.Success)
                return match.Value;
            else
                return "";
        }

        private static void LoadInsumos(string path, string prefix)
        {
            var connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            var dbContext = new AppDbContext();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand($"SELECT * FROM [{GetTableName(conn)}A7:E1048576]", conn);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            var i = new Insumo();
                            i.Codigo = dr[0].ToString();
                            i.Descricao = dr[1].ToString();
                            i.Unidade = dr[2].ToString();
                            i.OrigemPreco = dr[3].ToString();
                            i.Preco = Convert.ToDecimal(dr[4].ToString());
                            i.Prefixo = prefix;
                            dbContext.Insumos.Add(i);
                        }
                    }
                    dbContext.SaveChanges();
                }
            }
        }

        private static void LoadComposicoesSintetico(string path, string prefix)
        {
            var connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            var dbContext = new AppDbContext();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand($"SELECT * FROM [{GetTableName(conn)}A7:L1048576]", conn);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            var c = new ComposicaoSintetica();
                            c.DescricaoClasse = dr[0].ToString();
                            c.SiglaClasse = dr[1].ToString();
                            c.DescricaoTipo1 = dr[2].ToString();
                            c.SiglaTipo1 = dr[3].ToString();
                            c.CodigoAgrupador = dr[4].ToString();
                            c.DescricaoAgrupador = dr[5].ToString();
                            c.CodigoComposicao= dr[6].ToString();
                            c.DescricaoComposicao = dr[7].ToString();
                            c.Unidade = dr[8].ToString();
                            c.OrigemPreco = dr[9].ToString();
                            c.CustoTotal = Convert.ToDecimal(dr[10].ToString());
                            c.Vinculo = dr[11].ToString();
                            c.Prefixo = prefix;

                            dbContext.ComposicoesSinteticas.Add(c);
                        }
                    }
                    dbContext.SaveChanges();
                }
            }
        }

        private static void LoadComposicoesAnalitico(string path, string prefix)
        {
            var connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            var dbContext = new AppDbContext();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand($"SELECT * FROM [{GetTableName(conn)}A7:AE1048576]", conn);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            var c = new ComposicaoAnalitica();
                            c.DescricaoClasse = dr[0].ToString();
                            c.SiglaClasse = dr[1].ToString();
                            c.DescricaoTipo1 = dr[2].ToString();
                            c.SiglaTipo1 = dr[3].ToString();
                            c.CodigoAgrupador = dr[4].ToString();
                            c.DescricaoAgrupador = dr[5].ToString();
                            c.CodigoComposicao = dr[6].ToString();
                            c.DescricaoComposicao = dr[7].ToString();
                            c.Unidade = dr[8].ToString();
                            c.OrigemPreco = dr[9].ToString();
                            if (!dr.IsDBNull(10)) c.CustoTotal = Convert.ToDecimal(dr[10].ToString());
                            c.ItemTipo= dr[11].ToString();
                            c.ItemCodigo= dr[12].ToString();
                            c.ItemDescricao= dr[13].ToString();
                            c.ItemUnidade= dr[14].ToString();
                            c.ItemOrigemPreco= dr[15].ToString();
                            if (!dr.IsDBNull(16)) c.ItemPrecoUnitario = Convert.ToDecimal(dr[16].ToString());
                            if (!dr.IsDBNull(17)) c.ItemCustoTotal= Convert.ToDecimal(dr[17].ToString());
                            c.Prefixo = prefix;
                            c.Vinculo = dr[30].ToString();

                            dbContext.ComposicoesAnaliticas.Add(c);
                        }
                    }
                    dbContext.SaveChanges();
                }
            }
        }

        private static string GetTableName(OleDbConnection conn)
        {
            var dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            return dt.Rows[0]["TABLE_NAME"].ToString().Replace("'", "");
        }
    }
}
