using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TemplateFw.Shared.Application.Exceptions;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;

namespace TemplateFw.Shared.Domain.GenericResponse
{
    public class GenericApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }

    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool Status { get; set; }
        public List<CommonError> Errors { get; set; } = new List<CommonError>();
       

    }

    public class CommonWebResponse
    {
        public HttpStatusCode StatusCode { get; set; } = default;
        public bool Status { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public List<CommonError> Errors { get; set; } = new List<CommonError>();
        public string Message { get; set; }
    }

    public class GenericWebResponse<T> : CommonWebResponse
    {
        public T Data { get; set; }
        public GenericWebResponse()
        {

        }
        public GenericWebResponse(CommonWebResponse webResponse)
        {
            StatusCode = webResponse.StatusCode;
            Status = webResponse.Status;
            Title = webResponse.Title;
            Icon = webResponse.Icon;
            Errors = webResponse.Errors;
            Message = webResponse.Message;
        }
    }
    public class CommonError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }
   
}
