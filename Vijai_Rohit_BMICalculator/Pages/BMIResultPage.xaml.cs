using Vijai_Rohit_BMICalculator.PageModels;

namespace Vijai_Rohit_BMICalculator.Pages;

[QueryProperty(nameof(BMI), "bmi")]
[QueryProperty(nameof(Status), "status")]
[QueryProperty(nameof(StatusColor), "statusColor")]
[QueryProperty(nameof(Recommendation), "recommendation")]
[QueryProperty(nameof(Gender), "gender")]
[QueryProperty(nameof(Weight), "weight")]
[QueryProperty(nameof(Height), "height")]
public partial class BMIResultPage : ContentPage
{
    public BMIResultPage()
    {
        InitializeComponent();
        BindingContext = new BMIResultPageModel();
    }

    public double BMI
    {
        get => (BindingContext as BMIResultPageModel)?.BMI ?? 0;
        set
        {
            if (BindingContext is BMIResultPageModel vm)
                vm.BMI = value;
        }
    }

    public string Status
    {
        get => (BindingContext as BMIResultPageModel)?.Status ?? string.Empty;
        set
        {
            if (BindingContext is BMIResultPageModel vm)
                vm.Status = value;
        }
    }

    public string StatusColor
    {
        get => (BindingContext as BMIResultPageModel)?.StatusColor ?? string.Empty;
        set
        {
            if (BindingContext is BMIResultPageModel vm)
                vm.StatusColor = value;
        }
    }

    public string Recommendation
    {
        get => (BindingContext as BMIResultPageModel)?.Recommendation ?? string.Empty;
        set
        {
            if (BindingContext is BMIResultPageModel vm)
                vm.Recommendation = value;
        }
    }

    public string Gender
    {
        get => (BindingContext as BMIResultPageModel)?.Gender ?? string.Empty;
        set
        {
            if (BindingContext is BMIResultPageModel vm)
                vm.Gender = value;
        }
    }

    public double Weight
    {
        get => (BindingContext as BMIResultPageModel)?.Weight ?? 0;
        set
        {
            if (BindingContext is BMIResultPageModel vm)
                vm.Weight = value;
        }
    }

    public double Height
    {
        get => (BindingContext as BMIResultPageModel)?.Height ?? 0;
        set
        {
            if (BindingContext is BMIResultPageModel vm)
                vm.Height = value;
        }
    }
}
