using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobility.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void regBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var SearchUser = App.Db.SearchUser(login.Text);
                var SearchEmail = App.Db.SearchEmail(Email.Text);
                if (SearchEmail == null && SearchUser == null)
                {
                    if (pass1.Text == pass2.Text)
                    {
                        DB.User user = new DB.User()
                        {
                            Login = login.Text,
                            Password = pass1.Text,
                            EMail = Email.Text
                        };
                        App.Db.SaveUser(user);
                        await Shell.Current.GoToAsync($"//{nameof(Views.AuthorizationPage)}");
                    }
                    else
                    {
                        await DisplayAlert("Пароли не совпадают", $"Пароли должны совпадать", "ok");
                    }
                }
                else
                {
                    await DisplayAlert("такие данные уже есть", "логин или почта занята", "ok");
                }

            }
            catch (Exception)
            {
                await DisplayAlert("не правильные данные", "ошибка авторизации", "ok");
            }
        }
        
        private async void BtnClose_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Views.AuthorizationPage)}");
        }

        private void firstEye_Clicked(object sender, EventArgs e)
        {
            pass1.IsPassword = !pass1.IsPassword;
        }

        private void secondEye_Clicked(object sender, EventArgs e)
        {
            pass2.IsPassword = !pass2.IsPassword;
        }
    }
}