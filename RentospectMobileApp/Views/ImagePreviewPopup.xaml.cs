using CommunityToolkit.Maui.Views;
using RentospectMobileApp.Entities;
using RentospectMobileApp.ViewModels;
using RentospectShared.CommonEnum;

namespace RentospectMobileApp.Views
{
    public partial class ImagePreviewPopup : Popup
    {
        public ImagePreviewPopup(ImageSource image)
        {
            InitializeComponent();
            PreviewImage.Source = image;
            Size = new Size(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density - 70, 450);
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            Close();
        }
    }
}
