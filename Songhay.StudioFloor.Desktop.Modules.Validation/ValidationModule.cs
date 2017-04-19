using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Unity;
using Songhay.Models;
using Songhay.StudioFloor.Desktop.Common.Events;
using Songhay.StudioFloor.Desktop.Modules.Validation.Views;
using System;

namespace Songhay.StudioFloor.Desktop.Modules
{
    public class ValidationModule : DisplayItemModel, IModule
    {
        public ValidationModule(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this._container = container;
            this._eventAggregator = eventAggregator;

            this.Description = "Validation samples, featuring the use of INotifyDataErrorInfo.";
            this.DisplayText = "Validation Samples";
            this.ItemName = "BasicValidationView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        public void Initialize()
        {
            this._container.RegisterTypeForNavigation<BasicValidationView>();

            this._eventAggregator.GetEvent<ModuleInitializedEvent>().Publish(this);
        }

        readonly IUnityContainer _container;
        readonly IEventAggregator _eventAggregator;
    }
}
