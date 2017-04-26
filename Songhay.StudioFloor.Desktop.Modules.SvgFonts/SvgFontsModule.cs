using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Unity;
using Songhay.Models;
using Songhay.Mvvm.Models;
using Songhay.StudioFloor.Desktop.Modules.SvgFonts.Views;
using System;

namespace Songhay.StudioFloor.Desktop.Modules
{
    public class SvgFontsModule : DisplayItemModel, IModule
    {
        public SvgFontsModule(IUnityContainer container, IEventAggregator eventAggregator)
        {
            this._container = container;
            this._eventAggregator = eventAggregator;

            this.Description = "SVG fonts converted to StreamGeometry.";
            this.DisplayText = "SVG Font Samples";
            this.ItemName = "SvgFontsIndexView";
            this.ResourceIndicator = new Uri(this.ItemName, UriKind.Relative);
        }

        public void Initialize()
        {
            this._container.RegisterTypeForNavigation<SvgFontsIndexView>();
            this._container.RegisterTypeForNavigation<SvgFontView>();

            this._eventAggregator.GetEvent<DisplayItemModelEvent>().Publish(this);
        }

        readonly IUnityContainer _container;
        readonly IEventAggregator _eventAggregator;
    }
}
