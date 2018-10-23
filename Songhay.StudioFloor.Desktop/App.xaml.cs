using Prism.Ioc;
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
using System.Windows.Threading;

namespace Songhay.StudioFloor.Desktop
{

    /// <summary>
    /// Desktop Application
    /// </summary>
    public partial class App : PrismApplication, IApp
    {
        /// <summary>
        /// Gets or sets a value indicating whether App should close on Dispatcher exception.
        /// </summary>
        /// <value>
        /// <c>true</c> if App should close on Dispatcher exception; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldCloseOnDispatcherException { get; set; }

        /// <summary>
        /// Configures the <see cref="T:Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            var moduleTypes = new List<Type> {
                typeof(ClientModule),
                typeof(AnalogDigitModule),
                typeof(ExceptionsModule),
                typeof(KennyYoungFluidMoveModule),
                typeof(PackedXamlModule),
                typeof(SvgFontsModule),
                typeof(ValidationModule),
            };

            moduleTypes.ForEachInEnumerable(i => moduleCatalog.AddModule(i));
        }

        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        /// The shell of the application.
        /// </returns>
        protected override Window CreateShell()
        {
            if (!FrameworkDispatcherUtility.HasCurrentWindowsApplication()) return null;

            return this.Container.Resolve<ClientView>();
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        /// <param name="shell"></param>
        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);

            if (!FrameworkDispatcherUtility.HasCurrentWindowsApplication()) return;

            Application.Current.MainWindow = shell as ClientView;
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Raises the <see cref="E:Startup" /> event.
        /// </summary>
        /// <param name="e">The <see cref="StartupEventArgs"/> instance containing the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        /// <summary>
        /// Initializes the modules.
        /// </summary>
        protected override void InitializeModules()
        {
            base.InitializeModules();

            var regionManager = this.Container.Resolve<IRegionManager>();
            regionManager.RequestNavigate(RegionNames.ClientContentRegion, new Uri(typeof(IndexView).Name, UriKind.Relative));
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (this.ShouldCloseOnDispatcherException)
            {
                MessageBox.Show("Application is going to close! ", "Uncaught Exception");
                e.Handled = false;
            }
            else
            {
                MessageBox.Show(e.Exception.Message, "Dispatcher Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            }
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            MessageBox.Show(ex.Message, "Domain Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
