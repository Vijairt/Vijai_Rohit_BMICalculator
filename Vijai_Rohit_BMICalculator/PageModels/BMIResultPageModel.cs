using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Vijai_Rohit_BMICalculator.PageModels;

public class BMIResultPageModel : INotifyPropertyChanged
{
    private double _bmi;
    private string _status = string.Empty;
    private string _statusColor = "#2196F3";
    private string _recommendation = string.Empty;
    private string _gender = "male";
    private double _weight = 90;
    private double _height = 50;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ICommand ViewRecommendationsCommand { get; }
    public ICommand BackToInputCommand { get; }

    public BMIResultPageModel()
    {
        ViewRecommendationsCommand = new Command(OnViewRecommendations);
        BackToInputCommand = new Command(OnBackToInput);
    }

    public double BMI
    {
        get => _bmi;
        set
        {
            if (_bmi != value)
            {
                _bmi = value;
                OnPropertyChanged();
            }
        }
    }

    public string Status
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                OnPropertyChanged();
            }
        }
    }

    public string StatusColor
    {
        get => _statusColor;
        set
        {
            if (_statusColor != value)
            {
                _statusColor = value;
                OnPropertyChanged();
            }
        }
    }

    public string Recommendation
    {
        get => _recommendation;
        set
        {
            if (_recommendation != value)
            {
                _recommendation = value;
                OnPropertyChanged();
            }
        }
    }

    public string Gender
    {
        get => _gender;
        set
        {
            if (_gender != value)
            {
                _gender = value;
                OnPropertyChanged();
            }
        }
    }

    public double Weight
    {
        get => _weight;
        set
        {
            if (_weight != value)
            {
                _weight = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(UserInfo));
            }
        }
    }

    public double Height
    {
        get => _height;
        set
        {
            if (_height != value)
            {
                _height = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(UserInfo));
            }
        }
    }

    public string UserInfo => $"{Gender.ToUpper()} | {Weight:F0} lbs | {Height:F0} inches";

    private async void OnViewRecommendations()
    {
        var queryParams = new Dictionary<string, object>
        {
            { "recommendation", Recommendation },
            { "status", Status },
            { "statusColor", StatusColor },
            { "gender", Gender },
            { "bmi", BMI }
        };

        await Shell.Current.GoToAsync($"bmi_recommendations?recommendation={Uri.EscapeDataString(Recommendation)}&status={Uri.EscapeDataString(Status)}&statusColor={Uri.EscapeDataString(StatusColor)}&gender={Gender}&bmi={BMI}");
    }

    private async void OnBackToInput()
    {
        await Shell.Current.GoToAsync("..");
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
