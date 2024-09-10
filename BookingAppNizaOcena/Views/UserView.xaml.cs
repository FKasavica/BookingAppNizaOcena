using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Repository;
using BookingAppNizaOcena.ViewModels;
using System.Windows;

namespace BookingAppNizaOcena.Views
{
    public partial class UserView : Window
    {
        public UserView()
        {
            InitializeComponent();
            DataContext = new UserViewModel(new UserService(new UserRepository()));
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((UserViewModel)DataContext).Password = PasswordBox.Password;
            }
        }
    }
}
