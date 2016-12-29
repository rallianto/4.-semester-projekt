using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAndOffer.Core.Interfaces
{
    public interface IMongoModel
    {
        Guid Id { get; set; }
    }
}
