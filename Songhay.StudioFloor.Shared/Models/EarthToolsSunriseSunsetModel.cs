using System;

namespace Songhay.StudioFloor.Shared.Models
{
    /// <summary>
    /// Models Sunrise/Sunset data
    /// </summary>
    /// <remarks>
    /// This is a partial representation of the schema
    ///  from Earthtools.org
    /// [http://www.earthtools.org/sun.xsd]
    /// </remarks>
    public class EarthToolsSunriseSunsetModel
    {
        /// <summary>
        /// Gets or sets the location latitude.
        /// </summary>
        /// <value>
        /// The location latitude.
        /// </value>
        public decimal LocationLatitude { get; set; }

        /// <summary>
        /// Gets or sets the location longitude.
        /// </summary>
        /// <value>
        /// The location longitude.
        /// </value>
        public decimal LocationLongitude { get; set; }

        /// <summary>
        /// Gets or sets the evening sunset.
        /// </summary>
        /// <value>
        /// The evening sunset.
        /// </value>
        public DateTime EveningSunset { get; set; }

        /// <summary>
        /// Gets or sets the morning sunrise.
        /// </summary>
        /// <value>
        /// The morning sunrise.
        /// </value>
        public DateTime MorningSunrise { get; set; }

        public override string ToString()
        {
            return string.Format("Sunset: {0}, Sunrise: {1}, Longitude: {2}, Latitude: {3}",
                this.EveningSunset, this.MorningSunrise, this.LocationLongitude, this.LocationLatitude);
        }
    }
}
