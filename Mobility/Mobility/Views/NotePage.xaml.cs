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
    public partial class NotePage : ContentPage
    {
        public NotePage()
        {
            InitializeComponent();
        }

        private async void NewProject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateNotePage());
        }
        protected override void OnAppearing()
        {
            LVNote.ItemsSource = App.Db.GetMoneys().Where(u=>u.UserId == BD.currentUser.UserId);
            base.OnAppearing();
        }

        private async void LVNote_ItmSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DB.Money selectedNote = (DB.Money)e.SelectedItem;
            EditNotePage selectedNotePage = new EditNotePage(selectedNote);
            selectedNotePage.BindingContext = selectedNote;
            await Navigation.PushAsync(selectedNotePage);
        }
    }
}