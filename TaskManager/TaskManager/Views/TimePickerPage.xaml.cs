using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TaskManager.ViewModels;

namespace TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimePickerPage : ContentPage
    {
        public TimePickerViewModel TimePickerViewModel { get; private set; }
        
        public TimePickerPage(TodoItemViewModel todoItemViewModel, TodoListViewModel todoListViewModel)
        {
            InitializeComponent();
            
            TimePickerViewModel = new TimePickerViewModel()
            {
                TodoItemViewModel = todoItemViewModel,
                TodoListViewModel = todoListViewModel,
                Navigation = this.Navigation,
                Time = todoItemViewModel.Time
            };

            this.BindingContext = TimePickerViewModel;
        }

        protected override async void OnAppearing()
        {
            await TimePickerViewModel.GetClockItems();

            base.OnAppearing();
        }
    }
}