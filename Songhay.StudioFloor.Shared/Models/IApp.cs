namespace Songhay.StudioFloor.Shared.Models
{
    /// <summary>
    /// Defines selected App Members
    /// </summary>
    public interface IApp
    {
        /// <summary>
        /// Gets or sets a value indicating whether App should close on Dispatcher exception.
        /// </summary>
        /// <value>
        /// <c>true</c> if App should close on Dispatcher exception; otherwise, <c>false</c>.
        /// </value>
        bool ShouldCloseOnDispatcherException { get; set; }
    }
}
