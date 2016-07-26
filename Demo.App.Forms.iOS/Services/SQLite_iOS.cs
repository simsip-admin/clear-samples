using Simsip.Demo.Data;
using Simsip.Demo.iOS.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace Simsip.Demo.iOS.Services
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        #region ISQLite implementation

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Pharo.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            // TODO: Local database copy support (see TODO from Xamarin forms samples)
            // https://developer.xamarin.com/guides/xamarin-forms/working-with/databases/
            // This is where we copy in the prepopulated database
            /*
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Copy(sqliteFilename, path);
            }
            */

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }

        #endregion
    }
}
