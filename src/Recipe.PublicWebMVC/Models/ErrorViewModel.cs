using System;
using System.Net;

namespace PublicWebMVC.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string Title;
        public string Description;
        public HttpStatusCode StatusCode;

        public ErrorViewModel(string requestId, string title, string description, HttpStatusCode statusCode )
        {
            RequestId = requestId;
            Title = title;
            Description = description;
            StatusCode = statusCode;
        }
    }
}