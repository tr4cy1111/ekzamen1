using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobility.DB;
using System.IO;
using System.Linq;
using SQLite;

namespace Mobility
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Money.db";
        internal static Storage db;
        internal static Storage Db
        {
            get
            {
                if (db == null)
                {
                    db = new Storage(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            if (App.Db.GetExpenseTypes() == null || App.Db.GetExpenseTypes().Count() == 0)
            {
                ExpenseType expenseType1 = new ExpenseType()
                {
                    Name = "Доход",
                };

                ExpenseType expenseType2 = new ExpenseType()
                {
                    Name = "Расход",
                };

                App.Db.SaveExpenseType(expenseType1);
                App.Db.SaveExpenseType(expenseType2);
            }

            MainPage = new AppShell();


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}