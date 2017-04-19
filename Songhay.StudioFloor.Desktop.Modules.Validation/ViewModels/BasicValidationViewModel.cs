using Songhay.Mvvm.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Songhay.StudioFloor.Desktop.Modules.Validation.ViewModels
{
    /// <summary>
    /// Basic Validation View Model
    /// </summary>
    public class BasicValidationViewModel : BindableBaseWithValidation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicValidationViewModel"/> class.
        /// </summary>
        public BasicValidationViewModel()
        {
            this.SelectedUSStates =
                new ObservableCollection<string>
                {
                    {" "},
                    {"[Other]"},
                    {"[Refuse to Answer]"},
                    {"Arkansas"},
                    {"California"},
                    {"Louisiana"},
                    {"Texas"}
                };

            this.YesNoValues =
                new ObservableCollection<string>
                {
                    {"Yes"},
                    {"No"}
                };
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"(?i:^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$)")]
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                if ((!string.IsNullOrEmpty(value)) &&
                    (this._email == value)) return;

                this.ValidateProperty(this, value);
                this.SetProperty(ref this._email, value);
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Display(Name = "First Name")]
        [Required]
        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) &&
                    (this._firstName == value)) return;

                this.ValidateProperty(this, value);
                this.SetProperty(ref this._firstName, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating
        /// whether this instance is residing in US.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance
        /// 	is residing in US; otherwise, <c>false</c>.
        /// </value>
        public bool IsResidingInUS
        {
            get
            {
                return this._isResidingInUS;
            }
            set
            {
                if (!this.ValidateIsResidingInUS(value)) return;
                this.SetProperty(ref this._isResidingInUS, value);
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Display(Name = "Last Name")]
        [Required]
        public string LastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                this.ValidateProperty(this, value);
                this.SetProperty(ref this._lastName, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected US state.
        /// </summary>
        /// <value>The state of the selected US state.</value>
        [Display(Name = "U.S. State")]
        [Required]
        public string SelectedUSState
        {
            get
            {
                return this._selectedUSState;
            }
            set
            {
                if (!string.IsNullOrEmpty(value)) value = value.Trim();
                this.ValidateProperty(this, value);
                this.SetProperty(ref this._selectedUSState, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected US states.
        /// </summary>
        /// <value>The selected US states.</value>
        public ObservableCollection<string> SelectedUSStates { get; set; }

        /// <summary>
        /// Gets or sets the yes-no collection.
        /// </summary>
        /// <value>The yes-no collection.</value>
        public ObservableCollection<string> YesNoValues { get; set; }

        bool ValidateIsResidingInUS(bool isResidingInUS)
        {
            var isValid = (isResidingInUS && (this._selectedUSState != " ")) ||
                (this._selectedUSState == "[Refuse to Answer]");

            if (!isValid)
            {
                this.AddError(this, "IsResidingInUS", ISRESIDINGINUS_ERROR, false);
            }
            else
            {
                this.RemoveError(this, "IsResidingInUS", ISRESIDINGINUS_ERROR);
            }

            return isValid;
        }

        string _email;
        string _firstName;
        bool _isResidingInUS;
        string _lastName;
        string _selectedUSState;

        const string ISRESIDINGINUS_ERROR =
            "You have not selected a U.S. state (or [Other]). " +
            "Are you sure you do NOT reside in the U.S?";

    }
}
