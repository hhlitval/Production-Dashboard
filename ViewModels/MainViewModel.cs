using Production_Analysis.Comands;
using Production_Analysis.DbServices;
using Production_Analysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Production_Analysis.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public event EventHandler<string>? SelectedYearChanged;
        public List<string>? Years { get; set; }
        public TimePeriod TimePeriod { get; set; }
        
        private string _selectedYear;
        public string SelectedYear
        {
            get { return _selectedYear; }
            set
            {
                _selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
                SelectedYearChanged?.Invoke(this, SelectedYear);                
            }
        }        

        public ProductionVolumeViewModel ProductionVolumeViewModel { get; set; }
        public ProductionDowntimeViewModel ProductionDowntimeViewModel { get; set; }
        public EquipmentEffectivenessViewModel EquipmentEffectivenessViewModel { get; set; }
        public InfoCardsViewModel InfoCardsViewModel { get; set; }
        public ShippingMapViewModel ShippingMapViewModel { get; set; }
        public ProductionCostsViewModel ProductionCostsViewModel { get; set; }

        
        public MainViewModel(List<string> _years, string selectedYear)
        {
            Years = _years;
            SelectedYear = selectedYear;
            TimePeriod = new TimePeriod(selectedYear);
            ProductionVolumeViewModel = new ProductionVolumeViewModel(TimePeriod);
            ProductionDowntimeViewModel = new ProductionDowntimeViewModel(TimePeriod);
            EquipmentEffectivenessViewModel = new EquipmentEffectivenessViewModel(TimePeriod);
            InfoCardsViewModel = new InfoCardsViewModel(TimePeriod);
            ShippingMapViewModel = new ShippingMapViewModel(TimePeriod);
            ProductionCostsViewModel = new ProductionCostsViewModel(TimePeriod);            
        }
    }
}
