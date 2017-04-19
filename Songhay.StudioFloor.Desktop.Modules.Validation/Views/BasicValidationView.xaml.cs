using Songhay.Extensions;
using Songhay.Mvvm.Models;
using System.Linq;
using System.Windows.Controls;

namespace Songhay.StudioFloor.Desktop.Modules.Validation.Views
{
    /// <summary>
    /// Interaction logic for BasicValidationView.xaml
    /// </summary>
    public partial class BasicValidationView : UserControl, IView
    {
        public BasicValidationView()
        {
            InitializeComponent();

            this.Validate.Click += (s, args) =>
            {
                this.FormFields.Children
                    .OfType<StackPanel>()
                    .First().Children
                    .OfType<ComboBox>()
                    .ForEachInEnumerable(i => i.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource());

                this.FormFields.Children
                    .OfType<TextBox>()
                    .ForEachInEnumerable(i => i.GetBindingExpression(TextBox.TextProperty).UpdateSource());
            };
        }
    }
}
