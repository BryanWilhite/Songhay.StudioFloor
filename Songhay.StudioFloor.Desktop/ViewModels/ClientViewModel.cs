using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Songhay.Models;
using Songhay.Mvvm.ViewModels;
using Songhay.StudioFloor.Desktop.Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Songhay.StudioFloor.Desktop.ViewModels
{

    public class ClientViewModel : BindableBase
    {
        public ClientViewModel()
        {
            this._regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this._clientContentRegionNavigation = this.GetClientContentRegionNavigation(this._regionManager);

            this.SetIndex();
        }

        public RegionNavigationViewModel ClientContentRegionNavigation
        {
            get { return this._clientContentRegionNavigation; }
        }

        public IEnumerable<DisplayItemModel> Index { get; private set; }

        void SetIndex()
        {
            var instances = ServiceLocator.Current.GetAllInstances<IModule>();
            var models = instances.OfType<DisplayItemModel>().OrderBy(i => i.DisplayText);
            this.Index = models;
        }

        IRegionManager _regionManager;
        RegionNavigationViewModel _clientContentRegionNavigation;
    }
}
