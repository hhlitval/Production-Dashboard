using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

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
            PdfDocument pdf = new PdfDocument();
            PdfPage page = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(page);

            // Capture the window as an image
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(1200, 800, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(this);

            // Convert the image to a PDF-compatible format
            MemoryStream memoryStream = new MemoryStream();
            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            encoder.Save(memoryStream);

            XImage image = XImage.FromStream(memoryStream);
            graph.DrawImage(image, 0, 0);

            // Save the PDF
            string filePath = @"C:\\Users\\sasha\\Desktop\proanalysis.pdf"; 
            pdf.Save(filePath);
        }
    }
}
