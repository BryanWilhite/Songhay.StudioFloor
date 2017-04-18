using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Songhay.StudioFloor.Desktop.Modules.KennyYoungFluidMove.ViewModels
{
    /// <summary>
    /// Kenny’s Food
    /// </summary>
    /// <remarks>
    /// This type is based on the gallery sample “Dynamic Layout and Transitions in Blend 4”
    /// by Kenny Young, Expression Blend Architect
    /// [http://gallery.expression.microsoft.com/DynamicLayoutTrans/]
    /// </remarks>
    public class KennyYoungFluidMoveViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KennyYoungFluidMoveViewModel"/> class.
        /// </summary>
        public KennyYoungFluidMoveViewModel()
        {
            this.masterList = new List<KennyFoodItemViewModel>()
            {
                new KennyFoodItemViewModel() { Name = "Chocolate Cake", IsLiked = true, Order = 10 },
                new KennyFoodItemViewModel() { Name = "Brussels Sprouts", IsLiked = false, Order = 11 },
                new KennyFoodItemViewModel() { Name = "Mocha Ice Cream", IsLiked = true, Order = 12 },
                new KennyFoodItemViewModel() { Name = "Asparagus", IsLiked = false, Order = 13 },
                new KennyFoodItemViewModel() { Name = "Sushi", IsLiked = true, Order = 14 },
                new KennyFoodItemViewModel() { Name = "Cilantro", IsLiked = false, Order = 15 },
                new KennyFoodItemViewModel() { Name = "Diet Coke", IsLiked = true, Order = 16 },
                new KennyFoodItemViewModel() { Name = "Tequila", IsLiked = false, Order = 17 },
                new KennyFoodItemViewModel() { Name = "Habanero Peppers", IsLiked = true, Order = 18 },
                new KennyFoodItemViewModel() { Name = "Lutefisk", IsLiked = false, Order = 19 },
                new KennyFoodItemViewModel() { Name = "Sauerkraut", IsLiked = true, Order = 20 },
                new KennyFoodItemViewModel() { Name = "Haggis", IsLiked = false, Order = 21 }
            };

            this.numberOfItems = this.masterList.Count;

            foreach (KennyFoodItemViewModel item in this.masterList)
            {
                item.PropertyChanged += (s, args) =>
                {
                    this.UpdateCollections();
                };
            }

            this.UpdateCollections();
        }

        /// <summary>
        /// Gets the foods I like.
        /// </summary>
        /// <value>The foods I like.</value>
        public ObservableCollection<KennyFoodItemViewModel> FoodsILike { get { return this.foodsILike; } }

        /// <summary>
        /// Gets the foods I hate.
        /// </summary>
        /// <value>The foods I hate.</value>
        public ObservableCollection<KennyFoodItemViewModel> FoodsIHate { get { return this.foodsIHate; } }

        /// <summary>
        /// Gets the max number of items.
        /// </summary>
        /// <value>The max number of items.</value>
        public double MaxNumberOfItems { get { return this.masterList.Count; } }

        /// <summary>
        /// Gets or sets the number of items.
        /// </summary>
        /// <value>The number of items.</value>
        public double NumberOfItems
        {
            get { return this.numberOfItems; }
            set { this.SetProperty(ref this.numberOfItems, value); }
        }

        /// <summary>
        /// Kenny food view model: sort original.
        /// </summary>
        public void SortOriginal()
        {
            this.masterList.Sort(new Comparison<KennyFoodItemViewModel>(delegate(KennyFoodItemViewModel a, KennyFoodItemViewModel b) { return (int)(a.Order - b.Order); }));
            this.UpdateCollections();
        }

        /// <summary>
        /// Kenny food view model: sort alphabetical.
        /// </summary>
        public void SortAlphabetical()
        {
            this.masterList.Sort(new Comparison<KennyFoodItemViewModel>(delegate(KennyFoodItemViewModel a, KennyFoodItemViewModel b) { return String.Compare(a.Name, b.Name); }));
            this.UpdateCollections();
        }

        void UpdateCollections()
        {
            this.UpdateObservableCollection(this.FoodsILike, true);
            this.UpdateObservableCollection(this.FoodsIHate, false);
        }

        void UpdateObservableCollection(ObservableCollection<KennyFoodItemViewModel> collection, bool filter)
        {
            int index = 0;
            int collectionIndex = 0;

            foreach (KennyFoodItemViewModel item in this.masterList)
            {
                bool itemIsAvailable = collectionIndex < this.NumberOfItems;

                if (item.IsLiked == filter && itemIsAvailable)
                {
                    if (index >= collection.Count || collection[index] != item)
                    {
                        if (collection.Contains(item))
                        {
                            collection.Remove(item); // don't have it in place twice
                        }
                        collection.Insert(index, item);
                    }
                    index++;
                }
                else
                {
                    if (index < collection.Count && collection[index] == item)
                    {
                        collection.RemoveAt(index);
                    }
                }

                collectionIndex++;
            }

            while (collection.Count > index)
            {
                collection.RemoveAt(index);
            }
        }

        List<KennyFoodItemViewModel> masterList;
        ObservableCollection<KennyFoodItemViewModel> foodsILike = new ObservableCollection<KennyFoodItemViewModel>();
        ObservableCollection<KennyFoodItemViewModel> foodsIHate = new ObservableCollection<KennyFoodItemViewModel>();
        double numberOfItems;
    }
}
