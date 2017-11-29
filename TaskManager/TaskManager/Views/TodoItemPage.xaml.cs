using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemPage : ContentPage
    {
        private TodoItemViewModel TodoItemViewModel { get; set; }

        public TodoItemPage(TodoListViewModel lvm) : this(null, lvm) { }

        public TodoItemPage(TodoItem todoItem, TodoListViewModel lvm)
        {
            InitializeComponent();
            
            this.TodoItemViewModel = new TodoItemViewModel
            {
                Navigation = this.Navigation,
                TodoListViewModel = lvm
            };

            // addition
            if (todoItem == null)
            {
                this.TodoItemViewModel.IsAdding = true;
            }
            // editing
            else
            {
                this.TodoItemViewModel.TodoItem =        todoItem.ShallowCopy();
                this.TodoItemViewModel.Id =              todoItem.Id;
                this.TodoItemViewModel.Name =            todoItem.Name;
                this.TodoItemViewModel.Description =     todoItem.Description;
                this.TodoItemViewModel.Date =            todoItem.Date;
                this.TodoItemViewModel.Time =            todoItem.Time;
            }            

            this.BindingContext = this.TodoItemViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SetPageTitles();
        }

        private void SetPageTitles()
        {
            this.Title = this.TodoItemViewModel.Title;
            this.saveButton.Text = this.TodoItemViewModel.SaveButtonTitle;
        }
    }
}