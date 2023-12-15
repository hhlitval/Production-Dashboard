using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Production_Analysis.UserControls
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public MenuBar()
        {
            InitializeComponent();
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
            //PrintDialog printDialog = new PrintDialog();

            //if (printDialog.ShowDialog() == true)
            //{
            //    // Get the selected printer
            //    PrintQueue printQueue = printDialog.PrintQueue;

            //    // Create a FixedDocument to hold the content you want to print
            //    FixedDocument fixedDocument = new FixedDocument();

            //    // Create a FixedPage
            //    FixedPage fixedPage = new FixedPage();
            //    fixedPage.Width = printQueue.GetPrintCapabilities().PageImageableArea.ExtentWidth;
            //    fixedPage.Height = printQueue.GetPrintCapabilities().PageImageableArea.ExtentHeight;

            //    // Add your dashboard content to the FixedPage

            //    Dashboard.Measure(new Size(fixedPage.Width, fixedPage.Height));
            //    Dashboard.Arrange(new Rect(new Point(0, 0), Dashboard.DesiredSize));
            //    fixedPage.Children.Add(Dashboard);

            //    // Add the FixedPage to the FixedDocument
            //    PageContent pageContent = new PageContent();
            //    ((IAddChild)pageContent).AddChild(fixedPage);
            //    fixedDocument.Pages.Add(pageContent);

            //    // Print the FixedDocument
            //    printDialog.PrintDocument(fixedDocument.DocumentPaginator, "Dashboard Printing");

            //}

        }
    }
}
