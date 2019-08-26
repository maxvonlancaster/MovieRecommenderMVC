using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRecommenderMVC.DAL.MongoDBAccess
{
    public class MongoDbContext
    {
        private string _connectionString = "mongodb://localhost:27017";

        public IMongoDatabase database;

        public MongoDbContext()
        {
            MongoClient client = new MongoClient(_connectionString);
            database = client.GetDatabase("Movie");
        }
    }
}
