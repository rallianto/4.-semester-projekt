using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossApp.PCL.Services
{
    public static class MainService
    {
        private static string _baseUrl = "http://jobandoffer.boligbuen.dk/";
        public static string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
        }
    }
}
