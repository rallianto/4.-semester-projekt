using JobAndOffer.Core.Models;
using JobAndOffer.Core.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAndOffer.BLL
{
    public class ProjectController
    {
        MongoContext db = new MongoContext();

        public async Task<List<Project>> GetAll()
        {
            return await db.Project.AsQueryable().ToListAsync();
        }

        public async Task<Project> Post(Project project)
        {
            await db.Project.InsertOneAsync(project);
            return project;
        }

        public Project Get(Project project)
        {
            return db.Project.AsQueryable().Where(s => s.Id == project.Id).FirstOrDefault();
        }

        public Project GetById(Guid id)
        {
            return db.Project.AsQueryable().Where(s => s.Id == id).FirstOrDefault();
        }

        public Project Put(Project project)
        {
            ReplaceOneResult results = db.Project.ReplaceOne(x => x.Id == project.Id, project);
            if (results.IsAcknowledged && results.ModifiedCount == 1)
            {
                return project;
            }
            return null;
        }

        public bool Delete(Project project)
        {
            DeleteResult results = db.Worker.DeleteOne(x => x.Id == project.Id);
            if (results.IsAcknowledged && results.DeletedCount == 1)
            {
                return true;
            }
            return false;
        }
    }
}
