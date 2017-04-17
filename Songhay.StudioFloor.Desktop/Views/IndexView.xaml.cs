using Songhay.Mvvm.Models;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Songhay.StudioFloor.Desktop.Views
{
    /// <summary>
    /// Interaction logic for IndexView.xaml
    /// </summary>
    [Export("IndexView", typeof(IView))]
    public partial class IndexView : UserControl, IView
    {
        public IndexView()
        {
            InitializeComponent();
        }
    }
}
