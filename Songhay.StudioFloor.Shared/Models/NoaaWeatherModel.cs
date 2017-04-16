using System;

namespace Songhay.StudioFloor.Shared.Models
{
    /// <summary>
    /// NOAA Weather Model
    /// </summary>
    /// <remarks>
    /// This is a partial representation of the schema
    /// from National Weather Service of National Oceanic and Atmospheric Administration (NOAA)
    /// [http://www.weather.gov/view/current_observation.xsd]
    /// </remarks>
    public class NoaaWeatherModel
    {
        /// <summary>
        /// Gets or sets the copyright URI.
        /// </summary>
        /// <value>
        /// The copyright URI.
        /// </value>
        public Uri CopyrightUri { get; set; }

        /// <summary>
        /// Gets or sets the credit.
        /// </summary>
        /// <value>
        /// The credit.
        /// </value>
        public string Credit { get; set; }

        /// <summary>
        /// Gets or sets the credit URI.
        /// </summary>
        /// <value>
        /// The credit URI.
        /// </value>
        public Uri CreditUri { get; set; }

        /// <summary>
        /// Gets or sets the logo URI.
        /// </summary>
        /// <value>
        /// The logo URI.
        /// </value>
        public Uri LogoUri { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public float Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public float Longitude { get; set; }

        /// <summary>
        /// Gets or sets the observation time.
        /// </summary>
        /// <value>
        /// The observation time.
        /// </value>
        public DateTime ObservationTime { get; set; }

        /// <summary>
        /// Gets or sets the weather.
        /// </summary>
        /// <value>
        /// The weather.
        /// </value>
        public string Weather { get; set; }

        /// <summary>
        /// Gets or sets the temperature display text.
        /// </summary>
        /// <value>
        /// The temperature display text.
        /// </value>
        public string TemperatureDisplayText { get; set; }

        /// <summary>
        /// Gets or sets the temperature (Fahrenheit).
        /// </summary>
        /// <value>
        /// The temperature Fahrenheit.
        /// </value>
        public float TemperatureFahrenheit { get; set; }

        /// <summary>
        /// Gets or sets the temperature (Celsius).
        /// </summary>
        /// <value>
        /// The temperature Celsius.
        /// </value>
        public float TemperatureCelsius { get; set; }

        /// <summary>
        /// Gets or sets the relative humidity.
        /// </summary>
        /// <value>
        /// The relative humidity.
        /// </value>
        public byte RelativeHumidity { get; set; }

        /// <summary>
        /// Gets or sets the wind display text.
        /// </summary>
        /// <value>
        /// The wind display text.
        /// </value>
        public string WindDisplayText { get; set; }

        /// <summary>
        /// Gets or sets the wind chill display text.
        /// </summary>
        /// <value>
        /// The wind chill display text.
        /// </value>
        public string WindChillDisplayText { get; set; }

        /// <summary>
        /// Gets or sets the pressure display text.
        /// </summary>
        /// <value>
        /// The pressure display text.
        /// </value>
        public string PressureDisplayText { get; set; }

        /// <summary>
        /// Gets or sets the dew point display text.
        /// </summary>
        /// <value>
        /// The dew point display text.
        /// </value>
        public string DewPointDisplayText { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        /// <value>
        /// The visibility.
        /// </value>
        public float Visibility { get; set; }

        /// <summary>
        /// Gets or sets the two day history URI.
        /// </summary>
        /// <value>
        /// The two day history URI.
        /// </value>
        public Uri TwoDayHistoryUri { get; set; }

        /// <summary>
        /// Gets or sets the weather icon base.
        /// </summary>
        /// <value>
        /// The weather icon base.
        /// </value>
        public Uri WeatherIconBase { get; set; }

        /// <summary>
        /// Gets or sets the weather icon file.
        /// </summary>
        /// <value>
        /// The weather icon file.
        /// </value>
        public string WeatherIconFile { get; set; }

        public override string ToString()
        {
            return string.Format("Location: {0}, Temp: {1}", this.Location, this.TemperatureDisplayText);
        }
    }
}
