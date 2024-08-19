using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Budget.Application.Projections.Core;
internal class MongoDbProjectionStore : IProjectionStore
{
    private readonly IMongoDatabase _database;

    public MongoDbProjectionStore(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public void Add<TProjection>(TProjection projection) where TProjection : Projection<TProjection>
    {
        var collection = _database.GetCollection<TProjection>(typeof(TProjection).Name);
        if (projection.Id == Guid.Empty)
        {
            projection.Id = Guid.NewGuid();
        }
        collection.InsertOne(projection);
    }

    public void Clear()
    {
        var collections = _database.ListCollectionNames().ToList();
        foreach (var collectionName in collections) _database.DropCollection(collectionName);
    }

    public List<TProjection> Projections<TProjection>() where TProjection : Projection<TProjection>
    {
        var collection = _database.GetCollection<TProjection>(typeof(TProjection).Name);
        return collection.Find(Builders<TProjection>.Filter.Empty).ToList();
    }

    public void Remove<TProjection>(TProjection projection) where TProjection : Projection<TProjection>
    {
        var collection = _database.GetCollection<TProjection>(typeof(TProjection).Name);
        var filter = Builders<TProjection>.Filter.Eq(nameof(projection.Id), projection.Id);
        collection.DeleteOne(filter);
    }
}