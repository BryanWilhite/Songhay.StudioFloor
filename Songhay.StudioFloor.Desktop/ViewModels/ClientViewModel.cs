using CommonServiceLocator;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Songhay.Models;
using Songhay.Mvvm.Extensions;
using Songhay.Mvvm.Models;
using Songhay.Mvvm.ViewModels;
using Songhay.StudioFloor.Desktop.Common.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Songhay.StudioFloor.Desktop.ViewModels
{
    public class ClientViewModel : BindableBase
    {
        public ClientViewModel(IEventAggregator eventAggregator)
        {
            this.SetupRegionNavigation();
            this.SetupIndexViewSource();
            this.SetupIndexWithEventing(eventAggregator);
        }

        public RegionNavigationViewModel ClientContentRegionNavigation { get; private set; }

        public ICollectionView IndexCollectionView
        {
            get { return this._indexViewSource.GetView(this._index); }
        }

        void SetupIndexViewSource()
        {
            this._indexViewSource = new CollectionViewSource();
            this._indexViewSource.SortDescriptions.Add(new SortDescription("DisplayText", ListSortDirection.Ascending));
        }

        void SetupIndexWithEventing(IEventAggregator eventAggregator)
        {
            this._index = new ObservableCollection<DisplayItemModel>();
            eventAggregator
                .GetEvent<DisplayItemModelEvent>()
                .Subscribe(displayItem => this._index.Add(displayItem));
        }

        void SetupRegionNavigation()
        {
            this._regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this.ClientContentRegionNavigation = this.GetClientContentRegionNavigation(this._regionManager);
        }

        CollectionViewSource _indexViewSource;
        IRegionManager _regionManager;
        ObservableCollection<DisplayItemModel> _index;
    }
}
