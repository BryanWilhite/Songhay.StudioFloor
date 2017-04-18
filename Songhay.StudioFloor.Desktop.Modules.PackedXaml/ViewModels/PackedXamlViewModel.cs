using Prism.Mvvm;
using Prism.Regions;
using Songhay.Extensions;
using Songhay.Mvvm.Extensions;
using System.Windows.Controls;

namespace Songhay.StudioFloor.Desktop.Modules.PackedXaml.ViewModels
{
    /// <summary>
    /// Packed XAML View Model
    /// </summary>
    public class PackedXamlViewModel : BindableBase, INavigationAware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackedXamlViewModel"/> class.
        /// </summary>
        public PackedXamlViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the current visual.
        /// </summary>
        /// <value>
        /// The current visual.
        /// </value>
        public UserControl CurrentVisual
        {
            get { return this._currentVisual; }
            set
            {
                this.SetProperty(ref this._currentVisual, value);
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        #region INavigationAware members:

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return this.IsINavigationAwareNavigationTarget(navigationContext);
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var xaml = ApplicationUtility.LoadResource(navigationContext.Uri.ToRelativeUriFromQuery());
            var control = ApplicationUtility.LoadResource<UserControl>(xaml);

            this.CurrentVisual = control;
            this.Title = control.Tag.ToString();
            this.XamlSource = xaml;
        }

        #endregion

        string _title;
        string _xamlSource;

        public string XamlSource
        {
            get { return this._xamlSource; }
            set { this.SetProperty(ref this._xamlSource, value); }
        }

        UserControl _currentVisual;
    }
}
