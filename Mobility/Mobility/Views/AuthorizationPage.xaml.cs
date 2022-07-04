using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobility.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private async void BtnReg_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Views.RegistrationPage)}");
        }

        private async void regAuth_Clicked(object sender, EventArgs e)
        {
            var user = App.Db.GetUser(login.Text, pass1.Text);
            if (user != null)
            {
                BD.currentUser.UserId = user.Id;
                await Shell.Current.GoToAsync($"//{nameof(Views.NotePage)}");
            }
            else
            {
                await DisplayAlert("Ошибка авторизации", "Неверный логин или пароль", "Закрыть");
            }
            
        }

        private void firstEye_Clicked(object sender, EventArgs e)
        {
            pass1.IsPassword = !pass1.IsPassword;
        }
    }
}