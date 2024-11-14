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
using System.Collections.ObjectModel;

namespace Production_Analysis
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<string> _years = LoadDbData.GetYearsData();
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel(_years, _years.FirstOrDefault());            
            DataContext = mainViewModel;
            mainViewModel.SelectedYearChanged += ViewModel_SelectedYearChanged;
        }
        

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }        

        private void ViewModel_SelectedYearChanged(object sender, string selectedYear)
        {
            DataContext = new MainViewModel(_years, selectedYear);
        }
    }
}