using Vijai_Rohit_BMICalculator.PageModels;

namespace Vijai_Rohit_BMICalculator.Pages;

[QueryProperty(nameof(Recommendation), "recommendation")]
[QueryProperty(nameof(Status), "status")]
[QueryProperty(nameof(StatusColor), "statusColor")]
[QueryProperty(nameof(Gender), "gender")]
[QueryProperty(nameof(BMI), "bmi")]
public partial class HealthRecommendationsPage : ContentPage
{
    public HealthRecommendationsPage()
    {
        InitializeComponent();
        BindingContext = new HealthRecommendationsPageModel();
    }

    public string Recommendation
    {
        get => (BindingContext as HealthRecommendationsPageModel)?.Recommendation ?? string.Empty;
        set
        {
            if (BindingContext is HealthRecommendationsPageModel vm)
                vm.Recommendation = value;
        }
    }

    public string Status
    {
        get => (BindingContext as HealthRecommendationsPageModel)?.Status ?? string.Empty;
        set
        {
            if (BindingContext is HealthRecommendationsPageModel vm)
                vm.Status = value;
        }
    }

    public string StatusColor
    {
        get => (BindingContext as HealthRecommendationsPageModel)?.StatusColor ?? string.Empty;
        set
        {
            if (BindingContext is HealthRecommendationsPageModel vm)
                vm.StatusColor = value;
        }
    }

    public string Gender
    {
        get => (BindingContext as HealthRecommendationsPageModel)?.Gender ?? string.Empty;
        set
        {
            if (BindingContext is HealthRecommendationsPageModel vm)
                vm.Gender = value;
        }
    }

    public double BMI
    {
        get => (BindingContext as HealthRecommendationsPageModel)?.BMI ?? 0;
        set
        {
            if (BindingContext is HealthRecommendationsPageModel vm)
                vm.BMI = value;
        }
    }
}
