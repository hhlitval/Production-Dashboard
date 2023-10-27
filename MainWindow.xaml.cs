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
using LiveChartsCore.Defaults;
using System.Collections.ObjectModel;
using Production_Analysis.Models;
using System.Windows.Markup;
using Production_Analysis.ViewModels;

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

            //Production chart
            public ISeries[] Production { get; set; } =
            {
                new LineSeries<double>
                {
                    Values = new double[]{166,180,123,158,90,124,146,162,150,169,166,144},
                    Fill = null,
                    Stroke = new SolidColorPaint(new SKColor(90, 169, 230)){StrokeThickness = 3},
                    GeometrySize = 0,
                    LineSmoothness = 1
                }
            };

            public Axis[] XProduction { get; set; } = new[]
            {
                new Axis
                {
                    Labels = new string[]{"Jan 22", "Feb 22", "Mär 22", "Apr 22", "Mai 22", "Jun 22", "Jul 22",
                    "Aug 22", "Sep 22", "Okt 22", "Nov 22", "Dez 22"}
                }
            };

            public Axis[] YProduction { get; set; } =
            {
                new Axis
                {
                    SeparatorsPaint = null
                }
            };

            //
            public IEnumerable<ISeries> EquipmentEfficiency { get; set; } = new GaugeBuilder()                 
                .WithLabelsSize(30)
                .WithInnerRadius(80)
                .WithLabelFormatter(point => point.PrimaryValue + " %" + point.Context.Series.Name)
                .WithBackgroundInnerRadius(0)
                .WithBackgroundOffsetRadius(10)
                .WithBackground(new SolidColorPaint(new SKColor(247, 247, 255)))
                .AddValue(67.29, "", new SKColor(90, 169, 230))                
                .BuildSeries();

            //Productivity chart
            public ISeries[] ProductionCosts { get; set; } =
            {
                new LineSeries<double>
                {
                    Values = new double[] { 1, 2, 1, 1.5, 1.2, 0.9, 1, 1.3, 1.5, 1, 1.4, 1.6 },
                    Stroke = new SolidColorPaint(new SKColor(90, 169, 230)){StrokeThickness = 3},
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 1
                }
            };

            public Axis[] YProductionCosts { get; set; } =
            {
                new Axis
                {
                    SeparatorsPaint = null
                }
            };

            public Axis[] XProductionCosts { get; set; } = new[]
            {
                new Axis
                {
                    Labels = new string[]{"Jan 22", "Feb 22", "Mär 22", "Apr 22", "Mai 22", "Jun 22", "Jul 22",
                    "Aug 22", "Sep 22", "Okt 22", "Nov 22", "Dez 22"}
                }
            };

            //Production losses chart
            //TODO: rename
            public ISeries[] DefectProduction { get; set; } =
            {
                new ColumnSeries<double>
                {
                    Values = new ObservableCollection<double> { 20, 50, 40, 20, 40, 30, 50, 20, 50, 40, 30, 10 },
                    Fill = new SolidColorPaint(new SKColor(90, 169, 230)),
                    // Defines the distance between every bars in the series
                    Padding = 8,
                    DataLabelsSize = 2,

                    // Defines the max width a bar can have
                    MaxBarWidth = double.PositiveInfinity,
                    Rx = 50,
                    Ry = 50
                }
            };

            public Axis[] XDefectProduction { get; set; } = new[]
            {
                new Axis
                {
                    Labels = new string[]{"Jan 22", "Feb 22", "Mär 22", "Apr 22", "Mai 22", "Jun 22", "Jul 22",
                    "Aug 22", "Sep 22", "Okt 22", "Nov 22", "Dez 22"}
                }
            };

            public Axis[] YDefectProduction { get; set; } =
            {
                new Axis
                {
                    SeparatorsPaint = null
                }
            };


            public ViewModel()
            {
                var lands = new HeatLand[]
                {
                new() { Name = "bra", Value = 14 },
                new() { Name = "mex", Value = 10 },
                new() { Name = "usa", Value = 20 },
                new() { Name = "ind", Value = 12 },
                new() { Name = "deu", Value = 13 },
                new() { Name= "jpn", Value = 15 },
                new() { Name = "chn", Value = 18 },
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
                            new SKColor(191, 220, 242).AsLvcColor(), // the first element is the "coldest" 
                            new SKColor(90, 169, 230).AsLvcColor(),
                            new SKColor(4, 105, 181).AsLvcColor() // the last element is the "hottest" 
                        },
                    Lands = lands }
                };
            }

            public List<Shipping>? Lands { get; set; } = new List<Shipping>()
            {
                new Shipping { DestinationLand = "USA", Quantity = 12864, Percentage = 14.3M},
                new Shipping { DestinationLand = "China", Quantity = 10136, Percentage = 11.3M},
                new Shipping { DestinationLand = "Japan", Quantity = 7561, Percentage = 8.4M},
                new Shipping { DestinationLand = "Brasilien", Quantity = 7089, Percentage = 7.9M},
                new Shipping { DestinationLand = "Deutschland", Quantity = 6954, Percentage = 7.7M},
                new Shipping { DestinationLand = "Indien", Quantity = 6233, Percentage = 6.9M}
            };
            
        }
    }
}