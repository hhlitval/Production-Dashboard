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
using LiveChartsCore.Drawing;

namespace Production_Analysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly SKColor productionChartColor = new SKColor(216, 49, 91);
        private static readonly SolidColorPaint productivityChartColor = new SolidColorPaint(new SKColor(0, 48, 73)) { StrokeThickness = 3 };

        private static readonly LinearGradientPaint energyConsumptionChartColor = new LinearGradientPaint(new[] 
                                { new SKColor(239, 71, 111), new SKColor(255, 255, 255) }, new SKPoint(0.5f, 0), new SKPoint(0.5f, 1));
        private static readonly SolidColorPaint energyConsumptionStrokeColor = new SolidColorPaint(new SKColor(239, 71, 111)) { StrokeThickness = 2 };

        private static readonly LinearGradientPaint emissionsChartColor = new LinearGradientPaint(new[] 
                                { new SKColor(6, 214, 160), new SKColor(255, 255, 255) }, new SKPoint(0.5f, 0), new SKPoint(0.5f, 1));
        private static readonly SolidColorPaint emissionsStrokeColor = new SolidColorPaint(new SKColor(6, 214, 160)) { StrokeThickness = 2 };

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
            public IEnumerable<ISeries> PieSeries { get; set; }

            public ISeries[] Series { get; set; }
                = new ISeries[]
                {                
                new ColumnSeries<double>
                {
                    Name = "Produktionsmenge",
                    Values = new double[] { 4, 2, 2, 8, 1, 6, 3 },
                    Fill = new SolidColorPaint(productionChartColor)
                },
                new LineSeries<double>
                {
                    Name = "Materialproduktivität",
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Stroke = productivityChartColor,   
                    Fill = null
                }
                };

            public List<ISeries> StackedSeries { get; set; } = new()
            {
                new StackedAreaSeries<double>
                {
                    DataPadding = new LvcPoint(0, 1),
                    Values = new List<double> { 3, 2, 3, 5, 3, 4, 6 },
                    Stroke = energyConsumptionStrokeColor,
                    Fill = energyConsumptionChartColor,
                    LineSmoothness = 0.2
                }                
            };

            public List<ISeries> StackedSeries2 { get; set; } = new()
            {
                new StackedAreaSeries<double>
                {
                    DataPadding = new LvcPoint(0, 1),
                    Values = new List<double> { 6, 2, 5, 3, 5, 4, 2 },
                    Stroke = emissionsStrokeColor,
                    Fill = emissionsChartColor,                    
                    LineSmoothness = 0.2
                }
            };

            public ViewModel()
            {
                var lands = new HeatLand[]
                {
                new() { Name = "bra", Value = 13 },
                new() { Name = "mex", Value = 10 },
                new() { Name = "usa", Value = 20 },
                new() { Name = "kaz", Value = 1 },
                new() { Name = "ind", Value = 12 },
                new() { Name = "deu", Value = 13 },
                new() { Name= "jpn", Value = 15 },
                new() { Name = "chn", Value = 20 },
                new() { Name = "nor", Value = 11 },
                new() { Name = "fra", Value = 8 },
                new() { Name = "esp", Value = 7 },
                new() { Name = "kor", Value = 10 },
                new() { Name = "zaf", Value = 12 },
                new() { Name = "tur", Value = 5 },
                new() { Name = "are", Value = 13 }
                };
                GeoSeries = new HeatLandSeries[] { new HeatLandSeries { 
                    HeatMap = new[]
                        {
                            new SKColor(76, 201, 240).AsLvcColor(), // the first element is the "coldest" 
                            new SKColor(17, 138, 178).AsLvcColor(),
                            new SKColor(7, 59, 76).AsLvcColor() // the last element is the "hottest" 
                        }, 
                    Lands = lands } 
                };

                var data = new double[] { 2, 3, 1, 4 };                

                PieSeries = data.AsLiveChartsPieSeries((value, series) =>
                {
                    series.Name = $"Schicht {value}";
                    series.DataLabelsPaint = new SolidColorPaint(SKColors.White);
                    series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle;
                    series.DataLabelsFormatter = point => point.PrimaryValue.ToString("N1") + " %";
                    series.DataLabelsSize = 15;
                });
            }           
           

        }
    }
}