using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrossApp.PCL.ServiceModels
{
    public class Project
    {
        public Guid Id { get; set; }

        public List<Offer> Offers { get; set; }

        public string ProjectDescription { get; set; }

        public string ProjectTitel { get; set; }

        public List<Image> Images { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public Provinces Province { get; set; }

        public List<JobTypes> JobType { get; set; }

        public Image FirstImage { get {
                if (Images != null && Images.Count > 0) return Images.FirstOrDefault(); return null;
            } }

        //static readonly Dictionary<Provinces, string> ProvinceNames = new Dictionary<Provinces, string>
        //{
        //    { Provinces.KøbenhavnsBy, "Københavns By" },
        //    { Provinces.KøbenhavnsOmegn, "Københavns omegn" },
        //    { Provinces.Nordsjælland, "Nordsjælland" },
        //    { Provinces.Bornholm, "Bornholm" },
        //    { Provinces.Østsjælland, "Østsjælland" },
        //    { Provinces.VestOgSydsjælland, "Vest- & Sydsjælland" },
        //    { Provinces.Fyn, "Fyn" },
        //    { Provinces.Sydjylland, "Sydjylland" },
        //    { Provinces.Vestjylland, "Vestjylland" },
        //    { Provinces.Østjylland, "Østjylland" },
        //    { Provinces.Nordjylland, "Nordjylland" },
        //};
        //public static string ConvertProvinces(Provinces province)
        //{
        //    string name;
        //    return (ProvinceNames.TryGetValue(province, out name)) ? name : province.ToString();
        //}
    }

    public enum Provinces
    {
        KøbenhavnsBy = 0,
        KøbenhavnsOmegn = 1,
        Nordsjælland = 2,
        Bornholm = 3,
        Østsjælland = 4,
        VestOgSydsjælland = 5,
        Fyn = 6,
        Sydjylland = 7,
        Vestjylland = 8,
        Østjylland = 9,
        Nordjylland = 10,
    }

    public enum JobTypes
    {
        Murer = 0,
        Tømrer = 1,
        VVS = 2,
        Elektriker = 3,
        Transport = 4,
        Andet = 5
    }
}
