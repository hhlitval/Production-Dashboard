using Production_Analysis.Comands;
using Production_Analysis.DbServices;
using Production_Analysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Production_Analysis.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<string>? Years { get; }
        public TimePeriod TimePeriod { get; set; }

        private string _selectedYear;

        public string SelectedYear { get; set; }
        public ProductionVolumeViewModel ProductionVolumeViewModel { get; set; }
        public ProductionDowntimeViewModel ProductionDowntimeViewModel { get; set; }
        public EquipmentEffectivenessViewModel EquipmentEffectivenessViewModel { get; set; }
        public InfoCardsViewModel InfoCardsViewModel { get; set; }
        public ShippingMapViewModel ShippingMapViewModel { get; set; }
        public ProductionCostsViewModel ProductionCostsViewModel { get; set; }

        [Obsolete]
        public MainViewModel()
        {
            Years = LoadDbData.GetYearsData();
            SelectedYear = Years[1];
            TimePeriod = new TimePeriod() { 
                Start = new DateTime(int.Parse(SelectedYear), 1, 1),
                End = new DateTime(int.Parse(SelectedYear), 12, 31)};
            ProductionVolumeViewModel = new ProductionVolumeViewModel(TimePeriod);
            ProductionDowntimeViewModel = new ProductionDowntimeViewModel(TimePeriod);
            EquipmentEffectivenessViewModel = new EquipmentEffectivenessViewModel(TimePeriod);
            InfoCardsViewModel = new InfoCardsViewModel(TimePeriod);
            ShippingMapViewModel = new ShippingMapViewModel(TimePeriod);
            ProductionCostsViewModel = new ProductionCostsViewModel(TimePeriod);
        }
        public MainViewModel(TimePeriod timePeriod)
        {
            ProductionVolumeViewModel = new ProductionVolumeViewModel(timePeriod);
            ProductionDowntimeViewModel = new ProductionDowntimeViewModel(timePeriod);
            EquipmentEffectivenessViewModel = new EquipmentEffectivenessViewModel(timePeriod);
            InfoCardsViewModel = new InfoCardsViewModel(timePeriod);
            ShippingMapViewModel = new ShippingMapViewModel(timePeriod);
            ProductionCostsViewModel = new ProductionCostsViewModel(timePeriod);            
        }
    }
}
