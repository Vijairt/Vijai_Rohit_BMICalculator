using Vijai_Rohit_BMICalculator.PageModels;

namespace Vijai_Rohit_BMICalculator.Pages;

public partial class BMIInputPage : ContentPage
{
    public BMIInputPage()
    {
        InitializeComponent();
        BindingContext = new BMIInputPageModel();
    }
}
