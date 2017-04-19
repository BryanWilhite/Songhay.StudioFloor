using Prism.Mvvm;
using Songhay.Extensions;
using System.Xml.Linq;

namespace Songhay.StudioFloor.Desktop.Modules.SvgFonts.ViewModels
{
    /// <summary>
    /// SVG Glyph View Model
    /// </summary>
    public class SvgGlyphViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgGlyphViewModel"/> class.
        /// </summary>
        /// <param name="glyph">The glyph.</param>
        public SvgGlyphViewModel(XElement glyph)
        {
            var d = glyph.ToAttributeValueOrDefault("d", string.Empty);
            var unicode = glyph.ToAttributeValueOrDefault("unicode", string.Empty);

            this.EntityDisplayText = unicode;
            this.StreamGeometry = d;
        }

        /// <summary>
        /// Gets or sets the stream geometry.
        /// </summary>
        /// <value>
        /// The stream geometry.
        /// </value>
        public string StreamGeometry
        {
            get { return this._streamGeometry; }
            set { this.SetProperty(ref this._streamGeometry, value); }
        }

        /// <summary>
        /// Gets or sets the entity display text.
        /// </summary>
        /// <value>
        /// The entity display text.
        /// </value>
        public string EntityDisplayText
        {
            get { return this._entityDisplayText; }
            set { this.SetProperty(ref this._entityDisplayText, value); }
        }

        string _entityDisplayText;
        string _streamGeometry;
    }
}
