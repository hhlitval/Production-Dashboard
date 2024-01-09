using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LiveChartsCore.SkiaSharpView;
using Production_Analysis.Views;
using Production_Analysis.ViewModels;
using Production_Analysis.Models;
using Production_Analysis.DbServices;

namespace Production_Analysis

{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly List<string> _years = LoadDbData.GetYearsData();
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_years, _years.FirstOrDefault())
            };

            SubscribeToSelectedYearChangedEvent();

            MainWindow.Show();

            base.OnStartup(e);
        }

        private void SubscribeToSelectedYearChangedEvent()
        {
            if (MainWindow.DataContext is MainViewModel viewModel)
            {
                viewModel.SelectedYearChanged += ViewModel_SelectedYearChanged;
            }
        }

        private void ViewModel_SelectedYearChanged(object sender, string selectedYear)
        {
            MainWindow.DataContext = new MainViewModel(_years, selectedYear);
        }
    }
}
