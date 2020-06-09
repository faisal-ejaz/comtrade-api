using Comtrade.Api.Core.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Comtrade.Api.Core.Interfaces
{
    /// <summary>
    /// Interface for ComTrade data service implementation
    /// </summary>
    public interface IComtradeDataService
    {
        /// <summary>
        /// Gets the ComTrade data from public API
        /// </summary>
        /// <param name="parameters">Parameters for calling the API</param>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        Task<ComtradeResponse> GetComtradeData(ComTradeParameters parameters,CancellationToken ct);
        /// <summary>
        /// Gets the ComTrade valid reporting countries list
        /// </summary>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        Task<ParametersResponse> GetComtradeReportingCountries(CancellationToken ct);
        /// <summary>
        /// Gets the ComTrade valid partner countries list
        /// </summary>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        Task<ParametersResponse> GetComtradePartnerCountries(CancellationToken ct);
        /// <summary>
        /// Gets the ComTrade valid trade flows list
        /// </summary>
        /// <param name="ct">Cancellation token for the task</param>
        /// <returns></returns>
        Task<ParametersResponse> GetComtradeTradeFlows(CancellationToken ct);

    }
}
