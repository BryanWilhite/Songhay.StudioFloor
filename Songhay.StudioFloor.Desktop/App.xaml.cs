using Prism.Mvvm;
using Songhay.Mvvm.Extensions;
using Songhay.StudioFloor.Shared.Models;
using System;
using System.Windows;
using System.Windows.Threading;

namespace Songhay.StudioFloor.Desktop
{

    /// <summary>
    /// Desktop Application
    /// </summary>
    public partial class App : Application, IApp
    {
        /// <summary>
        /// Gets or sets a value indicating whether App should close on Dispatcher exception.
        /// </summary>
        /// <value>
        /// <c>true</c> if App should close on Dispatcher exception; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldCloseOnDispatcherException { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType => viewType.GetDefaultViewTypeForViewModelTypeResolver());

            var bootstrapper = new ClientBootstrapper();
            bootstrapper.Run();
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
