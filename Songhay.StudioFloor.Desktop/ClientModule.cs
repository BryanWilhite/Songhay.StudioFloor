using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Songhay.StudioFloor.Desktop.Views;

namespace Songhay.StudioFloor.Desktop
{
    /// <summary>
    /// Prism Module
    /// </summary>
    /// <seealso cref="Prism.Modularity.IModule" />
    public class ClientModule: IModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientModule"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public ClientModule(RegionManager regionManager)
        {
            this._regionManager = regionManager;
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AboutView>();
            containerRegistry.RegisterForNavigation<ClientView>();
            containerRegistry.RegisterForNavigation<IndexView>();
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        readonly IRegionManager _regionManager;
    }
}
