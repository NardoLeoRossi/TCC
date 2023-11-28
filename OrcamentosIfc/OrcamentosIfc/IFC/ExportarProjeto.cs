using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xbim.Ifc;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.ModelGeometry.Scene;
using OrcamentosIfc.Data;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace OrcamentosIfc.IFC
{
    public static class ExportarProjeto
    {
        public static void ExportarProjetoSelecionado()
        {
            //Capturar o caminho do arquivo do projeto
            var path = Path.Combine(AppConfiguration.GetProjectsPath(), Parametros.ProjetoSelecionado);

            //Definir o caminho de saída
            var outputPath = "";
            var saveFileDialog = new SaveFileDialog()
            {
                Title = "Salvar Como",
                FileName = Path.GetFileName(path),
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            outputPath = saveFileDialog.FileName;

            //Carregar o modelo IFC completo
            var model = IfcStore.Open(path);

            //Capturar os elementos com itens de custo relacionados
            var elementos = Parametros.AppDbContext.ElementosProjeto.Where(x => x.NomeProjeto.ToUpper() == Parametros.ProjetoSelecionado.ToUpper()).ToList();

            elementos.ForEach(x => x.LoadCustos());

            //Criar uma transaçaõ de alteração no modelo IFC
            using (var tr = model.BeginTransaction("Exportar Projeto"))
            {
                //Percorrer todos os elementos 
                foreach (var ep in elementos)
                {
                    //Carregar os itens de custos associados ao elemento
                    ep.LoadCustos();

                    //Carregar o elemento
                    var elementoIfc = model.Instances.FirstOrDefault<IfcElement>(x => x.GlobalId.ToString().ToUpper() == ep.IfcId.ToUpper());

                    //Criar o relacionamento de propriedades
                    var rel = model.Instances.New<IfcRelDefinesByProperties>();
                    rel.RelatedObjects.Add(elementoIfc);
                    rel.Name = "Orçamento";

                    //Se o elemento for localizado
                    if (elementoIfc != null)
                    {
                        //Percorrer todos os insumos
                        if (ep.Insumos != null)
                            foreach (var item in ep.Insumos)
                            {
                                AdicionarPropriedades(model, rel, "Insumo", item.Insumo.Codigo,
                                                        item.Quantidade.ToString(), item.Insumo.Preco, item.Insumo.Prefixo, item.Dimensao, item.Insumo.Unidade);
                            }

                        //Percorrer todas as composições sinteticas
                        if (ep.Composicoes != null)
                            foreach (var item in ep.Composicoes)
                            {
                                AdicionarPropriedades(model, rel, "Composição Sintética",
                                                    item.Composicao.CodigoComposicao, item.Quantidade.ToString(),
                                                    item.Composicao.CustoTotal, item.Composicao.Prefixo, item.Dimensao, item.Composicao.Unidade);
                            }
                    }
                }

                //Finalizar a transação de alterações
                tr.Commit();
            }

            //Salvar o modelo
            model.SaveAs(outputPath);
        }

        private static void AdicionarPropriedades(IfcStore model, IfcRelDefinesByProperties rel, string tipoItem, string codigoSinapi, 
                                                    string quantidade, decimal custoUnitario, string prefixoSinapi, string dimensao, string unidade)
        {
            var ps = model.Instances.New<IfcPropertySet>();
            rel.RelatingPropertyDefinition = ps;
            ps.Name = "Custo";

            //Tipo de item
            ps.HasProperties.Add(model.Instances.New<IfcPropertySingleValue>(p =>
            {
                p.Name = "Tipo Item Sinapi";
                p.NominalValue = new IfcLabel(tipoItem);
            }));

            //Código Sinapi
            ps.HasProperties.Add(model.Instances.New<IfcPropertySingleValue>(p =>
            {
                p.Name = "Código Sinapi";
                p.NominalValue = new IfcLabel(codigoSinapi);
            }));

            //Unidade do item sinapi
            ps.HasProperties.Add(model.Instances.New<IfcPropertySingleValue>(p =>
            {
                p.Name = "Unidade Sinapi";
                p.NominalValue = new IfcLabel(unidade);
            }));

            //Quantidade
            ps.HasProperties.Add(model.Instances.New<IfcPropertySingleValue>(p =>
            {
                p.Name = "Quantidade";
                p.NominalValue = new IfcLabel(quantidade);
            }));

            //Dimensao
            ps.HasProperties.Add(model.Instances.New<IfcPropertySingleValue>(p =>
            {
                p.Name = "Dimensão";
                p.NominalValue = new IfcLabel(dimensao);
            }));

            //Custo unitário
            ps.HasProperties.Add(model.Instances.New<IfcPropertySingleValue>(p =>
            {
                p.Name = "Custo Unitário";
                p.NominalValue = new IfcLabel(custoUnitario.ToString());
            }));

            //Custo Total
            ps.HasProperties.Add(model.Instances.New<IfcPropertySingleValue>(p =>
            {
                p.Name = "Custo Total";
                p.NominalValue = new IfcLabel((custoUnitario * Decimal.Parse(quantidade)).ToString());
            }));

            //Referencia SINAPI
            ps.HasProperties.Add(model.Instances.New<IfcPropertySingleValue>(p =>
            {
                p.Name = "Referência SINAPI";
                p.NominalValue = new IfcLabel(prefixoSinapi);
            }));
        }
    }
}
