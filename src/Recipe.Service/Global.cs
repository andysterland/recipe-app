using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipe.Service
{
    public static class Global
    {
        private static TelemetryClient _AI;
        public static TelemetryClient AI
        {
            get
            {
                if (_AI == null)
                {
                    _AI = new TelemetryClient();
                }
                return _AI;
            }
        }
    }
}