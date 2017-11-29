using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

using Xamarin.Forms;

using TaskManager.Views;
using TaskManager.Providers;

namespace TaskManager
{
    public partial class App : Application
    {
        public const string DB_NAME = "TaskManagerDB.db";
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TodoListPage());
        }

        private static IUnitOfWork unitOfWork;
        public static IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    string dataBasePath = DependencyService.Get<ISQLite>().GetDatabasePath(DB_NAME);
                    SQLiteAsyncConnection context = new SQLiteAsyncConnection(dataBasePath);
                    unitOfWork = new UnitOfWork(context);
                }

                return unitOfWork;
            }
        }        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
