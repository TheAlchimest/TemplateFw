using System;
using System.Collections.Generic;
using System.Net;

namespace TemplateFw.Shared.Domain.GenericResponse
{
    public class GenericApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }

    public class ApiResponse
    {
        public string ErrorMessages { get; set; }
        public bool Status { get; set; }
        public int[] ErrorCodes { get; set; } = Array.Empty<int>();
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }

    public class WebResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool Status { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }

        public string ErrorCodes { get; set; }

        public List<string> Messages { get; set; }
        public string Message {
            set {
                Messages.Add(value);
            }
        }
        public WebResponse()
        {
            Messages = new List<string>();
        }
    }

    public class GenericWebResponse<T> : WebResponse
    {
        public T Data { get; set; }
    }
}
