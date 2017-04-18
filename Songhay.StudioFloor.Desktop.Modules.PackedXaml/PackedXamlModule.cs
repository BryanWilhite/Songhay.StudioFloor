using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Songhay.Models;
using Songhay.StudioFloor.Desktop.Common.Events;
using Songhay.StudioFloor.Desktop.Modules.PackedXaml.Views;
using System;

namespace Songhay.StudioFloor.Desktop.Modules
{
    public class PackedXamlModule : DisplayItemModel, IModule
    {
        public PackedXamlModule(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this._container = container;
            this._eventAggregator = eventAggregator;

            this.Description = "Page-compiled XAML-only samples.";
            this.DisplayText = "Packed XAML Samples";
            this.ItemName = "PackedXamlIndexView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        public void Initialize()
        {
            this._container.RegisterTypeForNavigation<PackedXamlIndexView>();
            this._container.RegisterTypeForNavigation<PackedXamlView>();

            this._eventAggregator.GetEvent<ModuleInitializedEvent>().Publish(this);
        }

        readonly IUnityContainer _container;
        readonly IEventAggregator _eventAggregator;
    }
}
