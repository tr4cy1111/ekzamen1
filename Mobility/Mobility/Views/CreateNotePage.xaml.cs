using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using Mobility.DB;

namespace Mobility.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNotePage : ContentPage
    {
        public CreateNotePage()
        {
            InitializeComponent();
        }
        private void ESumm_TextChanged(object sender, TextChangedEventArgs e)
        {
            var nums = new Regex(@"[0-9]");
        }

        protected override void OnAppearing()
        {
            PNoteType.ItemsSource = App.Db.GetNoteTypes().ToList();
            PExpenseType.ItemsSource = App.Db.GetExpenseTypes().ToList();
            base.OnAppearing();
        }

        private async void BtnAddNote_Clicked(object sender, EventArgs e)
        {
            Money money = new Money()
            {
                NoteTypeId = (PNoteType.SelectedIndex + 1),
                ExpenseTypeId = (PExpenseType.SelectedIndex + 1),
                Sum = double.Parse(ESumm.Text),
                Date = dp_date.Date,
                Description = e_description.Text,
                UserId = BD.currentUser.UserId
            };
            App.Db.SaveMoney(money);
            await Shell.Current.GoToAsync($"//{nameof(Views.NotePage)}");
        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Views.NotePage)}");
        }
    }
}