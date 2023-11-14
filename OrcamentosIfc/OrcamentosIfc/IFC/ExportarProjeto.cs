using Microsoft.EntityFrameworkCore;
using OrcamentosIfc.Data;
using OrcamentosIfc.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xbim.Ifc;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.SharedBldgElements;
using Xbim.ModelGeometry.Scene;
using Xbim.Presentation;

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
                                            .Where(x=> x.NomeProjeto.ToUpper() == Parametros.ProjetoSelecionado.ToUpper());

            //Percorrer todos os elementos 
            foreach (var ep in elementos)
            {
                //Carregar os itens de custos associados ao elemento
                ep.LoadCustos();

                //Carregar o elemento
                var elementoIfc = model.Instances.Where(x => x.EntityLabel.ToString().ToUpper() == ep.IfcId.ToUpper()).First();

                //Se o elemento for localizado
                if(elementoIfc != null)
                {

                    var propriedade = model.Instances.New<IfcPropertySingleValue>(p =>
                    {
                        p.Name = "NomeDaPropriedade";
                        p.NominalValue = new IfcLabel("ValorDaPropriedade");
                    });



                    //var conjuntoPropriedades = model.Instances.New<IfcPropertySet>(ps =>
                    //{
                    //    ps.GlobalId = Guid.NewGuid();
                    //    ps.OwnerHistory = model.Instances.FirstOrDefault<IIfcOwnerHistory>();
                    //    ps.Name = "NomeDoConjuntoDePropriedades";
                    //    ps.HasProperties.Add(propriedade);
                    //});

                    //var relacao = model.Instances.New<IIfcRelDefinesByProperties>(r =>
                    //{
                    //    r.GlobalId = Guid.NewGuid();
                    //    r.RelatingPropertyDefinition = conjuntoPropriedades;
                    //    r.RelatedObjects.Add(elemento);
                    //});








                }
            }


            var e = model.Instances.FirstOrDefault(x => x.EntityLabel.ToString() == "!");

        }

        //void AddOrUpdateSimpleProperty(IIfcElement elemento, string propertyName, string propertyValue, IfcStore model)
        //{
        //    var defineByType = model.Instances.New<Xbim.Ifc2x3.Kernel.IfcRelDefinesByType>(rel =>
        //    {
        //        rel.RelatingType = elemento;
        //    });

        //    var propertySet = model.Instances.New<Xbim.Ifc2x3.Kernel.IfcPropertySet>(ps =>
        //    {
        //        ps.Name = "NomeDoConjuntoDePropriedades";
        //        ps.HasProperties.Add(new Xbim.Ifc2x3.PropertyResource.IfcPropertySingleValue(propertyName, new Xbim.Ifc2x3.MeasureResource.IfcLabel(propertyValue)));
        //    });

        //    defineByType.RelatedObjects.Add(elemento);
        //}
    }
}
