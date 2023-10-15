using System;
using Xbim.Common;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using System.Linq;

namespace TestandoXbimToolKit
{
    public static class Testes
    {

        public static void Teste3(string path)
        {
            using (var model = IfcStore.Open(path))
            {
                var walls = model.Instances.OfType<IIfcWall>();

                foreach (var wall in walls)
                {
                    Console.WriteLine($"Parede ID: {wall.GlobalId}");

                    // Obter o conjunto de camadas associado a esta parede
                    var materialLayerSetUsage = wall.HasAssociations.OfType<IIfcRelAssociatesMaterial>().FirstOrDefault()?.RelatingMaterial as IIfcMaterialLayerSetUsage;

                    if (materialLayerSetUsage != null)
                    {
                        var materialLayerSet = materialLayerSetUsage.ForLayerSet;

                        foreach (var layer in materialLayerSet.MaterialLayers)
                        {
                            Console.WriteLine($"  Camada:");
                            Console.WriteLine($"    Material: {layer.Material.Name}");
                            Console.WriteLine($"    Espessura: {layer.LayerThickness}");
                            Console.WriteLine($"    Categoria: {layer.Category}");
                        }
                    }

                    if (wall.Representation != null)
                    {
                        foreach (var representation in wall.Representation.Representations)
                        {
                            foreach (var item in representation.Items)
                            {
                                if (item is IIfcExtrudedAreaSolid extrudedSolid)
                                {
                                    var sweptArea = extrudedSolid.SweptArea;

                                    if (sweptArea is IIfcArbitraryClosedProfileDef arbitraryClosedProfile)
                                    {
                                        var outerCurve = arbitraryClosedProfile.OuterCurve;

                                        if (outerCurve is IIfcIndexedPolyCurve indexedPolyCurve)
                                        {
                                            // Os pontos estão armazenados em IfcCartesianPointList2D
                                            if (indexedPolyCurve.Points is IIfcCartesianPointList2D pointList)
                                            {
                                                var points = pointList.CoordList.Select(p => new { X = p[0], Y = p[1] }).ToList();

                                                var pointsX = points.Select(obj => (double)obj.X.Value);
                                                var minX = pointsX.Min(p => p);
                                                var maxX = pointsX.Max(p => p);

                                                var pointsY = points.Select(obj => (double)obj.Y.Value);
                                                var minY = pointsY.Min(p => p);
                                                var maxY = pointsY.Max(p => p);


                                                var width = maxX - minX;
                                                var length = maxY - minY;

                                                // A altura é o valor da extrusão
                                                var height = extrudedSolid.Depth;

                                                Console.WriteLine($"  Largura: {width}");
                                                Console.WriteLine($"  Altura: {height}");
                                                Console.WriteLine($"  Comprimento: {length}");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Console.WriteLine();
                }
            }
        }

        public static void Teste2(string path)
        {

            using (var model = IfcStore.Open(path))
            {
                var walls = model.Instances.OfType<IIfcWall>();

                foreach (var wall in walls)
                {
                    Console.WriteLine($"Parede ID: {wall.GlobalId}");

                    if (wall.Representation != null)
                    {
                        foreach (var representation in wall.Representation.Representations)
                        {
                            foreach (var item in representation.Items)
                            {
                                if (item is IIfcExtrudedAreaSolid extrudedSolid)
                                {
                                    var sweptArea = extrudedSolid.SweptArea;

                                    if (sweptArea is IIfcArbitraryClosedProfileDef arbitraryClosedProfile)
                                    {
                                        var outerCurve = arbitraryClosedProfile.OuterCurve;

                                        if (outerCurve is IIfcIndexedPolyCurve indexedPolyCurve)
                                        {
                                            // Os pontos são armazenados em IfcCartesianPointList
                                            if (indexedPolyCurve.Points is IIfcCartesianPointList3D pointList)
                                            {
                                                var points = pointList.CoordList.Select(p => new { X = p[0], Y = p[1], Z = p[2] }).ToList();

                                                var minX = points.Min(p => p.X);
                                                var minY = points.Min(p => p.Y);
                                                var minZ = points.Min(p => p.Z);

                                                var maxX = points.Max(p => p.X);
                                                var maxY = points.Max(p => p.Y);
                                                var maxZ = points.Max(p => p.Z);

                                                var width = maxX - minX;
                                                var height = maxZ - minZ;  // Considerando que Z é a direção vertical
                                                var length = maxY - minY;

                                                Console.WriteLine($"  Largura: {width}");
                                                Console.WriteLine($"  Altura: {height}");
                                                Console.WriteLine($"  Comprimento: {length}");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Console.WriteLine();
                }
            }
        }

        public static void Teste111(string path)
        {

            using (var model = IfcStore.Open(path))
            {
                var walls = model.Instances.OfType<IIfcWall>();

                foreach (var wall in walls)
                {
                    Console.WriteLine($"Parede ID: {wall.GlobalId}");

                    if (wall.Representation != null)
                    {
                        foreach (var representation in wall.Representation.Representations)
                        {
                            foreach (var item in representation.Items)
                            {
                                if (item is IIfcExtrudedAreaSolid extrudedSolid)
                                {
                                    var sweptArea = extrudedSolid.SweptArea;

                                    if (sweptArea is IIfcArbitraryClosedProfileDef arbitraryClosedProfile)
                                    {
                                        var outerCurve = arbitraryClosedProfile.OuterCurve;

                                        if (outerCurve is IIfcPolyline polyline)
                                        {
                                            var points = polyline.Points.Select(p => new { p.X, p.Y, p.Z }).ToList();

                                            var minX = points.Min(p => p.X);
                                            var minY = points.Min(p => p.Y);
                                            var minZ = points.Min(p => p.Z);

                                            var maxX = points.Max(p => p.X);
                                            var maxY = points.Max(p => p.Y);
                                            var maxZ = points.Max(p => p.Z);

                                            var width = maxX - minX;
                                            var height = maxZ - minZ;  // Considerando que Z é a direção vertical
                                            var length = maxY - minY;

                                            Console.WriteLine($"  Largura: {width}");
                                            Console.WriteLine($"  Altura: {height}");
                                            Console.WriteLine($"  Comprimento: {length}");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}

