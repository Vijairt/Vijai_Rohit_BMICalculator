using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Vijai_Rohit_BMICalculator.PageModels;

public class HealthRecommendationsPageModel : INotifyPropertyChanged
{
    private string _recommendation = string.Empty;
    private string _status = string.Empty;
    private string _statusColor = "#2196F3";
    private string _gender = "male";
    private double _bmi;
    private string _genderSpecificTips = string.Empty;
    private string _genderBMITips = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ICommand BackToResultCommand { get; }
    public ICommand BackToInputCommand { get; }

    public HealthRecommendationsPageModel()
    {
        BackToResultCommand = new Command(OnBackToResult);
        BackToInputCommand = new Command(OnBackToInput);
        UpdateGenderSpecificTips();
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
            UpdateGenderSpecificTips();
        }
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

    public string GenderSpecificTips
    {
        get => _genderSpecificTips;
        set
        {
            if (_genderSpecificTips != value)
            {
                _genderSpecificTips = value;
                OnPropertyChanged();
            }
        }
    }

    public string GenderBMITips
    {
        get => _genderBMITips;
        set
        {
            if (_genderBMITips != value)
            {
                _genderBMITips = value;
                OnPropertyChanged();
            }
        }
    }

    private void UpdateGenderSpecificTips()
    {
        if (Gender == "male")
        {
            GenderSpecificTips = "For Men:\n" +
                "• Build and maintain muscle mass through resistance training (3-4x per week)\n" +
                "• Monitor prostate health and have regular check-ups after age 40\n" +
                "• Ensure adequate protein intake (0.8-1.0g per lb of body weight)\n" +
                "• Manage stress and prioritize mental health - men are at higher risk for stress-related conditions\n" +
                "• Maintain cardiovascular fitness with aerobic exercise (150 min/week minimum)\n" +
                "• Monitor testosterone levels if experiencing fatigue or mood changes\n" +
                "• Stay hydrated and limit alcohol consumption\n" +
                "• Include whole grains, lean proteins, and healthy fats in your diet";

            GenderBMITips = "Understanding BMI for Men:\n" +
                "• Men typically have higher muscle mass, which can result in elevated BMI readings even with low body fat\n" +
                "• This means muscular men may be misclassified as overweight despite being healthy\n" +
                "• Men store fat primarily in the abdomen, which poses greater cardiovascular risks\n" +
                "• Consider pairing BMI with waist circumference measurements for a more accurate health assessment\n" +
                "• A healthy waist circumference for men is less than 40 inches\n" +
                "• Body composition matters more than BMI alone - consult a healthcare provider for personalized assessment";
        }
        else
        {
            GenderSpecificTips = "For Women:\n" +
                "• Include adequate iron-rich foods in your diet (especially during menstruation)\n" +
                "• Focus on bone health with calcium (1000-1200mg daily) and vitamin D\n" +
                "• Balance hormonal health through regular exercise and stress management\n" +
                "• Track nutritional needs during different life stages (puberty, pregnancy, menopause)\n" +
                "• Perform regular breast self-examinations and schedule mammograms as recommended\n" +
                "• Monitor thyroid health - women are more prone to thyroid disorders\n" +
                "• Incorporate flexibility and balance exercises to prevent falls\n" +
                "• Manage reproductive health with proper gynecological care and contraception as needed";

            GenderBMITips = "Understanding BMI for Women:\n" +
                "• Women naturally have 6-11% more body fat than men at the same BMI\n" +
                "• A healthy body fat range for women is 25-31%, compared to 18-24% for men\n" +
                "• Women tend to store fat in hips and thighs, which carries lower health risks than abdominal fat\n" +
                "• BMI alone doesn't account for hormonal changes during pregnancy and menopause that affect body composition\n" +
                "• A healthy waist circumference for women is less than 35 inches\n" +
                "• Monitor how your body changes throughout your menstrual cycle and different life stages";
        }
    }

    private async void OnBackToResult()
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnBackToInput()
    {
        await Shell.Current.GoToAsync("../..");
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
