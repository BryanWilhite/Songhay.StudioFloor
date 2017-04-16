using Songhay.StudioFloor.Shared.Models;
using System;
using System.Xml.Linq;

namespace Songhay.StudioFloor.Shared.ModelContext
{
    /// <summary>
    /// Static helpers for <see cref="NoaaWeatherModel"/>
    /// </summary>
    public static class NoaaWeatherContext
    {
        /// <summary>
        /// Gets the NOAA weather model.
        /// </summary>
        /// <param name="remoteDocument">The remote document.</param>
        public static NoaaWeatherModel GetNoaaWeatherModel(string remoteDocument)
        {
            var doc = XDocument.Parse(remoteDocument);
            return GetNoaaWeatherModel(doc);
        }

        /// <summary>
        /// Gets the NOAA weather model.
        /// </summary>
        /// <param name="remoteDocument">The remote document.</param>
        public static NoaaWeatherModel GetNoaaWeatherModel(XDocument remoteDocument)
        {
            if (remoteDocument == null) throw new ArgumentNullException("remoteDocument", "The remote document is null.");

            var model = new NoaaWeatherModel();
            string nodeValue;

            nodeValue = remoteDocument.Root.Element("copyright_url")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.CopyrightUri = new Uri(nodeValue);

            nodeValue = remoteDocument.Root.Element("credit")?.Value;
            model.Credit = nodeValue;

            nodeValue = remoteDocument.Root.Element("credit_URL")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.CreditUri = new Uri(nodeValue);

            nodeValue = remoteDocument.Root.Element("dewpoint_string")?.Value;
            model.DewPointDisplayText = nodeValue;

            nodeValue = remoteDocument.Root.Element("latitude")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.Latitude = Convert.ToSingle(nodeValue);

            nodeValue = remoteDocument.Root.Element("location")?.Value;
            model.Location = nodeValue;

            nodeValue = remoteDocument.Root.Element("image").Element("url")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.LogoUri = new Uri(nodeValue);

            nodeValue = remoteDocument.Root.Element("longitude")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.Longitude = Convert.ToSingle(nodeValue);

            nodeValue = remoteDocument.Root.Element("observation_time_rfc822")?.Value;
            //if (!string.IsNullOrEmpty(nodeValue)) model.ObservationTime = FrameworkTypeUtility.ParseRfc822DateTime(nodeValue);

            nodeValue = remoteDocument.Root.Element("pressure_string")?.Value;
            model.PressureDisplayText = nodeValue;

            nodeValue = remoteDocument.Root.Element("relative_humidity")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.RelativeHumidity = Convert.ToByte(nodeValue);

            nodeValue = remoteDocument.Root.Element("temp_c")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.TemperatureCelsius = Convert.ToSingle(nodeValue);

            nodeValue = remoteDocument.Root.Element("temperature_string")?.Value;
            model.TemperatureDisplayText = nodeValue.Replace(" F", "°F").Replace(" C", "°C");

            nodeValue = remoteDocument.Root.Element("temp_f")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.TemperatureFahrenheit = Convert.ToSingle(nodeValue);

            nodeValue = remoteDocument.Root.Element("two_day_history_url")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.TwoDayHistoryUri = new Uri(nodeValue);

            nodeValue = remoteDocument.Root.Element("visibility_mi")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.Visibility = Convert.ToSingle(nodeValue);

            nodeValue = remoteDocument.Root.Element("weather")?.Value;
            model.Weather = nodeValue;

            nodeValue = remoteDocument.Root.Element("icon_url_base")?.Value;
            if (!string.IsNullOrEmpty(nodeValue)) model.WeatherIconBase = new Uri(nodeValue);

            nodeValue = remoteDocument.Root.Element("icon_url_name")?.Value;
            model.WeatherIconFile = nodeValue;

            nodeValue = remoteDocument.Root.Element("windchill_string")?.Value;
            model.WindChillDisplayText = nodeValue;

            nodeValue = remoteDocument.Root.Element("wind_string")?.Value;
            model.WindDisplayText = nodeValue;

            return model;
        }

        /// <summary>
        /// Inspects the remote document.
        /// </summary>
        /// <param name="remoteDocument">The remote document.</param>
        public static bool InspectRemoteDocument(XDocument remoteDocument)
        {
            var isCorrectAssertion = (remoteDocument.Root.Name == "current_observation");
            return isCorrectAssertion;
        }
    }
}
