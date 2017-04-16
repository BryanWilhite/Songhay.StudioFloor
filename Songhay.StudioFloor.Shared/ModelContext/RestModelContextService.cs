using Songhay.StudioFloor.Shared.Models;
using Songhay.StudioFloor.Shared.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Songhay.StudioFloor.Shared.ModelContext
{
    /// <summary>
    /// REST Model Context Service
    /// </summary>
    public class RestModelContextService : IRestModelContextService
    {
        /// <summary>
        /// Gets the earth tools sunrise sunset model asynchronous.
        /// </summary>
        /// <param name="uri">The URI.</param>
        public async Task<EarthToolsSunriseSunsetModel> GetEarthToolsSunriseSunsetModelAsync(Uri uri)
        {
            var xml = await LoadXml(uri);
            return EarthToolsContext.GetEarthToolsSunriseSunsetModel(xml);
        }

        /// <summary>
        /// Gets the noaa weather model asynchronous.
        /// </summary>
        /// <param name="uri">The URI.</param>
        public async Task<NoaaWeatherModel> GetNoaaWeatherModelAsync(Uri uri)
        {
            var xml = await LoadXml(uri);
            return NoaaWeatherContext.GetNoaaWeatherModel(xml);
        }

        async Task<string> LoadXml(Uri uri)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(uri);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
