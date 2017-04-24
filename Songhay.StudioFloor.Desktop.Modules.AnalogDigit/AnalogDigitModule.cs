using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Unity;
using Songhay.Models;
using Songhay.StudioFloor.Desktop.Modules.AnalogDigit.Views;
using System;

namespace Songhay.StudioFloor.Desktop.Modules
{
    public class AnalogDigitModule : DisplayItemModel, IModule
    {
        public AnalogDigitModule(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;
            this._container = container;

            this.Description = "The Analog Digit Control sample.";
            this.DisplayText = "Songhay Analog Digit";
            this.ItemName = "AnalogDigitView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        public void Initialize()
        {
            this._container.RegisterTypeForNavigation<AnalogDigitView>();

            this._eventAggregator.GetEvent<PubSubEvent<DisplayItemModel>>().Publish(this);
        }

        readonly IEventAggregator _eventAggregator;
        readonly IUnityContainer _container;
    }
}
