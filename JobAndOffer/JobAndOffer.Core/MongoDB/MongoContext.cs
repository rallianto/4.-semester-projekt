using JobAndOffer.Core.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobAndOffer.Core.MongoDB
{
    public class MongoContext
    {
        private IMongoDatabase db;
        private MongoClient client;

        public MongoContext()
        {
            client = new MongoClient("mongodb://jobandoffer:jobandoffer@ds147377.mlab.com:47377/jobandoffer");
            db = client.GetDatabase("jobandoffer");
        }

        public IMongoCollection<Worker> Worker
        {
            get
            {
                return db.GetCollection<Worker>("Worker");
            }
        }

        public IMongoCollection<Project> Project
        {
            get
            {
                return db.GetCollection<Project>("Project");
            }
        }

    }
}
