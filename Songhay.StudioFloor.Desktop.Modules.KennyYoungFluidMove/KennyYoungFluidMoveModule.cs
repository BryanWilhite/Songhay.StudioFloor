using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Songhay.Models;
using Songhay.Mvvm.Models;
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
        public KennyYoungFluidMoveModule(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;

            this.Description = "The Expression Blend SDK Fluid Move Behavior from Blend Architect Kenny Young.";
            this.DisplayText = "Kenny Young: Fluid Move";
            this.ItemName = "KennyYoungFluidMoveView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<KennyYoungFluidMoveView>();
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            this._eventAggregator.GetEvent<DisplayItemModelEvent>().Publish(this);
        }

        readonly IEventAggregator _eventAggregator;
    }
}
