using JobAndOffer.Core.Models;
using JobAndOffer.Core.MongoDB;
using JobAndOffer.BLL;
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
    [RoutePrefix("Project")]
    public class ProjectController : ApiController
    {
        BLL.ProjectController projectController = new BLL.ProjectController();

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Project>> GetAllProjects()
        {
            return await projectController.GetAll();
        }

        [HttpPost]
        [Route("Post")]
        public async Task<Project> PostProject(Project project)
        {
            return await projectController.Post(project);
        }
        [HttpGet]
        [Route("Get")]
        public Project GetProject(Project project)
        {
            return projectController.Get(project);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Project GetProjectById(string id)
        {
            return projectController.GetById(new Guid(id));
        }

        [HttpPut]
        [Route("Put")]
        public Project PutProject(Project project)
        {
            return projectController.Put(project);
        }

        [HttpDelete]
        [Route("Delete")]
        public bool DeleteProject(Project project)
        {
            return projectController.Delete(project);
        }
    }
}
