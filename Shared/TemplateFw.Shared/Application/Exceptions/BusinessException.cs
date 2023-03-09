using System;
using TemplateFw.Shared.Domain.Enums;

namespace TemplateFw.Shared.Application.Exceptions
{
    public class BusinessException : Exception
    {
        public ErrorCodes[] ErrorCodes { get; set; }
        public string ErrorMessages { get; set; }

        #region Constructor

        public BusinessException(Exception ex = null, params ErrorCodes[] errorCodes)
            : base("", ex)
        {
            this.ErrorCodes = errorCodes;
        }

        public BusinessException(params ErrorCodes[] errorCodes)
            : base()
        {
            this.ErrorCodes = errorCodes;
        }

        public BusinessException(string message)
            : base()
        {
            this.ErrorMessages = message;
        }

        #endregion
    }
}
