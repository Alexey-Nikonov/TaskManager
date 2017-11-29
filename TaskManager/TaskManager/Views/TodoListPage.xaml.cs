using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        public TodoListViewModel TodoListViewModel { get; private set; }

        public TodoListPage()
        {            
            InitializeComponent();

            TodoListViewModel = new TodoListViewModel() { Navigation = this.Navigation };            

            this.BindingContext = TodoListViewModel;
        }

        protected override async void OnAppearing()
        {
            await TodoListViewModel.GetTodoItems();            

            base.OnAppearing();
        }
    }
}