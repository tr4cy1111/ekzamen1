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
    public partial class EditNotePage : ContentPage
    {
        private static DB.Money currentMoney;
        public EditNotePage(DB.Money money)
        {
            InitializeComponent();
            currentMoney = money;
            BindingContext = currentMoney;
            NoteTypes.SelectedItem = App.Db.GetNoteType(money.NoteTypeId);
            ExpenseTypes.SelectedItem = App.Db.GetExpenseType(money.ExpenseTypeId);
            ESumm.Text = currentMoney.Sum.ToString();
            Description.Text = currentMoney.Description.ToString();
        }

        private async void Deleted_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert(" ", $"Вы хотите удалить данные?", "Да", "Отмена"))
            {
                App.Db.DeleteMoney(currentMoney.Id);
                await Shell.Current.GoToAsync($"//{nameof(Views.NotePage)}");
            }
        }
        protected override void OnAppearing()
        {
            NoteTypes.ItemsSource = App.Db.GetNoteTypes().ToList();
            ExpenseTypes.ItemsSource = App.Db.GetExpenseTypes().ToList();
            base.OnAppearing();
        }
        private async void BtnAddNote_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (await DisplayAlert(" ", $"Вы хотите изменить данные?", "Да", "Отмена"))
                {
                    App.Db.EditMoney(currentMoney, NoteTypes.SelectedIndex + 1, ExpenseTypes.SelectedIndex + 1, Convert.ToDouble(ESumm.Text), Description.Text, BD.currentUser.UserId);
                    await Shell.Current.GoToAsync($"//{nameof(Views.NotePage)}");
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private async void BtnBack_Clicked_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Views.NotePage)}");
        }
    }
}