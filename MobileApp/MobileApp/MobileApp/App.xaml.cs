using MobileTodoApp;
using MobileTodoApp.Persistence;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    public partial class App : Application
    {
        public static TodoRepository TodoRepository = new TodoRepository();
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TodoListView());
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
