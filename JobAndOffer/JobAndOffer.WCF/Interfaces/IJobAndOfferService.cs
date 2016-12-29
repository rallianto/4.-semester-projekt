using JobAndOffer.Core.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JobAndOffer.WCF
{
    [ServiceContract]
    public interface IJobAndOfferService
    {
        #region Worker
        [OperationContract]
        Worker AddWorker(Worker worker);
        [OperationContract]
        Worker FindWorker(Worker worker);
        [OperationContract]
        Worker FindWorkerById(Guid id);
        [OperationContract]
        Worker UpdateWorker(Worker worker);
        [OperationContract]
        bool DeleteWorker(Worker worker);
        #endregion

        #region Project
        [OperationContract]
        Project AddProject(Project project);
        [OperationContract]
        Project FindProject(Project project);
        [OperationContract]
        Project FindProjectById(Guid id);
        [OperationContract]
        Project UpdateProject(Project project);
        [OperationContract]
        bool DeleteProject(Project project);
        #endregion
    }
}
