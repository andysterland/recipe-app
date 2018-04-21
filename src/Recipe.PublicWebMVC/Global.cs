using Microsoft.AspNetCore.Hosting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicWebMVC
{
    public class Global
    {
        public static Global Singleton;

        public Uri RestApiUri
        {
            get;
            private set;
        }
        public RestClient ApiClient;

        public Global(IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                RestApiUri = new Uri("http://localhost:64407");
            }
            else
            {
                RestApiUri = new Uri("http://andster-build2018-recipe-api.azurewebsites.net");
            }

            ApiClient = new RestClient(RestApiUri);
        }
    }
}
