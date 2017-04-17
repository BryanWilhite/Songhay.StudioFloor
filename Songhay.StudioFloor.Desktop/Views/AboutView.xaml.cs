using Songhay.Mvvm.Models;
using Songhay.Mvvm.ViewModels;
using System.Reflection;
using System.Windows.Controls;

namespace Songhay.StudioFloor.Desktop.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : UserControl, IView
    {
        public AboutView()
        {
            InitializeComponent();
            this.DataContext = new AboutViewModel(Assembly.GetExecutingAssembly());
        }
    }
}
