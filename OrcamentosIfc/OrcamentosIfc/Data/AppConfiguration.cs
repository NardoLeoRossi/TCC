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
            if (!Directory.Exists(GetDataBasePath()))
            {
                SQLiteConnection.CreateFile(GetDataBasePath());
                var db = new AppDbContext();
                db.Database.EnsureCreated();
            }
        }

        public static string GetAppDataFolder()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folderPath = Path.Combine(appDataPath, @"OrcamentosIFC");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }

        public static string GetDataBasePath()
        {
            return GetAppDataFolder() + @"\OrcamentosIfc.sqlite";
        }
    }
}
