using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System;

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
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(this, "Window Printing");
            }
        }

        private void PrintPDF_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)ActualWidth, (int)ActualHeight, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(this);

            // Convert the captured image to a BitmapImage
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            // Save the rendered image to a file
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string imageFilePath = Path.Combine(desktopPath, "windowImage.png");

            using (FileStream file = new FileStream(imageFilePath, FileMode.Create))
            {
                encoder.Save(file);
            }

            // Create a PDF and embed the captured image
            PdfDocument pdf = new PdfDocument();
            PdfPage page = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(page);

            // Load the captured image
            XImage windowImage = XImage.FromFile(imageFilePath);

            // Draw the image on the PDF page
            graph.DrawImage(windowImage, 0, 0);

            // Save the PDF file
            string pdfFilePath = Path.Combine(desktopPath, "windowContent.pdf");
            pdf.Save(pdfFilePath);
        }
    }
}
