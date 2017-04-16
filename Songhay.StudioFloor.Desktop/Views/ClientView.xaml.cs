using MahApps.Metro.Controls;
using Microsoft.Practices.Prism.Mvvm;
using System.ComponentModel.Composition;

namespace Songhay.StudioFloor.Desktop.Views
{
    /// <summary>
    /// Client View
    /// </summary>
    [Export(typeof(ClientView))]
    public partial class ClientView : MetroWindow, IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientView"/> class.
        /// </summary>
        public ClientView()
        {
            this.InitializeComponent();
            ViewModelLocator.SetAutoWireViewModel(this, true);
        }
    }
}
