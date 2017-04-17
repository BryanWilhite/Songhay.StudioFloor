using Prism.Mef.Modularity;
using Prism.Modularity;
using Songhay.Models;
using System;

namespace Songhay.StudioFloor.Desktop.Modules
{
    [ModuleExport("AnalogDigitModule", typeof(IModule))]
    public class AnalogDigitModule : DisplayItemModel, IModule
    {
        public AnalogDigitModule()
        {
            this.Description = "The Analog Digit Control sample.";
            this.DisplayText = "Songhay Analog Digit";
            this.ItemName = "AnalogDigitView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        public void Initialize()
        {
        }
    }
}
