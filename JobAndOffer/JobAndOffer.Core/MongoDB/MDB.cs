//using JobAndOffer.Core.Interfaces;
//using JobAndOffer.Core.Models;
//using MongoDB.Bson;
//using MongoDB.Driver;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace JobAndOffer.Core
//{
//    public class MDB<T> where T : IMongoModel
//    {
//        //MongoDB Connection
//        static MongoClient client = new MongoClient("mongodb://jobandoffer:jobandoffer@ds147377.mlab.com:47377/jobandoffer");

//        //Database
//        static IMongoDatabase db = client.GetDatabase("jobandoffer");

//        //Collection
//        IMongoCollection<T> mongoCollection;

//        public MDB(string collection)
//        {
//            mongoCollection = db.GetCollection<T>(collection);
//        }

//        public T Add(T entity)
//        {
//            mongoCollection.InsertOne(entity);
//            return entity;
//        }

//        public async Task<T> AddAsync(T entity)
//        {
//            await mongoCollection.InsertOneAsync(entity);
//            return entity;
//        }

//        public T Find(T entity)
//        {
//            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
//            return mongoCollection.Find(filter).FirstOrDefault();
//        }

//        public async Task<T> FindAsync(T entity)
//        {
//            //FindOptions<T> options = new FindOptions<T> { Limit = 1 };
//            //IAsyncCursor<T> task = await mongoCollection.FindAsync(x => x.Id.Equals(entity.Id), options);
//            //return task.ToListAsync().Result.FirstOrDefault();
//            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
//            return await mongoCollection.Find(filter).FirstOrDefaultAsync();
//        }

//        public T FindById(string id)
//        {
//            var filter = Builders<T>.Filter.Eq(s => s.Id, id);
//            return mongoCollection.Find(filter).FirstOrDefault();
//        }

//        public async Task<T> FindByIdAsync(string id)
//        {
//            var filter = Builders<T>.Filter.Eq(s => s.Id, id);
//            return await mongoCollection.Find(filter).FirstOrDefaultAsync();
//        }

//        public T Update(T entity)
//        {
//            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
//            ReplaceOneResult result = mongoCollection.ReplaceOne(filter, entity);
//            if (result.IsAcknowledged && result.ModifiedCount == 1)
//            {
//                return entity;
//            }
//            return default(T);
//        }

//        public async Task<T> UpdateAsync(T entity)
//        {
//            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
//            ReplaceOneResult result = await mongoCollection.ReplaceOneAsync(filter, entity);
//            if (result.IsAcknowledged && result.ModifiedCount == 1)
//            {
//                return entity;
//            }
//            return default(T);
//        }

//        public bool Delete(T entity)
//        {
//            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
//            DeleteResult result = mongoCollection.DeleteOne(filter);
//            if (result.IsAcknowledged && result.DeletedCount == 1)
//            {
//                return true;
//            }
//            return false;
//        }

//        public async Task<bool> DeleteAsync(T entity)
//        {      
//            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
//            DeleteResult result = await mongoCollection.DeleteOneAsync(filter);
//            if(result.IsAcknowledged && result.DeletedCount == 1)
//            {
//                return true;
//            }         
//            return false;
//        }

//    }
//}

