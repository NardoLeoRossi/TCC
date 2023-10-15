using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xbim.Ifc;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.SharedBldgElements;

namespace TestandoXbimToolKit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var dlg = new OpenFileDialog();
            //dlg.Filter = "IFC Files|*.ifc;*.ifczip;*.ifcxml|Xbim Files|*.xbim";
            //dlg.Multiselect = false;
            //dlg.Title = "Selecione um Arquivo IFC";
            //dlg.ShowDialog();

            var path = @"C:\Users\Cinvau\OneDrive\Área de Trabalho\Trabalho Sistemas Estruturais III 4.0.ifc";//@"C:\Users\Cinvau\OneDrive\Área de Trabalho\Projeto Teste.ifc"; //dlg.FileName;

            Testes.Teste3(path);

            Console.ReadLine();















            if (String.IsNullOrEmpty(path))
            {
                Console.WriteLine("Arquivo Inválido");
                Console.ReadLine();
                return;
            }

            //var model = IfcStore.Open(path);



            const string fileName = "SampleHouse.ifc";
            using (var model = IfcStore.Open(path))
            {
               


                var walls = model.Instances.OfType < IfcWall>();

                foreach (var wall in walls)
                {

                    Console.WriteLine($"Parede Global ID: {wall.GlobalId}, Nome: {wall.Name}");

                    if(wall.Representation != null)
                    {
                        foreach (var representation in wall.Representation.Representations)
                        {

                            foreach (var item in representation.Items)
                            {
                                if( item is IIfcExtrudedAreaSolid extrudedSolid)
                                {
                                    var direction = extrudedSolid.ExtrudedDirection;
                                    var depth = extrudedSolid.Depth;
                                    var baseProfile = extrudedSolid.SweptArea;

                                    double height = Math.Abs(depth * direction.Z);

                                    if (baseProfile is IIfcRectangleProfileDef rectangle)
                                    {
                                        double width = rectangle.XDim;
                                        double lengh = rectangle.YDim;

                                        Console.WriteLine($"    Altura:{height}");
                                        Console.WriteLine($"    Largura:{width}");
                                        Console.WriteLine($"    Altura:{lengh}");
                                    }
                                }
                            }
                        }
                    }


                }





                foreach (var wall in walls)
                {
                    var props = wall.IsDefinedBy.Where(r => r.RelatingPropertyDefinition is IfcPropertySet)
                        .SelectMany(r => ((IfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                        .OfType<IIfcPropertySingleValue>();
                    foreach (var p in props)
                    {
                        
                        Console.WriteLine($"Wall: {wall.Name} - Property: {p.Name}, Value: {p.NominalValue}");
                    }
                }


                ////get all doors in the model (using IFC4 interface of IfcDoor this will work both for IFC2x3 and IFC4)
                //var allDoors = model.Instances.OfType<IIfcDoor>();

                ////get only doors with defined IIfcTypeObject
                //var someDoors = model.Instances.Where<IIfcDoor>(d => d.IsTypedBy.Any());

                ////get one single door 
                //var id = "2AswZfru1AdAiKfEdrNPnu";
                //var theDoor = model.Instances.FirstOrDefault<IIfcDoor>(d => d.GlobalId == id);
                //Console.WriteLine($"Door ID: {theDoor.GlobalId}, Name: {theDoor.Name}");

                ////get all single-value properties of the door
                //var properties = theDoor.IsDefinedBy
                //    .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                //    .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                //    .OfType<IIfcPropertySingleValue>();
                //foreach (var property in properties)
                //    Console.WriteLine($"Property: {property.Name}, Value: {property.NominalValue}");
            }



            Console.ReadLine();

            //Console.WriteLine("Elementos encontrados com dimensões:");

            //foreach (var instance in model.Instances)
            //{
            //    if (instance is IfcProduct product)
            //    {
            //        // Verifica se o elemento tem uma representação da geometria
            //        if (product.Representation != null)
            //        {
            //            // Verifica se a representação possui sólidos
            //            var solids = product.Representation.Representations
            //                .SelectMany(r => r.Items)
            //                .OfType<IfcSolidModel>();

            //            foreach (var solid in solids)
            //            {

            //                // Verifica se o sólido é um prisma extrudado, o que pode representar as dimensões do elemento
            //                if (solid is IfcExtrudedAreaSolid extrudedSolid)
            //                {
            //                    // Obtém as dimensões do sólido (por exemplo, altura)
            //                    var height = extrudedSolid.Depth;

            //                    Console.WriteLine($"Elemento: Tipo = {product.GetType().Name}, Altura = {height} metros");
            //                }
            //            }
            //        }
            //    }
            //}





            //var allInstances = model.Instances;
            //foreach (var instance in allInstances)
            //{
            //    if (instance is IfcObject ifcObject || true)
            //    {
            //        Console.WriteLine($"Tipo: {instance.GetType().Name}");
            //    }
            //}


        }


        // Função para obter a altura de uma parede
        static double GetWallHeight(IfcWall wall)
        {
            // Verifica se a parede tem uma representação da geometria
            if (wall.Representation != null)
            {
                // Verifica se a representação possui sólidos
                var solids = wall.Representation.Representations
                    .SelectMany(r => r.Items)
                    .OfType<Xbim.Ifc4.Interfaces.IIfcSolidModel>();

                foreach (var solid in solids)
                {
                    // Verifica se o sólido é um prisma extrudado, o que pode representar a altura da parede
                    if (solid is Xbim.Ifc4.Interfaces.IIfcExtrudedAreaSolid extrudedSolid)
                    {
                        // A altura da parede é a extrusão da forma base
                        return extrudedSolid.Depth;
                    }
                }
            }

            // Se a altura não puder ser determinada, retorna 0 como valor padrão
            return 0.0;
        }
    }
}

