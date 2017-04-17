using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Songhay.Models;
using System;
using System.ComponentModel.Composition;

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
