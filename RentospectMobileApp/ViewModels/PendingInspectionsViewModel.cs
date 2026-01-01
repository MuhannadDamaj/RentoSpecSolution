using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentospectMobileApp.DBService.Contracts;
using RentospectMobileApp.Entities;
using RentospectMobileApp.Entities.CustomEnitities;
using RentospectMobileApp.Services;
using RentospectMobileApp.Views;
using RentospectShared.CommonEnum;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentospectMobileApp.ViewModels
{
    public partial class PendingInspectionsViewModel : ObservableObject
    {
        private readonly IInspectionTypeDBService _inspectionTypeDBService;
        private readonly IInspectionDBService inspectionDBService;
        private readonly InspectionHolderService inspectionHolderService;
        private ObservableCollection<EnumItem> inspectionTypes = new();
        public ObservableCollection<EnumItem> InspectionTypes
        {
            get
            {
                return inspectionTypes;
            }
            set
            {
                inspectionTypes = value;
                OnPropertyChanged();
            }
        }
        private EnumItem _selectedInspectionType;
        public EnumItem SelectedInspectionType
        {
            get => _selectedInspectionType;
            set
            {
                if (SetProperty(ref _selectedInspectionType, value))
                {
                    FilterInspections();
                }
            }
        }

        private DateTime _fromDate = DateTime.Today.AddDays(-7); // Default: last 7 days
        public DateTime FromDate
        {
            get => _fromDate;
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    OnPropertyChanged();
                    FilterInspections(); // Optional: re-filter list
                }
            }
        }

        private DateTime _toDate = DateTime.Today;
        public DateTime ToDate
        {
            get => _toDate;
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    OnPropertyChanged();
                    FilterInspections(); // Optional: re-filter list
                }
            }
        }

        private string searchText = string.Empty;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
                FilterInspections();
            }
        }
        public IRelayCommand ShowFromDatePickerCommand { get; }
        public IRelayCommand ShowToDatePickerCommand { get; }
        public ICommand NavigateToDetailsCommand { get; }

        public List<Inspection> Inspections { get; set; } = new();

        private ObservableCollection<Inspection> filteredInspections = new();
        public ObservableCollection<Inspection> FilteredInspections
        {
            get
            {
                return filteredInspections;
            }
            set
            {
                filteredInspections = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand { get; }

        public bool IsRefreshing { get; set; }

        public PendingInspectionsViewModel(IInspectionTypeDBService inspectionTypeDBService,
                                           IInspectionDBService inspectionDBService,
                                           InspectionHolderService inspectionHolderService)
        {
            _inspectionTypeDBService = inspectionTypeDBService;
            this.inspectionDBService = inspectionDBService;
            this.inspectionHolderService = inspectionHolderService;
            RefreshCommand = new Command(RefreshList);
            NavigateToDetailsCommand = new Command<Inspection>(OnNavigateToDetails);
        }
        private void FilterInspections()
        {
            List<Inspection> filteredInspections = Inspections.Where(inspection =>
                                                                        inspection.InspectionDate >= FromDate.ToUniversalTime()
                                                                        &&
                                                                        inspection.InspectionDate <= ToDate.AddDays(1).AddSeconds(-1).ToUniversalTime()
                                                                    ).ToList();
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                filteredInspections = filteredInspections.Where(i =>
                    (i.DriverName.ToUpper().Contains(SearchText.ToUpper()))
                    ||
                    (i.InspectionNumber.ToUpper().Contains(SearchText.ToUpper())
                    ||
                    (i.PlateNumber.ToUpper().Contains(SearchText.ToUpper()))
                    ||
                    (i.AgreementNumber.ToUpper().Contains(SearchText.ToUpper()))
                    )
                ).ToList();
            }
                if (SelectedInspectionType?.Value == null)
            {
                FilteredInspections = new ObservableCollection<Inspection>(filteredInspections);
            }
            else
            {
                var selectedValue = SelectedInspectionType.Value.Value;
                FilteredInspections = new ObservableCollection<Inspection>(filteredInspections.Where(i => i.CheckType == selectedValue));
            }
        }
        private async void OnNavigateToDetails(Inspection inspection)
        {
            if (inspection == null)
                return;
            inspectionHolderService.Clear();
            await Shell.Current.GoToAsync(nameof(InspectionDetailsView), true, new Dictionary<string, object>
            {
                { "Inspection", inspection }
            });
        }
        private void RefreshList()
        {
            IsRefreshing = true;
            var reversed = new ObservableCollection<Inspection>(FilteredInspections.Reverse());
            Inspections.Clear();
            foreach (var item in reversed)
                Inspections.Add(item);
            IsRefreshing = false;
        }
        public async Task InitializeAsync()
        {
            await LoadInspectionAndInspectionTypesAsync();
        }
        private async Task LoadInspectionAndInspectionTypesAsync()
        {
            Inspections = await inspectionDBService.GetInspectionsAsync();
            FilteredInspections = new ObservableCollection<Inspection>(Inspections);

            List<EnumItem> enumItems = new List<EnumItem>();

            enumItems.Add(new EnumItem { Name = "All Types", Value = null });

            foreach (InspectionCheckTypeEnum type in Enum.GetValues(typeof(InspectionCheckTypeEnum)))
            {
                string description = type.GetType()
                                         .GetField(type.ToString())
                                         ?.GetCustomAttribute<DescriptionAttribute>()
                                         ?.Description ?? type.ToString();

                enumItems.Add(new EnumItem
                {
                    Name = description,
                    Value = type
                });
            }

            InspectionTypes = new ObservableCollection<EnumItem>(enumItems);
            SelectedInspectionType = InspectionTypes.First(); // Default: All Types

        }

    }
}
