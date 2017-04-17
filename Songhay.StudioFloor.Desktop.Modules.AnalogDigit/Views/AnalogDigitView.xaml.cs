using Prism.Mvvm;
using Songhay.Mvvm.Models;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Songhay.StudioFloor.Desktop.Modules.AnalogDigit.Views
{
    /// <summary>
    /// Interaction logic for AnalogDigitView.xaml
    /// </summary>
    [Export("AnalogDigitView", typeof(IView))]
    public partial class AnalogDigitView : UserControl, IView
    {
        public AnalogDigitView()
        {
            InitializeComponent();
            ViewModelLocator.SetAutoWireViewModel(this, true);
        }
    }
}
