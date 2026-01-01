
using CommunityToolkit.Maui.Views;

namespace RentospectMobileApp.Views
{
    public partial class ChangePasswordPopup : Popup
    {
        public ChangePasswordPopup()
        {
            InitializeComponent();
        }
        private void OnCancelClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
