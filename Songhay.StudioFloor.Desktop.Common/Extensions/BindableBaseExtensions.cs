using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
using Songhay.Mvvm.ViewModels;
using Songhay.StudioFloor.Shared.Models;

namespace Songhay.StudioFloor.Desktop.Common.Extensions
{
    /// <summary>
    /// Extensions of <see cref="BindableBase"/>
    /// </summary>
    public static class BindableBaseExtensions
    {
        /// <summary>
        /// Gets the client content region navigation.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="regionManager">The region manager.</param>
        public static RegionNavigationViewModel GetClientContentRegionNavigation(this BindableBase viewModel, IRegionManager regionManager)
        {
            if (viewModel == null) return null;
            if (regionManager == null) return null;
            return new RegionNavigationViewModel(regionManager, RegionNames.ClientContentRegion);
        }

        /// <summary>
        /// Determines whether the specified View Model is the Prism Navigation target.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="navigationContext">The navigation context.</param>
        public static bool IsINavigationAwareNavigationTarget(this BindableBase viewModel, NavigationContext navigationContext)
        {
            if (viewModel == null) return false;
            if (navigationContext == null) return false;

            var key = viewModel.GetType().Name.Replace("Model", string.Empty);
            return navigationContext.Uri.OriginalString.Contains(key);
        }
    }
}
