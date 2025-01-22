using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Labb_2
{
    public class DungeonDataAccess
    {
        private const string ConnectionString = "mongodb://localhost:27017";
         private const string DatabaseName = "JonathanOlaussenAlvin";
        private readonly IMongoCollection<LevelElement> SaveGameCollection;

        public DungeonDataAccess() 
        { 
            var client = new MongoClient(ConnectionString);
            var database = client.GetDatabase(DatabaseName);
            SaveGameCollection = database.GetCollection<LevelElement>("SaveGameCollection");

        }

/*        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }*/

       /* public void ClearSave()
        {
            var saveGameCollection = ConnectToMongo<LevelElement>(SaveGameCollection);
            var emptyFilter = Builders<LevelElement>.Filter.Empty;
            saveGameCollection.DeleteMany(emptyFilter);
        }*/
        public void CreateSave(List<LevelElement> elements)
        {
            var client = new MongoClient(ConnectionString);
            var database = client.GetDatabase(DatabaseName);
            database.DropCollection("SaveGameCollection"); 
            SaveGameCollection.InsertManyAsync(elements);

        }
        public List<LevelElement> LoadSave()
        {
            List<LevelElement> result = new List<LevelElement>();   
            result = SaveGameCollection.Find(_ => true).ToList();
            return result;
        }

        /* public List<LevelElement> LoadSave()
         {   var data = new LevelData();
             var saveGameCollection = ConnectToMongo<LevelElement>(SaveGameCollection);
             data.Elements = saveGameCollection.Find(_ => true);
             return results.ToList();
         }*/
    }
}
