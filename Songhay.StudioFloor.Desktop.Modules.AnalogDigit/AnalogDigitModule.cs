using Prism.Events;
using Prism.Modularity;
using Songhay.Models;
using Songhay.StudioFloor.Desktop.Common.Events;
using System;

namespace Songhay.StudioFloor.Desktop.Modules
{
    public class AnalogDigitModule : DisplayItemModel, IModule
    {
        public AnalogDigitModule(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;

            this.Description = "The Analog Digit Control sample.";
            this.DisplayText = "Songhay Analog Digit";
            this.ItemName = "AnalogDigitView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        public void Initialize()
        {
            this._eventAggregator.GetEvent<ModuleInitializedEvent>().Publish(this);
        }

        IEventAggregator _eventAggregator;
    }
}
