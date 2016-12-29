using JobAndOffer.Core.Models;
using JobAndOffer.Core.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JobAndOffer.WebAPI.Controllers
{
    [RoutePrefix("Worker")]
    public class WorkerController : ApiController
    {
        MongoContext db = new MongoContext();

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Worker>> GetAll()
        {
            return await db.Worker.AsQueryable().ToListAsync();
        }
        [HttpGet]
        [Route("Far")]
        public string Test()
        {
            return "Hej far";
        }

        [HttpPost]
        public Worker Post(Worker worker)
        {
            db.Worker.InsertOne(worker);
            return worker;
        }

        public Worker Get(Worker worker)
        {
            return db.Worker.AsQueryable().Where(s => s.Id == worker.Id).FirstOrDefault();
        }

        public Worker Get(Guid id)
        {
            return db.Worker.AsQueryable().Where(s => s.Id == id).FirstOrDefault();
        }

        [HttpPut]
        public Worker Put(Worker worker)
        {
            ReplaceOneResult results = db.Worker.ReplaceOne(x => x.Id == worker.Id, worker);
            if (results.IsAcknowledged && results.ModifiedCount == 1)
            {
                return worker;
            }
            return null;
        }

        [HttpDelete]
        public bool Delete(Worker worker)
        {
            DeleteResult results = db.Worker.DeleteOne(x => x.Id == worker.Id);
            if (results.IsAcknowledged && results.DeletedCount == 1)
            {
                return true;
            }
            return false;
        }
    }
}
