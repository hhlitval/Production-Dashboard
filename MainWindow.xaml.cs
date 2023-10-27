using System.Windows;
using System.Windows.Input;
using Production_Analysis.ViewModels;

namespace Production_Analysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
            //DataContext = new ProductionChartViewModel(new DateTime(2018, 01, 01), new DateTime(2018, 03, 08));
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        //public class ViewModel
        //{
        //    public Axis[] XAxes { get; set; } = new Axis[]
        //    {
        //        new Axis
        //        {
        //            MinStep = 2,
        //            TextSize = 0,
        //            SeparatorsPaint = null
        //        }
        //    };

        //    public Axis[] YAxes { get; set; } = new Axis[]
        //    {
        //        new Axis
        //        {
        //            TextSize = 0,
        //            SeparatorsPaint = null
        //        }
        //    };
    }
}