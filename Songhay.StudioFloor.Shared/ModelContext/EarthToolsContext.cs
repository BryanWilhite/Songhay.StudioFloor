using Songhay.StudioFloor.Shared.Models;
using System;
using System.Xml.Linq;

namespace Songhay.StudioFloor.Shared.ModelContext
{
    /// <summary>
    /// EF Model Context for EarthTools.org data.
    /// </summary>
    public static class EarthToolsContext
    {
        /// <summary>
        /// Gets the earth tools sunrise sunset model.
        /// </summary>
        /// <param name="remoteDocument">The remote document.</param>
        /// <returns></returns>
        public static EarthToolsSunriseSunsetModel GetEarthToolsSunriseSunsetModel(string remoteDocument)
        {
            var doc = XDocument.Parse(remoteDocument);
            return GetEarthToolsSunriseSunsetModel(doc);
        }

        /// <summary>
        /// Gets the earth tools sunrise sunset model.
        /// </summary>
        /// <param name="remoteDocument">The remote document.</param>
        public static EarthToolsSunriseSunsetModel GetEarthToolsSunriseSunsetModel(XDocument remoteDocument)
        {
            if (remoteDocument == null) throw new ArgumentNullException("remoteDocument", "The remote document is null.");

            var model = new EarthToolsSunriseSunsetModel();
            string nodeValue;
            byte day; byte month; TimeSpan time;

            nodeValue = remoteDocument.Root.Element("date").Element("day")?.Value;
            day = byte.Parse(nodeValue);

            nodeValue = remoteDocument.Root.Element("date").Element("month")?.Value;
            month = byte.Parse(nodeValue);

            nodeValue = remoteDocument.Root.Element("evening").Element("sunset")?.Value;
            time = TimeSpan.Parse(nodeValue);
            model.EveningSunset = new DateTime(DateTime.Now.Year, month, day, time.Hours, time.Minutes, time.Seconds);

            nodeValue = remoteDocument.Root.Element("location").Element("latitude")?.Value;
            model.LocationLatitude = decimal.Parse(nodeValue);

            nodeValue = remoteDocument.Root.Element("location").Element("longitude")?.Value;
            model.LocationLongitude = decimal.Parse(nodeValue);

            nodeValue = remoteDocument.Root.Element("morning").Element("sunrise")?.Value;
            time = TimeSpan.Parse(nodeValue);
            model.MorningSunrise = new DateTime(DateTime.Now.Year, month, day, time.Hours, time.Minutes, time.Seconds);

            return model;
        }

        /// <summary>
        /// Inspects the remote document.
        /// </summary>
        /// <param name="remoteDocument">The remote document.</param>
        public static bool InspectRemoteDocument(XDocument remoteDocument)
        {
            var isCorrectAssertion = (remoteDocument.Root.Name == "sun");
            return isCorrectAssertion;
        }
    }
}
