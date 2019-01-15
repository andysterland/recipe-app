using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Hosting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Monolith
{
    public class Global
    {
        public static Global Singleton
        {
            get;
            set;
        }
        
        public TelemetryClient AI
        {
            get;
            private set;
        }
        
        public string DataPath
        {
            get;
            private set;
        }

        public Global(IHostingEnvironment  env)
        {
            AI = new TelemetryClient();
            DataPath = Path.Combine(env.ContentRootPath, "App_Data");
        }
    }
}
