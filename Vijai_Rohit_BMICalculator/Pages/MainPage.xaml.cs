using Vijai_Rohit_BMICalculator.Models;
using Vijai_Rohit_BMICalculator.PageModels;

namespace Vijai_Rohit_BMICalculator.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}