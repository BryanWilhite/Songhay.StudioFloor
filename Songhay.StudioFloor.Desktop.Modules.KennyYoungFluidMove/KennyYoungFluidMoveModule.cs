using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Unity;
using Songhay.Models;
using Songhay.StudioFloor.Desktop.Common.Events;
using Songhay.StudioFloor.Desktop.Modules.KennyYoungFluidMove.Views;
using System;

namespace Songhay.StudioFloor.Desktop.Modules
{
    /// <summary>
    /// Prism Module
    /// </summary>
    public class KennyYoungFluidMoveModule : DisplayItemModel, IModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KennyYoungFluidMoveModule"/> class.
        /// </summary>
        public KennyYoungFluidMoveModule(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this._container = container;
            this._eventAggregator = eventAggregator;

            this.Description = "The Expression Blend SDK Fluid Move Behavior from Blend Architect Kenny Young.";
            this.DisplayText = "Kenny Young: Fluid Move";
            this.ItemName = "KennyYoungFluidMoveView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        /// <summary>
        /// Notifies the module that it has been initialized.
        /// </summary>
        public void Initialize()
        {
            this._container.RegisterTypeForNavigation<KennyYoungFluidMoveView>();

            this._eventAggregator.GetEvent<ModuleInitializedEvent>().Publish(this);
        }

        readonly IUnityContainer _container;
        readonly IEventAggregator _eventAggregator;
    }
}
