using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace Comtrade.Api.Service
{
    /// <summary>
    /// Base service for all the ComTrade API services
    /// </summary>
    /// <typeparam name="T">Type of the derived service</typeparam>
    public class BaseService<T>
    {
        #region Members & Constructor
        protected readonly IHttpClientFactory _clientFactory;
        protected readonly ILogger<T> _logger;
        protected BaseService(IHttpClientFactory clientFactory, ILogger<T> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Logs the execution information for an action
        /// </summary>
        /// <param name="name">Name of the action</param>
        protected void LogActionCall(string name)
        {
            _logger.LogInformation("Called Action: {name}", name);
        }
        #endregion
    }
}
