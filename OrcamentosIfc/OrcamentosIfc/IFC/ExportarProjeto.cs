using Microsoft.EntityFrameworkCore;
using OrcamentosIfc.Data;
using OrcamentosIfc.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbim.Ifc;
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
                ep.LoadCustos();




            }


            var e = model.Instances.FirstOrDefault(x => x.EntityLabel.ToString() == "!");

        }
    }
}
