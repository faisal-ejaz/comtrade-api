using System;
using System.Collections.Generic;
using System.Text;

namespace Comtrade.Api.Core.DTO
{
    /// <summary>
    /// Response DTO for ComTrade valid parameters
    /// </summary>
    public class ParametersResponse
    {
        public bool More { get; set; }

        public Result[] Results { get; set; }
    }

    public class Result
    {
        public string Id { get; set; }

        public string Text { get; set; }
    }

}
