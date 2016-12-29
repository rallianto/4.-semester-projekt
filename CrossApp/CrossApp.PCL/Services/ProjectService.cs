using CrossApp.PCL.ServiceModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CrossApp.PCL.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjects();
        Task<Project> AddProject(Project project);
        Project FindProject(Project project);
        Task<Project> FindProjectById(Guid id);
        Project UpdateProject(Project project);
        bool DeleteProject(Project project);
    }

    public class ProjectService : IProjectService
    {

        public async Task<Project> AddProject(Project project)
        {
            HttpClient webservice = new HttpClient();
            string srObj = JsonConvert.SerializeObject(project);
            HttpContent httpContent = new StringContent(srObj, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await webservice.PostAsync(MainService.BaseUrl + "Project/Post", httpContent);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var returnObj = JsonConvert.DeserializeObject<Project>(data);
                return returnObj;
            }
            return null;
        }

        public bool DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Project FindProject(Project project)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> FindProjectById(Guid id)
        {
            var webservice = new HttpClient();
            var result = await webservice.GetAsync(MainService.BaseUrl + "Project/GetById/" + id.ToString());
            var content = await result.Content.ReadAsStringAsync();

            var project = JsonConvert.DeserializeObject<Project>(content);

            return project;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            var webservice = new HttpClient();
            var result = await webservice.GetAsync(MainService.BaseUrl + "Project/GetAll");
            var content = await result.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<Project>>(content);

            return list;
        }

        public Project UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
