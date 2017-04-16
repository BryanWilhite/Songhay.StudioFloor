using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Regions;
using Songhay.Extensions;
using Songhay.StudioFloor.Desktop.Views;
using Songhay.StudioFloor.Shared.Models;
using Songhay.StudioFloor.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.Windows;

namespace Songhay.StudioFloor.Desktop
{
    public class ClientBootstrapper : MefBootstrapper
    {
        internal CompositionContainer GetCompositionContainer()
        {
            return this.Container;
        }

        protected override void ConfigureAggregateCatalog()
        {
            #region builders:

            var rflContextForRest = new RegistrationBuilder();
            rflContextForRest
                .ForTypesDerivedFrom<IRestModelContextService>()
                .Export<IRestModelContextService>();

            #endregion

            var catalogs = new List<AssemblyCatalog> {
                new AssemblyCatalog(this.GetType().Assembly),
                //new AssemblyCatalog(typeof(RestModelContextModule).Assembly, rflContextForRest),
                //new AssemblyCatalog(typeof(RestWeatherModule).Assembly),
                //new AssemblyCatalog(typeof(AnalogDigitModule).Assembly),
                //new AssemblyCatalog(typeof(ExceptionsModule).Assembly),
                //new AssemblyCatalog(typeof(KennyYoungFluidMoveModule).Assembly),
                //new AssemblyCatalog(typeof(ODataWeatherModule).Assembly),
                //new AssemblyCatalog(typeof(PackedXamlModule).Assembly),
                //new AssemblyCatalog(typeof(SvgFontsModule).Assembly),
                //new AssemblyCatalog(typeof(ValidationModule).Assembly),
            };

            catalogs.ForEachInEnumerable(i => this.AggregateCatalog.Catalogs.Add(i));
        }

        protected override DependencyObject CreateShell()
        {
            if (!FrameworkDispatcherUtility.HasCurrentWindowsApplication()) return null;
            return this.Container.GetExportedValue<ClientView>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();

            var regionManager = this.Container.GetExportedValue<IRegionManager>();
            regionManager.RequestNavigate(RegionNames.ClientContentRegion, new Uri(typeof(Views.IndexView).Name, UriKind.Relative));
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            if (!FrameworkDispatcherUtility.HasCurrentWindowsApplication()) return;

            Application.Current.MainWindow = this.Shell as ClientView;
            Application.Current.MainWindow.Show();
        }
    }
}
