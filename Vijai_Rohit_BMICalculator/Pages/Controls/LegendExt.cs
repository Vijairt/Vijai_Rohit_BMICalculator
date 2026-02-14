using Syncfusion.Maui.Toolkit.Charts;

namespace Vijai_Rohit_BMICalculator.Pages.Controls
{
    public class LegendExt : ChartLegend
    {
        protected override double GetMaximumSizeCoefficient()
        {
            return 0.5;
        }
    }
}
