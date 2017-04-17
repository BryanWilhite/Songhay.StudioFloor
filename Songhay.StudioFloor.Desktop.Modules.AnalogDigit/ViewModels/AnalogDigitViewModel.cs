using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Songhay.StudioFloor.Desktop.Modules.AnalogDigit.ViewModels
{
    public class AnalogDigitViewModel : BindableBase
    {
        public AnalogDigitViewModel()
        {
            this.SingleDigitValue = 7;
            this.MultipleDigitValue = 1024.068;
            this.MultipleDigitValueCollection = new ObservableCollection<byte?>(new List<byte?> { 7, 0, 4, 2, 0, 1 });

            #region commanding:

            this.ChangeSingleDigitValueCommand = new DelegateCommand<string>(
            p =>
            {
                switch (p)
                {
                    case "+":
                        this.SingleDigitValue = Convert.ToByte((this.SingleDigitValue >= 9) ? 9 : ++this.SingleDigitValue);
                        break;
                    case "-":
                        this.SingleDigitValue = Convert.ToByte((this.SingleDigitValue <= 0) ? 0 : --this.SingleDigitValue);
                        break;
                }
            });

            this.ChangeMultipleValueCommand = new DelegateCommand<string>(
            p =>
            {
                this.MultipleDigitValue = Convert.ToDouble(p);
            });

            #endregion

            #region eventing:

            this.PropertyChanged += (s, args) =>
            {
                switch (args.PropertyName)
                {
                    case "MultipleDigitValue":
                        this.SetMultipleDigitPlaces();
                        break;
                }
            };

            #endregion
        }

        /// <summary>
        /// Gets or sets the multiple digit value.
        /// </summary>
        /// <value>The multiple digit value.</value>
        public double MultipleDigitValue
        {
            get { return this._multipleDigitValue; }
            set { this.SetProperty(ref this._multipleDigitValue, value); }
        }

        /// <summary>
        /// Gets or sets the multiple digit value collection.
        /// </summary>
        /// <value>The multiple digit value collection.</value>
        public ObservableCollection<byte?> MultipleDigitValueCollection
        {
            get { return this._multipleDigitValueCollection; }
            set { this.SetProperty(ref this._multipleDigitValueCollection, value); }
        }

        /// <summary>
        /// Gets or sets the single digit value.
        /// </summary>
        /// <value>The single digit value.</value>
        public byte SingleDigitValue
        {
            get { return this._singleDigitValue; }
            set { this.SetProperty(ref this._singleDigitValue, value); }
        }

        public ICommand ChangeSingleDigitValueCommand { get; private set; }
        public ICommand ChangeMultipleValueCommand { get; private set; }

        void SetMultipleDigitPlaces()
        {
            var x = Convert.ToInt32(100 * (Math.Round(this.MultipleDigitValue, 2)));
            if (x < 100) return;
            this.MultipleDigitValueCollection[0] = MathUtility.GetDigitInNumber(x, 1);
            this.MultipleDigitValueCollection[1] = MathUtility.GetDigitInNumber(x, 2);

            x = Convert.ToInt32(MathUtility.TruncateNumber(this.MultipleDigitValue));
            if (x <= 1) return;
            this.MultipleDigitValueCollection[2] = MathUtility.GetDigitInNumber(x, 1);
            if (x <= 10) return;
            this.MultipleDigitValueCollection[3] = MathUtility.GetDigitInNumber(x, 2);
            if (x <= 100) return;
            this.MultipleDigitValueCollection[4] = MathUtility.GetDigitInNumber(x, 3);
            if (x <= 1000) return;
            this.MultipleDigitValueCollection[5] = MathUtility.GetDigitInNumber(x, 4);
        }

        double _multipleDigitValue;
        ObservableCollection<byte?> _multipleDigitValueCollection;
        byte _singleDigitValue;
    }
}
