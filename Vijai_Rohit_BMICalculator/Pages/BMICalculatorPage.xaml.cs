using Vijai_Rohit_BMICalculator.PageModels;

namespace Vijai_Rohit_BMICalculator.Pages;

public partial class BMICalculatorPage : ContentPage
{
    private BMICalculatorPageModel? _pageModel;

    public BMICalculatorPage()
    {
        InitializeComponent();
        _pageModel = new BMICalculatorPageModel();
        _pageModel.SelectGenderCommand = new Command<string?>(SelectGender);
        _pageModel.CalculateBMICommand = new Command(OnCalculateBMI);
        BindingContext = _pageModel;
    }

    private void SelectGender(string? gender)
    {
        if (_pageModel != null && gender != null)
        {
            _pageModel.SelectGender(gender);
        }
    }

    private async void OnCalculateButtonClicked(object sender, EventArgs e)
    {
        if (_pageModel == null)
            return;

        _pageModel.OnCalculateBMI();

        // Show the results in a modal dialog
        string title = "Your calculated BMI results are:";
        string message = $"Gender: {_pageModel.Gender.ToUpper()}\n" +
                         $"BMI: {_pageModel.BMI:F2}\n" +
                         $"Health Status: {_pageModel.Status}\n" +
                         $"Recommendations:\n{_pageModel.Recommendation}";

        await DisplayAlert(title, message, "Ok");
    }

    private void OnCalculateBMI()
    {
        if (_pageModel != null)
        {
            _pageModel.OnCalculateBMI();
        }
    }
}
