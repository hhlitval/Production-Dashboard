using Production_Analysis.Comands;
using Production_Analysis.DbServices;
using Production_Analysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Production_Analysis.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<string>? _years;

        private string _selectedYear;

        public string SelectedYear
        {
            get { return _selectedYear; }
            set 
            { 
                _selectedYear = value;
                OnPropertyChanged(nameof(_selectedYear));
                
                TimePeriod = new TimePeriod()
                {
                    Start = new DateTime(int.Parse(_selectedYear), 1, 1),
                    End = new DateTime(int.Parse(_selectedYear), 12, 31)
                };
                SelectedYearChanged?.Invoke();
                UpdateViewModel(TimePeriod);
            }
        }

        public event Action SelectedYearChanged;

        public TimePeriod TimePeriod { get; set; }
        public ObservableCollection<string>? Years
        {
            get { return _years; }
            set
            {
                _years = value;
                OnPropertyChanged(nameof(Years));               
            }
        }

        private void UpdateViewModel(TimePeriod timePeriod)
        {
            ProductionVolumeViewModel = new ProductionVolumeViewModel(timePeriod);
            ProductionDowntimeViewModel = new ProductionDowntimeViewModel(timePeriod);
            EquipmentEffectivenessViewModel = new EquipmentEffectivenessViewModel(timePeriod);
            InfoCardsViewModel = new InfoCardsViewModel(timePeriod);
            ShippingMapViewModel = new ShippingMapViewModel(timePeriod);
            ProductionCostsViewModel = new ProductionCostsViewModel(timePeriod);
        }

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
            SelectedYear = Years[0];
            ProductionVolumeViewModel = new ProductionVolumeViewModel(TimePeriod);
            ProductionDowntimeViewModel = new ProductionDowntimeViewModel(TimePeriod);
            EquipmentEffectivenessViewModel = new EquipmentEffectivenessViewModel(TimePeriod);
            InfoCardsViewModel = new InfoCardsViewModel(TimePeriod);
            ShippingMapViewModel = new ShippingMapViewModel(TimePeriod);
            ProductionCostsViewModel = new ProductionCostsViewModel(TimePeriod);            
        }
    }
}
