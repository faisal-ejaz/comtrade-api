using System;
using System.Collections.Generic;
using System.Text;

namespace Comtrade.Api.Core.DTO
{
    /// <summary>
    /// Data transfer object for API Response
    /// </summary>
    /// <typeparam name="T">Type of the object returned in Payload</typeparam>
    public class APIResponse<T>
    {
        /// <summary>
        /// Indicator for success of the execution
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Status code of the operation
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Message to be sent in response
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Response data object
        /// </summary>
        public T Payload { get; set; }
    }
}
