using Microsoft.EntityFrameworkCore;
using OrcamentosIfc.Data;
using System;
using System.IO;
using System.Linq;
using Xbim.Ifc;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.StructuralElementsDomain;
using Xbim.Ifc2x3.UtilityResource;
using Xbim.ModelGeometry.Scene;

namespace OrcamentosIfc.IFC
{
    public static class ExportarProjeto
    {
        public static void ExportarProjetoSelecionado()
        {
            var path = Path.Combine(AppConfiguration.GetProjectsPath(), Parametros.ProjetoSelecionado);
            var model = IfcStore.Open(path);
            var context = new Xbim3DModelContext(model);
            context.CreateContext();

            //Capturar os elementos criados para o projeto selecionado
            var elementos = Parametros.AppDbContext.ElementosProjeto
                                            .Include(x => x.Insumos)
                                            .Include(x => x.ComposicoesAnaliticas)
                                            .Include(x => x.ComposicoesSinteticas)
                                            .Where(x => x.NomeProjeto.ToUpper() == Parametros.ProjetoSelecionado.ToUpper()).ToList();

            using (var tr = model.BeginTransaction("Adicionar Propriedade"))
            {
                //Percorrer todos os elementos 
                foreach (var ep in elementos)
                {
                    //Carregar os itens de custos associados ao elemento
                    ep.LoadCustos();

                    //Carregar o elemento
                    var elementoIfc = model.Instances.FirstOrDefault<IfcBuildingElementPart>(x => x.EntityLabel.ToString().ToUpper() == ep.IfcId.ToUpper());

                    //Se o elemento for localizado
                    if (elementoIfc != null)
                    {
                        //Percorrer todos os insumos
                        if (ep.Insumos != null)
                            foreach (var item in ep.Insumos)
                            {
                                var rel = AdicionarPropriedades(model, elementoIfc, "Insumo", item.Insumo.Codigo, item.Quantidade.ToString(), item.Insumo.Preco);
                            }

                        //Percorrer todas as composições sinteticas
                        if (ep.ComposicoesSinteticas != null)
                            foreach (var item in ep.ComposicoesSinteticas)
                            {
                                var rel = AdicionarPropriedades(model, elementoIfc, "Composição Sintética", item.ComposicaoSintetica.CodigoComposicao, item.Quantidade.ToString(), item.ComposicaoSintetica.CustoTotal);
                            }

                        //Percorrer todas as composições analiticas
                        if (ep.ComposicoesAnaliticas != null)
                            foreach (var item in ep.ComposicoesAnaliticas)
                            {
                                var rel = AdicionarPropriedades(model, elementoIfc, "Composição Sintética", item.ComposicaoAnalitica.CodigoComposicao, item.Quantidade.ToString(), item.ComposicaoAnalitica.CustoTotal);
                            }
                    }
                }

                tr.Commit();
            }

            model.SaveAs(@"C:\Users\Cinvau\OneDrive\Área de Trabalho\Trabalho Sistemas Estruturais III 4.0 - Edited.ifc");
        }

        private static IfcRelDefinesByProperties AdicionarPropriedades(IfcStore model, IfcBuildingElementPart elemento, string tipoItem, string codigoSinapi, string quantidade, decimal custoUnitario)
        {
            var rel = model.Instances.New<IfcRelDefinesByProperties>();
            rel.RelatedObjects.Add(elemento);
            //rel.GlobalId = new IfcGloballyUniqueId(Guid.NewGuid().ToString());

            var ps = model.Instances.New<IfcPropertySet>();
            rel.RelatingPropertyDefinition = ps;
            ps.Name = "Nome Teste";
            

            //ps.GlobalId = new IfcGloballyUniqueId(Guid.NewGuid().ToString());

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

            //Quantidade
            ps.HasProperties.Add(model.Instances.New<IfcPropertySingleValue>(p =>
            {
                p.Name = "Quantidade";
                p.NominalValue = new IfcLabel(quantidade);
            }));

            //Quantidade
            ps.HasProperties.Add(model.Instances.New<IfcPropertySingleValue>(p =>
            {
                p.Name = "Quantidade";
                p.NominalValue = new IfcLabel(quantidade);
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

            return rel;
        }
    }
}
