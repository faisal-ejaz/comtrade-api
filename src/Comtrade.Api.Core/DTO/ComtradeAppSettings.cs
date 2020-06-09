using System;
using System.Collections.Generic;
using System.Text;

namespace Comtrade.Api.Core.DTO
{
    /// <summary>
    /// ComTrade application settings DTO
    /// </summary>
    public class ComtradeAppSettings
    {
        public string BasePath { get; set; }
        public string ReportersPath { get; set; }
        public string PartnersPath { get; set; }
        public string TradeFlowsPath { get; set; }
    }
}
