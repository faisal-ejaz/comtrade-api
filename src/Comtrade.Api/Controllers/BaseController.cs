using Microsoft.AspNetCore.Mvc;
using Comtrade.Api.Core.Constants;
using System.Net;
using Microsoft.Extensions.Logging;
using System;
using Comtrade.Api.Core.DTO;

namespace Comtrade.Api.Controllers
{
    /// <summary>
    /// Base class for all the ComTrade API public controllers
    /// </summary>
    /// <typeparam name="T">Type of the derived controller</typeparam>
    public class BaseController<T> : ControllerBase
    {
        #region Members & Constructor
        protected readonly ILogger<T> _logger;
        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Creates a success response for the API call
        /// </summary>
        /// <typeparam name="TData">Type of the response object</typeparam>
        /// <param name="data">Data in the response</param>
        /// <param name="statusCode">Status code for the execution</param>
        /// <param name="message">Message for the execution</param>
        /// <returns></returns>
        protected APIResponse<TData> GenerateSuccessResponse<TData>(TData data, HttpStatusCode statusCode = HttpStatusCode.OK, string message = null)
        {
            return new APIResponse<TData>
            {
                Message = message ?? StatusMessages.SuccessMessage,
                Payload = data,
                StatusCode = (int)statusCode,
                IsSuccess = true,
            };
        }
        /// <summary>
        /// Creates a success response for the API call
        /// </summary>
        /// <typeparam name="TData">Type of the response object</typeparam>
        /// <param name="statusCode">Status code for the execution</param>
        /// <param name="errorMessage">Error message for the failed execution</param>
        /// <returns></returns>
        protected APIResponse<TData> GenerateErrorResponse<TData>(HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string errorMessage = null)
        {
            return new APIResponse<TData>
            {
                StatusCode = (int)statusCode,
                IsSuccess = false,
                Message = errorMessage ?? StatusMessages.ErrorMessage
            };
        }

        /// <summary>
        /// Logs the action call information
        /// </summary>
        /// <param name="methodName">Name of the method called</param>
        protected void LogActionCall(string methodName)
        {
            _logger.LogInformation("Called Action: {name}", methodName);
        }

        /// <summary>
        /// Logs the exception in execution
        /// </summary>
        /// <param name="exception">Exception object</param>
        /// <param name="message">Message for the exception</param>
        protected void LogException(Exception exception,string message = null)
        {
            _logger.LogError(exception, message);
        }
        #endregion
    }
}