using Prism.Mvvm;

namespace Songhay.StudioFloor.Desktop.Modules.KennyYoungFluidMove.ViewModels
{
    public class KennyFoodItemViewModel : BindableBase
    {
        public KennyFoodItemViewModel()
        {
            this._name = string.Empty;
            this._isLiked = false;
            this._order = 0;
        }

        /// <summary>
        /// Returns the internal name of this object
        /// for retrieval from a collection.
        /// Child classes can set this property to a new value,
        /// or override it to determine the value on-demand.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this.SetProperty(ref this._name, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is liked.
        /// </summary>
        /// <value><c>true</c> if this instance is liked; otherwise, <c>false</c>.</value>
        public bool IsLiked
        {
            get { return this._isLiked; }
            set { this.SetProperty(ref this._isLiked, value); }
        }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public double Order
        {
            get { return this._order; }
            set { this.SetProperty(ref this._order, value); }
        }

        string _name;
        bool _isLiked;
        double _order;
    }
}
