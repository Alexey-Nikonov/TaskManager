using System;
using System.IO;

using Xamarin.Forms;

using TaskManager.Providers;
using TaskManager.Droid;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace TaskManager.Droid
{
    public class SQLite_Droid : ISQLite
    {
        string ISQLite.GetDatabasePath(string dbname)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsPath, dbname);

            if (!File.Exists(path))
            {
                var dbAssetStream = Forms.Context.Assets.Open(dbname);

                var dbFileStream = new FileStream(path, FileMode.OpenOrCreate);
                var buffer = new byte[1024];

                int b = buffer.Length;
                int length;

                while ((length = dbAssetStream.Read(buffer, 0, b)) > 0)
                {
                    dbFileStream.Write(buffer, 0, length);
                }

                dbFileStream.Flush();
                dbFileStream.Close();
                dbAssetStream.Close();
            }

            return path;
        }
    }
}