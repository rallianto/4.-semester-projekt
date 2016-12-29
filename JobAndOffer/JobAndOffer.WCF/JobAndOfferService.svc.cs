using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using JobAndOffer.Core.Models;
using System.Threading.Tasks;
using MongoDB.Bson;
using JobAndOffer.Core;
using JobAndOffer.Core.MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace JobAndOffer.WCF
{
    public class JobAndOfferService : IJobAndOfferService
    {
        MongoContext db = new MongoContext();

        #region Worker
        public Worker AddWorker(Worker worker)
        {
            db.Worker.InsertOne(worker);
            return worker;
        }

        //public async Task<Worker> AddWorkerAsync(Worker worker)
        //{
        //    await db.Worker.InsertOneAsync(worker);
        //    return worker;
        //}

        public Worker FindWorker(Worker worker)
        {
            return db.Worker.AsQueryable().Where(s => s.Id == worker.Id).FirstOrDefault();
        }

        //public async Task<Worker> FindWorkerAsync(Worker worker)
        //{
        //    return await db.Worker.AsQueryable().Where(s => s.Id == worker.Id).FirstOrDefaultAsync();
        //}

        public Worker FindWorkerById(Guid id)
        {
            return db.Worker.AsQueryable().Where(s => s.Id == id).FirstOrDefault();
        }

        //public async Task<Worker> FindWorkerByIdAsync(Guid id)
        //{
        //    return await db.Worker.AsQueryable().Where(s => s.Id == id).FirstOrDefaultAsync();
        //}

        public Worker UpdateWorker(Worker worker)
        {
            ReplaceOneResult results = db.Worker.ReplaceOne(x => x.Id == worker.Id, worker);
            if (results.IsAcknowledged && results.ModifiedCount == 1)
            {
                return worker;
            }
            return null;
        }

        //public async Task<Worker> UpdateWorkerAsync(Worker worker)
        //{
        //    ReplaceOneResult results = await db.Worker.ReplaceOneAsync(x => x.Id == worker.Id, worker);
        //    if (results.IsAcknowledged && results.ModifiedCount == 1)
        //    {
        //        return worker;
        //    }
        //    return null;
        //}

        public bool DeleteWorker(Worker worker)
        {
            DeleteResult results = db.Worker.DeleteOne(x => x.Id == worker.Id);
            if (results.IsAcknowledged && results.DeletedCount == 1)
            {
                return true;
            }
            return false;
        }

        //public async Task<bool> DeleteWorkerAsync(Worker worker)
        //{
        //    DeleteResult results =  await db.Worker.DeleteOneAsync(x => x.Id == worker.Id);
        //    if(results.IsAcknowledged && results.DeletedCount == 1)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        #endregion

        #region Project
        public Project AddProject(Project project)
        {
            db.Project.InsertOneAsync(project);
            return project;
        }

        public Project FindProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Project FindProjectById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Project UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
