using Microsoft.Extensions.Logging;
using Comtrade.Api.Core.Interfaces;
using Comtrade.Api.Core.DTO;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Comtrade.Api.Core.Constants;
using Comtrade.Api.Core.Extensions;

namespace Comtrade.Api.Service
{
    /// <summary>
    /// ComTrade data retrieval service
    /// </summary>
    public class ComtradeDataService : BaseService<ComtradeDataService>, IComtradeDataService
    {
        #region Members & Constructor
        public ComtradeDataService(IHttpClientFactory clientFactory, 
                                    ILogger<ComtradeDataService> logger) : base(clientFactory, logger)
        {
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the ComTrade data from public API
        /// </summary>
        /// <param name="parameters">Parameters for calling the API</param>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        public async Task<ComtradeResponse> GetComtradeData(ComTradeParameters parameters,CancellationToken cancellationToken)
        {
            string requestURL = await GenerateRequestURL(parameters,cancellationToken);

            using (var response = await GetResponse(requestURL, cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                var contentStream = await GetResponseStream(response);

                return await DeserializeResponse<ComtradeResponse>(contentStream, cancellationToken);
            }
        }
        #endregion

        #region Private Methods
        private HttpClient GetComtradeClient()
        {
            return _clientFactory.CreateClient(AppSettingConstants.ComtradeClientName);
        }
        private async Task<HttpResponseMessage> GetResponse(string url, CancellationToken cancellationToken)
        {
            var client = GetComtradeClient();
           return await client.GetAsync(url, cancellationToken);
        }
        private async Task<Stream> GetResponseStream(HttpResponseMessage response)
        {
           return await response.Content.ReadAsStreamAsync();
        }
        private async Task<T> DeserializeResponse<T>(Stream contentStream, CancellationToken cancellationToken)
        {
            return await contentStream.DeserializeAsync<T>(cancellationToken);
        }
        private async Task<string> GenerateRequestURL(ComTradeParameters parameters, CancellationToken cancellationToken)
        {
            //will be replace with logic for call based on actual parameters
            return "?max=10&type=C&freq=A&px=HS&ps=2018%2C2017%2C2016&r=124&p=36&rg=all&cc=TOTAL&uitoken=7b5bdafefc464489fb8123e5c6452328";
        }
        #endregion
    }
}
