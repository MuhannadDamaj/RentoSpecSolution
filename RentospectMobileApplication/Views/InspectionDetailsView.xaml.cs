
using CommunityToolkit.Maui.Core;
using RentospectMobileApp.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RentospectMobileApp.Views
{
    public partial class InspectionDetailsView : ContentPage
    {
        
        public InspectionDetailsView(InspectionDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void SignaturePad_DrawingLineCompleted(object sender, CommunityToolkit.Maui.Core.DrawingLineCompletedEventArgs e)
        {
            if (BindingContext is InspectionDetailsViewModel vm)
            {
                // Initialize if null
                vm.SignatureLines ??= new ObservableCollection<IDrawingLine>();
                // Add each drawn line
                vm.SignatureLines.Add(e.LastDrawingLine);
            }
        }
    }
}
