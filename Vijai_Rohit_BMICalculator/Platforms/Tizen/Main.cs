using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace Vijai_Rohit_BMICalculator
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
