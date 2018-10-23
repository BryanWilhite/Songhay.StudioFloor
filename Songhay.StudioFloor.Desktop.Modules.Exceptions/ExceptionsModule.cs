using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Songhay.Models;
using Songhay.Mvvm.Models;
using Songhay.StudioFloor.Desktop.Modules.Exceptions.Views;
using System;

namespace Songhay.StudioFloor.Desktop.Modules
{
    /// <summary>
    /// Prism Module
    /// </summary>
    /// <seealso cref="Songhay.Models.DisplayItemModel" />
    /// <seealso cref="Prism.Modularity.IModule" />
    public class ExceptionsModule : DisplayItemModel, IModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionsModule"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ExceptionsModule(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;

            this.Description = "The conventional Exception handling in WPF.";
            this.DisplayText = "WPF Exceptions";
            this.ItemName = "ExceptionsView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ExceptionsView>();
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
