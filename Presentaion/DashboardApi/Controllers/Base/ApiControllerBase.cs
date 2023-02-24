using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Logging;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Application.Exceptions;
using System.Net;

namespace TemplateFw.DashboardApi.Controllers.Base
{
    [ApiController]
    public abstract class ApiControllerBase<TController> : ControllerBase
        where TController : ApiControllerBase<TController>
    {
        private readonly ILogger<TController> _logger;

        public string CurrentUserName => this.User?.Identity?.Name;

        protected bool IsArabic
        {
            get
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                return rqf.RequestCulture.Culture.Name.ToLower().Contains("ar");
            }
        }
        protected EnumLanguage CurrentLanguage
        {
            get
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                return (IsArabic) ? EnumLanguage.Arabic : EnumLanguage.English;
            }
        }
        protected ApiControllerBase(ILogger<TController> logger)
        {
            _logger = logger;
        }

        protected ApiResponse ApiError(ErrorCodes error)
        {
            return new ApiResponse
            {
                ErrorCodes = new int[] {(int) error},
                Status = false,
            };
        }
        protected async Task<ApiResponse> ApiResponse<T>(Func<Task<T>> funcCall, OperationTypes operation = OperationTypes.Unknown)
        {
            try
            {
                var result = funcCall == null ? default : await funcCall.Invoke();
                var response = new ApiResponse
                {
                    Status = true
                };
                if (typeof(T) == typeof(bool))
                {
                    response.Status = Convert.ToBoolean(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return HandleException<T>(ex, operation);
            }
        }
        protected async Task<GenericApiResponse<T>> GenericApiResponse<T>(Func<Task<T>> funcCall, OperationTypes operation= OperationTypes.Unknown)
        {
            try
            {
                var result = funcCall == null ? default : await funcCall.Invoke();
                var response = new GenericApiResponse<T>
                {
                    Data = result,
                    Status = true
                };
                if (typeof(T) == typeof(bool))
                {
                    response.Status = Convert.ToBoolean(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return HandleException<T>(ex, operation);
            }
        }

        protected GenericApiResponse<T> GenericApiResponse<T>(Func<T> funcCall, OperationTypes operation = OperationTypes.Unknown)
        {
            try
            {
                var result = funcCall == null ? default : funcCall.Invoke();
                var response = new GenericApiResponse<T>
                {
                    Data = result,
                    Status = true   
                };
                return response;
            }
            catch (Exception ex)
            {
                return HandleException<T>(ex, operation);
            }
        }

        protected ApiResponse ApiResponse(Action actionCall, OperationTypes operation = OperationTypes.Unknown)
        {
            return GenericApiResponse(() =>
            {
                actionCall();
                return new object();
            });
        }
     

        private GenericApiResponse<T> HandleException<T>(Exception ex, OperationTypes operation)
        {
            GenericApiResponse<T> result = new GenericApiResponse<T>();
            if (ex is BusinessException businessException)
            {
                return HandleBusinessException<T>(businessException, operation);
            }
            else
            {
                HandleRunTimeException<T>(ex, operation);
            }
            return result;
        }
        private GenericApiResponse<T> HandleBusinessException<T>(BusinessException businessException, OperationTypes operation)
        {
            GenericApiResponse<T> result = new GenericApiResponse<T>();
            result.ErrorCodes = businessException?.ErrorCodes?.Select(a => (int)a).ToArray();
            result.ErrorMessages = businessException.ErrorMessages;
            result.StatusCode = HttpStatusCode.OK;
            result.Status = false;
            return result;
        }

        private GenericApiResponse<T> HandleRunTimeException<T>(Exception ex, OperationTypes operation)
        {
            GenericApiResponse<T> result = new GenericApiResponse<T>();
            result.ErrorCodes = new int[] { (int)operation + 1000 };
            result.StatusCode = HttpStatusCode.InternalServerError;
            result.Status = false;
            //log exception
            Task.Run(() => _logger.LogError(ex, ex.Message));
            return result;
        }
    }
}