using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Databáze_osob
{
    public class OsobyDatabase
    {
        // SQLite connection
        public SQLiteAsyncConnection database;

        public OsobyDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Osoby>().Wait();
        }
        public Task<List<Osoby>>  QueryCustom()
        {
            return database.QueryAsync<Osoby>("DELETE FROM [Osoby]");
        }
        public Task<List<Osoby>> QueryCustomID(int ID)
        {
            return database.QueryAsync<Osoby>("DELETE FROM [Osoby] WHERE [ID] ="+ID);
        }
        public Task<List<Osoby>> QueryCustomUPDATE(string name, string text, int ID)
        {
          
    
          //  return database.QueryAsync<Osoby>("UPDATE [Osoby] (Name,Text) VALUES (" + name + "," + text + ") WHERE [ID] =" + ID);

            return database.QueryAsync<Osoby>("UPDATE [Osoby] SET Name = @name , Text = text WHERE[ID] = " + ID);
        }
        public Task<List<Osoby>> Add()
        {
            return database.QueryAsync<Osoby>("INSERT INTO [Osoby] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        // Query
        public Task<List<Osoby>> GetItemsAsync()
        {
            return database.Table<Osoby>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Osoby>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Osoby>("SELECT * FROM [Osoby] WHERE [Done] = 0");
        }

        // Query using LINQ
        public Task<Osoby> GetItemAsync(int id)
        {
            return database.Table<Osoby>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Osoby item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Osoby item)
        {
            return database.DeleteAsync(item);
        }
    }
}
