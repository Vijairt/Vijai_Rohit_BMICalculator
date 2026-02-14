using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Vijai_Rohit_BMICalculator.PageModels;

public class BMICalculatorPageModel : INotifyPropertyChanged
{
    private string _gender = "male"; // default gender
    private double _weight = 90;
    private double _height = 50;
    private double _bmi = 0;
    private string _status = string.Empty;
    private string _statusColor = "#2196F3"; // Blue for neutral
    private string _recommendation = string.Empty;
    private bool _isMaleSelected = true;
    private bool _isFemaleSelected = false;
    public ICommand? SelectGenderCommand { get; set; }
    public ICommand? CalculateBMICommand { get; set; }
    public EventHandler<BMIResultEventArgs>? BMICalculated;

    public string Gender
    {
        get => _gender;
        set
        {
            if (_gender != value)
            {
                _gender = value;
                OnPropertyChanged();
                CalculateBMI();
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
                CalculateBMI();
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
                CalculateBMI();
            }
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

    public bool IsMaleSelected
    {
        get => _isMaleSelected;
        set
        {
            if (_isMaleSelected != value)
            {
                _isMaleSelected = value;
                OnPropertyChanged();
            }
        }
    }

    public bool IsFemaleSelected
    {
        get => _isFemaleSelected;
        set
        {
            if (_isFemaleSelected != value)
            {
                _isFemaleSelected = value;
                OnPropertyChanged();
            }
        }
    }

    public void SelectGender(string gender)
    {
        if (gender == "male")
        {
            IsMaleSelected = true;
            IsFemaleSelected = false;
            Gender = "male";
        }
        else
        {
            IsMaleSelected = false;
            IsFemaleSelected = true;
            Gender = "female";
        }
    }

    public void OnCalculateBMI()
    {
        if (Height <= 0)
        {
            Status = "Invalid height";
            Recommendation = "Please enter a valid height";
            StatusColor = "#808080"; // Gray
            return;
        }

        if (Weight <= 0)
        {
            Status = "Invalid weight";
            Recommendation = "Please enter a valid weight";
            StatusColor = "#808080"; // Gray
            return;
        }

        // BMI = (weight in pounds * 703) / (height in inches)^2
        BMI = (Weight * 703) / (Height * Height);
        BMI = Math.Round(BMI, 2);

        if (Gender == "male")
        {
            ClassifyBMIMale();
        }
        else
        {
            ClassifyBMIFemale();
        }

        BMICalculated?.Invoke(this, new BMIResultEventArgs
        {
            BMI = BMI,
            Gender = Gender,
            Status = Status,
            Recommendation = Recommendation
        });
    }

    private void CalculateBMI()
    {
        OnCalculateBMI();
    }

    private void ClassifyBMIMale()
    {
        if (BMI < 18.5)
        {
            Status = "Underweight";
            StatusColor = "#2196F3"; // Blue
            Recommendation = "Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";
        }
        else if (BMI < 25)
        {
            Status = "Normal Weight";
            StatusColor = "#4CAF50"; // Green
            Recommendation = "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";
        }
        else if (BMI < 30)
        {
            Status = "Overweight";
            StatusColor = "#FF9800"; // Orange
            Recommendation = "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.";
        }
        else
        {
            Status = "Obese";
            StatusColor = "#F44336"; // Red
            Recommendation = "Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
        }
    }

    private void ClassifyBMIFemale()
    {
        if (BMI < 18)
        {
            Status = "Underweight";
            StatusColor = "#2196F3"; // Blue
            Recommendation = "Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";
        }
        else if (BMI < 24)
        {
            Status = "Normal Weight";
            StatusColor = "#4CAF50"; // Green
            Recommendation = "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";
        }
        else if (BMI < 29)
        {
            Status = "Overweight";
            StatusColor = "#FF9800"; // Orange
            Recommendation = "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.";
        }
        else
        {
            Status = "Obese";
            StatusColor = "#F44336"; // Red
            Recommendation = "Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class BMIResultEventArgs : EventArgs
{
    public double BMI { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Recommendation { get; set; } = string.Empty;
}

