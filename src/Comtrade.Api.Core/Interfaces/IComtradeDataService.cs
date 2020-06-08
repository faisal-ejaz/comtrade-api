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
        Task<ComtradeResponse> GetComtradeData(ComTradeParameters parameters,CancellationToken ct = default(CancellationToken));
    }
}
