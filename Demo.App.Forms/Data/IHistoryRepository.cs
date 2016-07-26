using Simsip.Demo.Models;
using System.Collections.Generic;

namespace Simsip.Demo.Data
{
    public interface IHistoryRepository
    {
        IList<History> GetItems();

        History GetItem(int id);

        int SaveItem(History item);

        int DeleteItem(int id);

        int Count();
    }
}
