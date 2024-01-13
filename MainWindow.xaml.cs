using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Production_Analysis.ViewModels;
using Microsoft.Win32;
using System.IO;
using System.Reflection.Metadata;
using Production_Analysis.DbServices;
using System.Collections.Generic;
using System.Linq;

namespace Production_Analysis
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> _years = LoadDbData.GetYearsData();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(_years, _years.FirstOrDefault());
            SubscribeToSelectedYearChangedEvent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void SubscribeToSelectedYearChangedEvent()
        {
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.SelectedYearChanged += ViewModel_SelectedYearChanged;
            }
        }

        private void ViewModel_SelectedYearChanged(object sender, string selectedYear)
        {
            mainWindow.DataContext = new MainViewModel(_years, selectedYear);
        }
    }
}