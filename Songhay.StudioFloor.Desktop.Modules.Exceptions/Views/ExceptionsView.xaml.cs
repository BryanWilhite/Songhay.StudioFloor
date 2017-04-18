using Songhay.Mvvm.Models;
using Songhay.StudioFloor.Shared.Models;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Songhay.StudioFloor.Desktop.Modules.Exceptions.Views
{
    /// <summary>
    /// Interaction logic for ExceptionsView.xaml
    /// </summary>
    public partial class ExceptionsView : UserControl, IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionsView"/> class.
        /// </summary>
        public ExceptionsView()
        {
            this.InitializeComponent();

            this.ShouldCloseApp.Checked += (s, args) =>
            {
                var app = Application.Current as IApp;

                if(this.ShouldCloseApp.IsChecked.GetValueOrDefault())
                {
                    app.ShouldCloseOnDispatcherException = true;
                }
                else
                {
                    app.ShouldCloseOnDispatcherException = false;
                }
            };
        }

        void ThrowException(object sender, RoutedEventArgs e)
        {
            throw new SystemException("BiggestBox: this is an Exception thrown on the UI thread.");
        }

        async void ThrowThreadException(object sender, RoutedEventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                throw new SystemException("BiggestBox: this is an Exception thrown on a Task thread.");
            });
        }
    }
}
