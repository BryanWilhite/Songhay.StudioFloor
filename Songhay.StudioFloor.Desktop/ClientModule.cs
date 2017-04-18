using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Songhay.StudioFloor.Desktop.Views;

namespace Songhay.StudioFloor.Desktop
{
    public class ClientModule: IModule
    {
        public ClientModule(RegionManager regionManager, IUnityContainer container)
        {
            this._regionManager = regionManager;
            this._container = container;
        }

        public void Initialize()
        {
            this._container.RegisterTypeForNavigation<AboutView>();
            this._container.RegisterTypeForNavigation<ClientView>();
            this._container.RegisterTypeForNavigation<IndexView>();
        }

        readonly IRegionManager _regionManager;
        readonly IUnityContainer _container;
    }
}
