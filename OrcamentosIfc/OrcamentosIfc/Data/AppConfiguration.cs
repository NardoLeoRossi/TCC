using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;

namespace OrcamentosIfc.Data
{
    public static class AppConfiguration
    {
        public static void CreateDataBaseSqlLite()
        {
            if (!File.Exists(GetDataBasePath()))
            {
                SQLiteConnection.CreateFile(GetDataBasePath());
                var db = new AppDbContext();
                db.Database.EnsureCreated();
            }
        }

        public static string GetAppDataFolder()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folderPath = Path.Combine(appDataPath, "OrcamentosIFC");
            var folderProjects = Path.Combine(appDataPath, "Projetos");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Directory.CreateDirectory(folderProjects);
            }
            return folderPath;
        }

        public static string GetDataBasePath()
        {
            return GetAppDataFolder() + @"\OrcamentosIfc.sqlite";
        }

        public static string GetProjectsPath()
        {
            var path = GetAppDataFolder() + @"\Projetos";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}
