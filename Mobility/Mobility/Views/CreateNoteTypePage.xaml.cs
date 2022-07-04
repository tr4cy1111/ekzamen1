using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mobility.DB;
using SQLite;

namespace Mobility.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNoteTypePage : ContentPage
    {
        NoteType NoteType;
        public CreateNoteTypePage()
        {
            InitializeComponent();
        }

        private async void addNoteTypeBtn_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Добавление", "Вы точно хотите создать категорию?", "Создать", "Отмена");
            if (answer)
            {
                NoteType = new NoteType();
                NoteType.Name = noteTypeName.Text;
                App.Db.SaveNoteType(NoteType);
                await Shell.Current.GoToAsync($"//{nameof(Views.NotePage)}");
            }

        }

        private async void cancelBtn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Views.NotePage)}");
        }
    }
}