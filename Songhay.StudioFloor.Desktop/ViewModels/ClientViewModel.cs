using Microsoft.Practices.ServiceLocation;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Songhay.Models;
using Songhay.Mvvm.ViewModels;
using Songhay.StudioFloor.Desktop.Common.Events;
using Songhay.StudioFloor.Desktop.Common.Extensions;
using System.Collections.ObjectModel;

namespace Songhay.StudioFloor.Desktop.ViewModels
{
    public class ClientViewModel : BindableBase
    {
        public ClientViewModel(IEventAggregator eventAggregator)
        {
            this._regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this._clientContentRegionNavigation = this.GetClientContentRegionNavigation(this._regionManager);

            this.Index = new ObservableCollection<DisplayItemModel>();
            eventAggregator
                .GetEvent<ModuleInitializedEvent>()
                .Subscribe(displayItem => this.Index.Add(displayItem));
        }

        public RegionNavigationViewModel ClientContentRegionNavigation
        {
            get { return this._clientContentRegionNavigation; }
        }

        public ObservableCollection<DisplayItemModel> Index { get; private set; }

        IRegionManager _regionManager;
        RegionNavigationViewModel _clientContentRegionNavigation;
    }
}
