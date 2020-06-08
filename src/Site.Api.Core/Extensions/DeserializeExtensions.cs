using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Comtrade.Api.Core.Extensions
{
    /// <summary>
    /// Extension method for the .net core de-serialize
    /// </summary>
    public static class DeserializeExtensions
    {
        /// <summary>
        /// Default options to be used
        /// </summary>
        private static readonly JsonSerializerOptions _defaultOptions = new JsonSerializerOptions() 
        {
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
        };

        /// <summary>
        /// De-serialize the provided string content 
        /// </summary>
        /// <typeparam name="T">Type for the de-serialization</typeparam>
        /// <param name="jsonString">String content of the HTTP response</param>
        /// <returns></returns>
        public static T Deserialize<T>(this string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString, _defaultOptions);
        }

        /// <summary>
        /// De-serialize the provided stream content 
        /// </summary>
        /// <typeparam name="T">Type for the de-serialization</typeparam>
        /// <param name="contentStream">Content Steam of the HTTP response</param>
        /// <param name="cancellationToken">Cancellation token for async operation</param>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(this Stream contentStream,CancellationToken cancellationToken)
        {
            return await JsonSerializer.DeserializeAsync<T>(contentStream, _defaultOptions, cancellationToken);
        }

    }
}
