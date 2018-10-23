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

namespace Songhay.StudioFloor.Desktop.Modules.PackedXaml.ViewModels
{
    public class PackedXamlIndexViewModel : BindableBase
    {
        public PackedXamlIndexViewModel()
        {
            this._regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this._clientContentRegionNavigation = this.GetClientContentRegionNavigation(this._regionManager);

            this.Index = ApplicationUtility
                .ListPackedResources(Assembly.GetExecutingAssembly(), 48)
                .Select(i=>
                {
                    i.ResourceIndicator = new Uri(string.Format("PackedXamlView?{0}",
                        Uri.EscapeUriString(i.ResourceIndicator.OriginalString)), UriKind.Relative);
                    return i;
                });
        }

        public RegionNavigationViewModel ClientContentRegionNavigation
        {
            get { return this._clientContentRegionNavigation; }
        }

        public IEnumerable<DisplayItemModel> Index { get; private set; }

        public ICommand IndexCommand { get; private set; }

        IRegionManager _regionManager;
        RegionNavigationViewModel _clientContentRegionNavigation;
    }
}
