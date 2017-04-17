using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Songhay.Extensions;
using Songhay.StudioFloor.Desktop.Modules;
using Songhay.StudioFloor.Desktop.Views;
using Songhay.StudioFloor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Songhay.StudioFloor.Desktop
{
    public class ClientBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureModuleCatalog()
        {
            var catalog = this.ModuleCatalog as ModuleCatalog;

            //#region builders:

            //var rflContextForRest = new RegistrationBuilder();
            //rflContextForRest
            //    .ForTypesDerivedFrom<IRestModelContextService>()
            //    .Export<IRestModelContextService>();

            //#endregion

            var moduleTypes = new List<Type> {
                typeof(ClientModule),
                //typeof(RestModelContextModule),
                //typeof(RestWeatherModule),
                typeof(AnalogDigitModule),
                //typeof(ExceptionsModule),
                //typeof(KennyYoungFluidMoveModule),
                //typeof(ODataWeatherModule),
                //typeof(PackedXamlModule),
                //typeof(SvgFontsModule),
                //typeof(ValidationModule),
            };

            moduleTypes.ForEachInEnumerable(i => catalog.AddModule(i));
        }

        protected override DependencyObject CreateShell()
        {
            if (!FrameworkDispatcherUtility.HasCurrentWindowsApplication()) return null;
            return this.Container.Resolve<ClientView>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();

            var regionManager = this.Container.Resolve<IRegionManager>();
            regionManager.RequestNavigate(RegionNames.ClientContentRegion, new Uri(typeof(IndexView).Name, UriKind.Relative));
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
