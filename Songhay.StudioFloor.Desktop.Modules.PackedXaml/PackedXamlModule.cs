using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Songhay.Models;
using Songhay.Mvvm.Models;
using Songhay.StudioFloor.Desktop.Modules.PackedXaml.Views;
using System;

namespace Songhay.StudioFloor.Desktop.Modules
{
    /// <summary>
    /// Prism Module
    /// </summary>
    /// <seealso cref="Songhay.Models.DisplayItemModel" />
    /// <seealso cref="Prism.Modularity.IModule" />
    public class PackedXamlModule : DisplayItemModel, IModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackedXamlModule"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public PackedXamlModule(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;

            this.Description = "Page-compiled XAML-only samples.";
            this.DisplayText = "Packed XAML Samples";
            this.ItemName = "PackedXamlIndexView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PackedXamlIndexView>();
            containerRegistry.RegisterForNavigation<PackedXamlView>();
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
