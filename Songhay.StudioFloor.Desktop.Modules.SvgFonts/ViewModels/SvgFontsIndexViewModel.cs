using CommonServiceLocator;
using Prism.Mvvm;
using Prism.Regions;
using Songhay.Models;
using Songhay.Mvvm.ViewModels;
using Songhay.StudioFloor.Desktop.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace Songhay.StudioFloor.Desktop.Modules.SvgFonts.ViewModels
{
    /// <summary>
    /// SVG Fonts Index View Model
    /// </summary>
    public class SvgFontsIndexViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgFontsIndexViewModel"/> class.
        /// </summary>
        public SvgFontsIndexViewModel()
        {
            this._regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this._clientContentRegionNavigation = this.GetClientContentRegionNavigation(this._regionManager);

            this.Index = ApplicationUtility
                .ListPackedResources(Assembly.GetExecutingAssembly(), 48)
                .Select(i =>
                {
                    i.DisplayText = i.DisplayText.Replace(".Svg", string.Empty);
                    i.ResourceIndicator = new Uri(string.Format("SvgFontView?{0}",
                        Uri.EscapeUriString(i.ResourceIndicator.OriginalString)), UriKind.Relative);
                    return i;
                });
        }

        /// <summary>
        /// Gets the client content region navigation.
        /// </summary>
        /// <value>
        /// The client content region navigation.
        /// </value>
        public RegionNavigationViewModel ClientContentRegionNavigation
        {
            get { return this._clientContentRegionNavigation; }
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public IEnumerable<DisplayItemModel> Index { get; private set; }

        /// <summary>
        /// Gets the index command.
        /// </summary>
        /// <value>
        /// The index command.
        /// </value>
        public ICommand IndexCommand { get; private set; }

        IRegionManager _regionManager;
        RegionNavigationViewModel _clientContentRegionNavigation;
    }
}
