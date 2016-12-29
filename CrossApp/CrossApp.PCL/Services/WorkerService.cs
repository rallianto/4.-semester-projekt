using CrossApp.PCL.ServiceModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrossApp.PCL.Services
{
    public interface IWorkerService
    {
        Task<List<Worker>> GetAllWorkers();
        Worker AddWorker(Worker worker);
        Worker FindWorker(Worker worker);
        Worker FindWorkerById(Guid id);
        Worker UpdateWorker(Worker worker);
        bool DeleteWorker(Worker worker);
    }

    public class WorkerService : IWorkerService
    {

        public Worker AddWorker(Worker worker)
        {
            throw new NotImplementedException();
        }

        public bool DeleteWorker(Worker worker)
        {
            throw new NotImplementedException();
        }

        public Worker FindWorker(Worker worker)
        {
            throw new NotImplementedException();
        }

        public Worker FindWorkerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Worker>> GetAllWorkers()
        {
            var webservice = new HttpClient();
            var result = await webservice.GetAsync( MainService.BaseUrl + "api/Worker/GetAllWorkers" );
            var content = await result.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<Worker>>(content);

            return list;
        }

        public Worker UpdateWorker(Worker worker)
        {
            throw new NotImplementedException();
        }
    }
}
