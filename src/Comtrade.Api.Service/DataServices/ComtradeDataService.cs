using Microsoft.Extensions.Logging;
using Comtrade.Api.Core.Interfaces;
using Comtrade.Api.Core.DTO;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Comtrade.Api.Core.Constants;
using Comtrade.Api.Core.Extensions;
using Microsoft.Extensions.Options;

namespace Comtrade.Api.Service.DataServices
{
    /// <summary>
    /// ComTrade data retrieval service
    /// </summary>
    public class ComtradeDataService : BaseService<ComtradeDataService>, IComtradeDataService
    {
        #region Members & Constructor
        private readonly IOptions<ComtradeAppSettings> _comtradeSettings;
        public ComtradeDataService(IHttpClientFactory clientFactory, 
                                    ILogger<ComtradeDataService> logger,
                                    IOptions<ComtradeAppSettings> comtradeSettings) : base(clientFactory, logger)
        {
            this._comtradeSettings = comtradeSettings;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the ComTrade data from public API
        /// </summary>
        /// <param name="parameters">Parameters for calling the API</param>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        public async Task<ComtradeResponse> GetComtradeData(ComTradeParameters parameters, CancellationToken ct)
        {
            string requestURL = await GenerateDataRequestURL(parameters,ct);

            return await GetApiResponse<ComtradeResponse>(requestURL, ct);
        }

        /// <summary>
        /// Gets the ComTrade valid reporting countries list
        /// </summary>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        public async Task<ParametersResponse> GetComtradeReportingCountries(CancellationToken ct)
        {
            string requestURL = _comtradeSettings.Value.ReportersPath;

            return await GetApiResponse<ParametersResponse>(requestURL, ct);
        }

        /// <summary>
        /// Gets the ComTrade valid partner countries list
        /// </summary>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        public async Task<ParametersResponse> GetComtradePartnerCountries(CancellationToken ct)
        {
            string requestURL = _comtradeSettings.Value.PartnersPath;

            return await GetApiResponse<ParametersResponse>(requestURL, ct);
        }

        /// <summary>
        /// Gets the ComTrade valid trade flows list
        /// </summary>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        public async Task<ParametersResponse> GetComtradeTradeFlows(CancellationToken ct)
        {
            string requestURL = _comtradeSettings.Value.TradeFlowsPath;

            return await GetApiResponse<ParametersResponse>(requestURL, ct);
        }
        #endregion

        #region Private Methods
        private async Task<T> GetApiResponse<T>(string requestURL, CancellationToken ct)
        {
            using (var response = await GetResponse(requestURL, ct))
            {
                response.EnsureSuccessStatusCode();

                var contentStream = await GetResponseStream(response);

                return await DeserializeResponse<T>(contentStream, ct);
            }
        }
        private HttpClient GetComtradeClient()
        {
            return _clientFactory.CreateClient(AppSettingConstants.ComtradeClientName);
        }
        private async Task<HttpResponseMessage> GetResponse(string url, CancellationToken ct)
        {
            var client = GetComtradeClient();
           return await client.GetAsync(url, ct);
        }
        private async Task<Stream> GetResponseStream(HttpResponseMessage response)
        {
           return await response.Content.ReadAsStreamAsync();
        }
        private async Task<T> DeserializeResponse<T>(Stream contentStream, CancellationToken ct)
        {
            return await contentStream.DeserializeAsync<T>(ct);
        }
        private async Task<string> GenerateDataRequestURL(ComTradeParameters parameters, CancellationToken ct)
        {
            //will be replace with logic for call based on actual parameters
            return "?max=10&type=C&freq=A&px=HS&ps=2018%2C2017%2C2016&r=124&p=36&rg=all&cc=TOTAL&uitoken=7b5bdafefc464489fb8123e5c6452328";
        }
        #endregion
    }
}
