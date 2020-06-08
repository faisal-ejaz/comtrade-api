using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Comtrade.Api.Core.Interfaces;
using Comtrade.Api.Core.DTO;
using Microsoft.Extensions.Logging;

namespace Comtrade.Api.Controllers
{
    public class ComtradeController : BaseController<ComtradeController>
    {
        #region Members & Constructor
        private readonly IComtradeDataService _comtradeDataService;
        public ComtradeController(IComtradeDataService comtradeDataService,ILogger<ComtradeController> logger) : base(logger)
        {
            _comtradeDataService = comtradeDataService;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<APIResponse<ComtradeResponse>> GetComtradeData(ComTradeParameters parameters)
        {
            try
            {
                return GenerateSuccessResponse<ComtradeResponse>(await _comtradeDataService.GetComtradeData(parameters), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error occurred while calling ComTrade API");
                return GenerateErrorResponse<ComtradeResponse>();
            }
        }

        #endregion
    }
}