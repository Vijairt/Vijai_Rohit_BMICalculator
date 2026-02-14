using Vijai_Rohit_BMICalculator.Models;

namespace Vijai_Rohit_BMICalculator.Pages
{
    public partial class ProjectDetailPage : ContentPage
    {
        public ProjectDetailPage(ProjectDetailPageModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}
