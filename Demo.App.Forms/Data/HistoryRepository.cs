using Simsip.Demo.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Simsip.Demo.Data
{
    public class HistoryRepository : IHistoryRepository
    {
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the History database. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// </param>
        public HistoryRepository()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<History>();
        }

        public IList<History> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<History>() select i).ToList();
            }
        }

        // Example
        public IEnumerable<History> GetItemsNotDone()
        {
            lock (locker)
            {
                return database.Query<History>("SELECT * FROM [History] WHERE [EntryValue] = 0");
            }
        }

        public History GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<History>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(History item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<History>(id);
            }
        }

        public int Count()
        {
            return database.Table<History>().Count();
        }
    }

}
