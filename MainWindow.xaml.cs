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

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog();
            //FlowDocument doc = new FlowDocument();
            //printDialog.PrintVisual(this, "Dashboard printing");

            

                // Create a PrintDialog
                PrintDialog printDialog = new PrintDialog();

                if (printDialog.ShowDialog() == true)
                {
                    // Get the selected printer
                    PrintQueue printQueue = printDialog.PrintQueue;

                    // Create a FixedDocument to hold the content you want to print
                    FixedDocument fixedDocument = new FixedDocument();

                    // Create a FixedPage
                    FixedPage fixedPage = new FixedPage();
                    fixedPage.Width = printQueue.GetPrintCapabilities().PageImageableArea.ExtentWidth;
                    fixedPage.Height = printQueue.GetPrintCapabilities().PageImageableArea.ExtentHeight;

                    // Add your dashboard content to the FixedPage
                    
                    Dashboard.Measure(new Size(fixedPage.Width, fixedPage.Height));
                    Dashboard.Arrange(new Rect(new Point(0, 0), Dashboard.DesiredSize));
                    fixedPage.Children.Add(Dashboard);

                    // Add the FixedPage to the FixedDocument
                    PageContent pageContent = new PageContent();
                    ((IAddChild)pageContent).AddChild(fixedPage);
                    fixedDocument.Pages.Add(pageContent);

                    // Print the FixedDocument
                    printDialog.PrintDocument(fixedDocument.DocumentPaginator, "Dashboard Printing");
                
            }

        }
    }
}