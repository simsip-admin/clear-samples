using SQLite;

namespace Simsip.Demo.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
