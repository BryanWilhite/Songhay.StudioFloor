using Songhay.StudioFloor.Shared.Models;
using System;
using System.Threading.Tasks;

namespace Songhay.StudioFloor.Shared.Services
{
    public interface IRestModelContextService
    {
        Task<EarthToolsSunriseSunsetModel> GetEarthToolsSunriseSunsetModelAsync(Uri uri);

        Task<NoaaWeatherModel> GetNoaaWeatherModelAsync(Uri uri);
    }
}