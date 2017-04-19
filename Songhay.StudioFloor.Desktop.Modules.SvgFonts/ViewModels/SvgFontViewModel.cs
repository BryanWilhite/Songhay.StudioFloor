using Prism.Mvvm;
using Prism.Regions;
using Songhay.Extensions;
using Songhay.Mvvm.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Songhay.StudioFloor.Desktop.Modules.SvgFonts.ViewModels
{
    /// <summary>
    /// SVG Font View Model
    /// </summary>
    public class SvgFontViewModel : BindableBase, INavigationAware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgFontViewModel"/> class.
        /// </summary>
        public SvgFontViewModel()
        {
            this.Glyphs = new ObservableCollection<SvgGlyphViewModel>();
        }

        /// <summary>
        /// Gets or sets the glyphs.
        /// </summary>
        /// <value>
        /// The glyphs.
        /// </value>
        public ObservableCollection<SvgGlyphViewModel> Glyphs
        {
            get { return this._glyphs; }
            set { this.SetProperty(ref this._glyphs, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is doing service operation.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is doing service operation; otherwise, <c>false</c>.
        /// </value>
        public bool IsDoingServiceOperation
        {
            get { return this._isDoingServiceOperation; }
            set { this.SetProperty(ref this._isDoingServiceOperation, value); }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        #region INavigationAware members:

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return this.IsINavigationAwareNavigationTarget(navigationContext);
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.Title = string.Empty;
            this.IsDoingServiceOperation = true;
            this.Glyphs.Clear();

            var xml = ApplicationUtility.LoadResource(navigationContext.Uri.ToRelativeUriFromQuery());

            Task.Factory.StartNew<IEnumerable<XElement>>(() =>
            {
                XNamespace svg = "http://www.w3.org/2000/svg";

                //You cannot stop .NET from condensing entities so load as string:
                xml = xml.Replace("unicode=\"&#", "unicode=\"&amp;#");
                var svgFont = XDocument.Parse(xml);

                var fontElement = svgFont.Descendants(svg + "font").FirstOrDefault();
                if (fontElement == null) svgFont.Descendants("font").FirstOrDefault();
                if (fontElement != null) this.Title = fontElement.ToAttributeValueOrNull("id");
                else this.Title = "[font ID not found]";

                var glyphs = svgFont.Descendants(svg + "glyph");
                if (!glyphs.Any()) glyphs = svgFont.Descendants("glyph");

                return glyphs;

            }).ContinueWith(task =>
            {
                task.Result.ForEachInEnumerable(i => this.Glyphs.Add(new SvgGlyphViewModel(i)));
                this.IsDoingServiceOperation = false;
            },
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        bool _isDoingServiceOperation;
        string _title;
        ObservableCollection<SvgGlyphViewModel> _glyphs;
    }
}
