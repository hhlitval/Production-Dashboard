using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Production_Analysis.Models;
using Production_Analysis.ViewModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Production_Analysis.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {            
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;                
                printDialog.PrintVisual(this, "Window Printing");
            }
        }

        private void PrintPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)ActualWidth+30, (int)ActualHeight+50, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(this);

                // Create a PDF and embed the captured image
                using (PdfDocument pdf = new PdfDocument())
                {
                    PdfPage page = pdf.AddPage();
                    
                    page.Orientation = PdfSharp.PageOrientation.Landscape;

                    XGraphics graph = XGraphics.FromPdfPage(page);

                    // Convert RenderTargetBitmap to BitmapSource
                    BitmapSource bitmapSource = renderTargetBitmap;

                    // Convert BitmapSource to XImage
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                        encoder.Save(memoryStream);

                        memoryStream.Position = 0;
                        XImage windowImage = XImage.FromStream(memoryStream);

                        // Draw the image on the PDF page
                        graph.DrawImage(windowImage, 0, 0, page.Width, page.Height);
                    }

                    // Save the PDF file
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string pdfFilePath = Path.Combine(desktopPath, "proanalysis.pdf");
                    pdf.Save(pdfFilePath);
                    MessageBox.Show("Window content saved as PDF.", "PDF Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);               
            }
        }

        private void ProductionVolumeView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
