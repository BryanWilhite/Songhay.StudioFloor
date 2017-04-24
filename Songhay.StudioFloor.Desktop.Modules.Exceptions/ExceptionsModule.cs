using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Unity;
using Songhay.Models;
using Songhay.StudioFloor.Desktop.Modules.Exceptions.Views;
using System;

namespace Songhay.StudioFloor.Desktop.Modules
{
    public class ExceptionsModule : DisplayItemModel, IModule
    {
        public ExceptionsModule(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this._container = container;
            this._eventAggregator = eventAggregator;

            this.Description = "The conventional Exception handling in WPF.";
            this.DisplayText = "WPF Exceptions";
            this.ItemName = "ExceptionsView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        /// <summary>
        /// Notifies the module that it has been initialized.
        /// </summary>
        public void Initialize()
        {
            this._container.RegisterTypeForNavigation<ExceptionsView>();

            this._eventAggregator.GetEvent<PubSubEvent<DisplayItemModel>>().Publish(this);
        }

        readonly IUnityContainer _container;
        readonly IEventAggregator _eventAggregator;
    }
}
