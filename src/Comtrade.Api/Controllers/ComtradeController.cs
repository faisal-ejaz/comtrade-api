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
using System.Threading;

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
        /// <summary>
        /// Gets the ComTrade data from the API
        /// </summary>
        /// <param name="parameters">Parameters for calling the ComTrade API</param>
        /// <param name="ct">Cancellation token for the request</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<APIResponse<ComtradeResponse>> GetComtradeData(ComTradeParameters parameters, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (parameters == null)
                {
                    return GenerateErrorResponse<ComtradeResponse>(HttpStatusCode.BadRequest, $"{nameof(parameters)} can not be empty");
                }
                return GenerateSuccessResponse<ComtradeResponse>(await _comtradeDataService.GetComtradeData(parameters,ct), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                base.LogException(ex,"Error occurred while getting ComTrade data from API");
                return GenerateErrorResponse<ComtradeResponse>();
            }
        }

        /// <summary>
        /// Gets the ComTrade valid reporting countries list
        /// </summary>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<APIResponse<ParametersResponse>> GetComtradeReportingCountries(CancellationToken ct)
        {
            try
            {
                return GenerateSuccessResponse<ParametersResponse>(await _comtradeDataService.GetComtradeReportingCountries(ct), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                base.LogException(ex, "Error occurred while getting ComTrade Partner Countries from API");
                return GenerateErrorResponse<ParametersResponse>();
            }
        }

        /// <summary>
        /// Gets the ComTrade valid partner countries list
        /// </summary>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<APIResponse<ParametersResponse>> GetComtradePartnerCountries(CancellationToken ct)
        {
            try
            {
                return GenerateSuccessResponse<ParametersResponse>(await _comtradeDataService.GetComtradePartnerCountries(ct), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                base.LogException(ex, "Error occurred while getting ComTrade Partner Countries from API");
                return GenerateErrorResponse<ParametersResponse>();
            }
        }

        /// <summary>
        /// Gets the ComTrade valid trade flows list
        /// </summary>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<APIResponse<ParametersResponse>> GetComtradeTradeFlows(CancellationToken ct)
        {
            try
            {
                return GenerateSuccessResponse<ParametersResponse>(await _comtradeDataService.GetComtradeTradeFlows(ct), HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                base.LogException(ex, "Error occurred while getting ComTrade Partner Countries");
                return GenerateErrorResponse<ParametersResponse>();
            }
        }

        #endregion
    }
}