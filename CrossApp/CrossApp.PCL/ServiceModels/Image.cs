using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossApp.PCL.ServiceModels
{
    public class Image
    {
        public Guid Id { get; set; }

        public byte[] ImageBytes { get; set; }

        public string ImageName { get; set; }

        //public Project Project { get; set; }

        public Guid ProjectId { get; set; }
    }
}
