namespace TemplateFw.Dashboard.Controllers
{
    public class WebBaseController<C> : LocalizedController where C : WebBaseController<C>
    {
        private ILogger<C> _logger;

        protected ILogger<C> Logger => _logger ??= HttpContext.RequestServices.GetService<ILogger<C>>();

        public WebBaseController() : base()
        {
        }

        #region  GetActionName
        public string GetActionName()
        {
            var routeDateValues = this.RouteData.Values;
            if (routeDateValues.ContainsKey("action"))
            {
                return (string)routeDateValues["action"];
            }

            return string.Empty;
        }
        #endregion

        #region  GetControllerName
        public string GetControllerName()
        {
            var routeDateValues = RouteData.Values;
            if (routeDateValues.ContainsKey("controller"))
            {
                return (string)routeDateValues["controller"];
            }

            return string.Empty;
        }
        #endregion


        #region  GetErrorMessage

        public string PopulateErrorMessagesFromErrorCodes(int[] errors)
        {
            string message = string.Empty;
            if (errors != null && errors.Length > 0)
            {
                errors.ToList().ForEach(e => message += Localizer[$"Exception{e}"] + "\n");
            }
            return message;
        }
        #endregion





        /*
        protected async Task<AttachmentDto> DownloadFile(string filename)
        {
        }

        protected async Task<string> UploadFile(AttachmentDto attachment)
        {
        }
        */
    }
}

