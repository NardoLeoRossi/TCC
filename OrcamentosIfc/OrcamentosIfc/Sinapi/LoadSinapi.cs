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
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Data;

namespace OrcamentosIfc.Sinapi
{
    public static class LoadSinapi
    {
        private static int _qntdInsumos = 0;
        private static int _qntdSintetico = 0;

        public static void LoadNewSinapi()
        {
            //Solicitar a seleção de uma pasta
            var dlg = new OpenFileDialog();
            dlg.Filter = "zip files|*.zip";
            dlg.Multiselect = false;
            var result = dlg.ShowDialog();

            if (result != DialogResult.OK) return;

            LoadSinapiData(dlg.FileName);
            Rbn_Orcamentos.Instance.LoadCombobox();

            MessageBox.Show($"Processo Concluído.\n" +
                $"Insumos: {_qntdInsumos} Registro Importados\n" +
                $"Composições: {_qntdSintetico} Registros Importados\n",
                "Orçamentos IFC",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
                    if (Path.GetExtension(file.FullName).ToUpper().Equals(".XLSX") || Path.GetExtension(file.FullName).ToUpper().Equals(".XLS"))
                    {
                        var fullPath = Path.Combine(destinationPath, file.FullName);
                        if (File.Exists(fullPath)) File.Delete(fullPath);
                        file.ExtractToFile(fullPath);
                        list.Add(fullPath);
                    }
                }
            }

            //Insumos
            var insumos = list.FirstOrDefault(x => x.ToUpper().Contains("REF_INSUMOS_"));
            var prefix = GetPrefix(insumos);
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
            _qntdInsumos = 0;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                var rowsSize = Path.GetExtension(path).ToUpper().Equals("XLSX") ? "1048576" : "65536";

                conn.Open();
                OleDbCommand cmd = new OleDbCommand($"SELECT * FROM [{GetTableName(conn)}A7:E{rowsSize}]", conn);
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
                            _qntdInsumos++;
                        }
                    }

                    dbContext.Database.ExecuteSqlRaw($"DELETE FROM Insumos WHERE PREFIXO = '{prefix}'");
                    dbContext.SaveChanges();
                }
            }
        }

        private static void LoadComposicoesSintetico(string path, string prefix)
        {
            var connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            var dbContext = new AppDbContext();
            _qntdSintetico = 0;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                var rowsSize = Path.GetExtension(path).ToUpper().Equals("XLSX") ? "1048576" : "65536";

                conn.Open();
                OleDbCommand cmd = new OleDbCommand($"SELECT * FROM [{GetTableName(conn)}A7:L{rowsSize}]", conn);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            var c = new Composicao();
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
                            c.CustoTotal = Convert.ToDecimal(dr[10].ToString());
                            if (dr.FieldCount > 11) c.Vinculo = dr[11].ToString();
                            c.Prefixo = prefix;

                            dbContext.Composicoes.Add(c);
                            _qntdSintetico++;
                        }
                    }

                    dbContext.Database.ExecuteSqlRaw($"DELETE FROM Composicoes WHERE PREFIXO = '{prefix}'");

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
                var rowsSize = Path.GetExtension(path).ToUpper().Equals("XLSX") ? "1048576" : "65536";

                conn.Open();
                OleDbCommand cmd = new OleDbCommand($"SELECT * FROM [{GetTableName(conn)}A7:AE{rowsSize}]", conn);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr.FieldCount > 13)
                        {
                            if (!String.IsNullOrEmpty(dr[12].ToString()))
                            {
                                var c = new ComposicaoItens();
                                c.Codigo = dr[6].ToString();
                                c.ItemTipo = dr[11].ToString();
                                c.ComposicaoCodigoComposicao = dr[12].ToString();
                                c.ItemCoeficiente = Convert.ToDecimal(dr[16].ToString());
                                c.ItemPrecoUnitario = Convert.ToDecimal(dr[17].ToString());
                                c.ItemCustoTotal = Convert.ToDecimal(dr[18].ToString());
                                c.Prefixo = prefix;

                                dbContext.ComposicoesItens.Add(c);
                            }
                        }
                    }

                    dbContext.Database.ExecuteSqlRaw($"DELETE FROM ComposicoesItens WHERE PREFIXO = '{prefix}'");

                    dbContext.SaveChanges();
                }
            }
        }

        private static string GetTableName(OleDbConnection conn)
        {
            var dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            var list = new List<String>();

            foreach (DataRow row in dt.Rows)
            {
                var tb = row["TABLE_NAME"].ToString();
                if (tb.EndsWith("$'"))
                {
                    tb = tb.Replace("'", "");
                    list.Add(tb);
                }
            }

            if (list.Count > 1)
            {
                foreach (var tb in list)
                {

                    OleDbCommand cmd = new OleDbCommand($"SELECT * FROM [{tb}A0:A10]", conn);
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr[0].ToString().ToUpper().Contains("CLASSE"))
                            {
                                return tb;
                            }
                        }
                    }
                }
            }

            return list.FirstOrDefault();
        }
    }
}
