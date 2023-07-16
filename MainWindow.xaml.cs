using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Drawing.Drawing2D;
using LiveChartsCore.SkiaSharpView.Painting.Effects;

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
            
            DataContext = new ViewModel();
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

        public class ViewModel
        {
            public Axis[] XAxes { get; set; } = new Axis[]
            {
                new Axis
                {             
                    MinStep = 2,
                    TextSize = 0,
                    SeparatorsPaint = null
                }
            };

            public Axis[] YAxes { get; set; } = new Axis[]
            {
                new Axis
                {   
                    TextSize = 0,
                    SeparatorsPaint = null
                }
            };
            public HeatLandSeries[] GeoSeries { get; set; }
            public ISeries[] Series { get; set; }
                = new ISeries[]
                {                
                new ColumnSeries<double>
                {
                    Name = "Produktionsmenge",
                    Values = new double[] { 4, 2, 2, 8, 1, 6, 3 },
                    Fill = new SolidColorPaint(new SKColor(226, 149, 120))
                },
                new LineSeries<double>
                {
                    Name = "Materialproduktivität",
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Stroke = new SolidColorPaint(new SKColor(0, 109, 119)) {StrokeThickness = 3},                    
                    Fill = null
                }
                };

            public List<ISeries> StackedSeries { get; set; } = new()
            {
                new StackedAreaSeries<double>
                {
                    Values = new List<double> { 3, 2, 3, 5, 3, 4, 6 },
                    Stroke = new SolidColorPaint(new SKColor(0, 109, 119)){StrokeThickness = 2},
                    Fill = new LinearGradientPaint(new [] { new SKColor(21, 165, 179), new SKColor(126, 232, 242) }, new SKPoint(0.5f, 0),new SKPoint(0.5f, 1)),
                    LineSmoothness = 0
                }                
            };

            public List<ISeries> StackedSeries2 { get; set; } = new()
            {
                new StackedAreaSeries<double>
                {
                    Values = new List<double> { 6, 2, 5, 3, 5, 4, 2 },
                    Stroke = new SolidColorPaint(new SKColor(252, 134, 126)){StrokeThickness = 2},
                    Fill = new LinearGradientPaint(new [] { new SKColor(252, 134, 126), new SKColor(252, 226, 225) }, new SKPoint(0.5f, 0),new SKPoint(0.5f, 1)),
                    LineSmoothness = 0
                }
            };
            public ViewModel()
            {
                var lands = new HeatLand[]
                {
                new() { Name = "bra", Value = 13 },
                new() { Name = "mex", Value = 10 },
                new() { Name = "usa", Value = 20 },
                new() { Name = "kaz", Value = 8 },
                new() { Name = "ind", Value = 12 },
                new() { Name = "deu", Value = 13 },
                new() { Name= "jpn", Value = 15 },
                new() { Name = "chn", Value = 14 },
                new() { Name = "nor", Value = 11 },
                new() { Name = "fra", Value = 8 },
                new() { Name = "esp", Value = 7 },
                new() { Name = "kor", Value = 10 },
                new() { Name = "zaf", Value = 12 },
                new() { Name = "are", Value = 13 }
                };
                GeoSeries = new HeatLandSeries[] { new HeatLandSeries { 
                    HeatMap = new[]
                        {
                            new SKColor(21, 165, 179).AsLvcColor(), // the first element is the "coldest" 
                            new SKColor(126, 232, 242).AsLvcColor(),
                            new SKColor(0,109,119).AsLvcColor() // the last element is the "hottest" 
                        }, 
                    Lands = lands } 
                };
            }
        }
    }
}