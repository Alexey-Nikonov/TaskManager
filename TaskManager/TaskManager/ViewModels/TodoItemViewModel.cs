using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

using TaskManager.Models;
using TaskManager.Views;

namespace TaskManager.ViewModels
{
    public class TodoItemViewModel : INotifyPropertyChanged
    {
        public TodoListViewModel TodoListViewModel { get; set; }
        public TodoItem TodoItem { get; set; }
        public bool IsAdding { get; set; }

        public ICommand SaveCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }
        public ICommand PickTimeCommand { get; protected set; }

        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public TodoItemViewModel()
        {
            TodoItem = new TodoItem();

            SaveCommand = new Command(Save);
            CancelCommand = new Command(Cancel);
            PickTimeCommand = new Command(PickTime);
        }

        public int Id
        {
            get { return TodoItem.Id; }
            set
            {
                if (TodoItem.Id != value)
                {
                    TodoItem.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get { return TodoItem.Name; }
            set
            {
                if (TodoItem.Name != value)
                {
                    TodoItem.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get { return TodoItem.Description; }
            set
            {
                if (TodoItem.Description != value)
                {
                    TodoItem.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public DateTime Date
        {
            get { return TodoItem.Date; }
            set
            {
                if (TodoItem.Date != value)
                {
                    TodoItem.Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public TimeSpan Time
        {
            get { return TodoItem.Time; }
            set
            {
                if (TodoItem.Time != value)
                {
                    TodoItem.Time = value;
                    OnPropertyChanged("Time");
                }
            }
        }
        
        public string Title
        {
            get { return IsAdding ? "Addition" : "Editing"; }
        }

        public string SaveButtonTitle
        {
            get { return IsAdding ? "Add" : "Save"; }
        }

        public bool IsValid
        {
            get
            {
                return (!String.IsNullOrEmpty(Name?.Trim())) && (!String.IsNullOrEmpty(Description?.Trim()));
            }
        }

        private async void Save()
        {
            if (IsValid)
            {
                if (IsAdding)
                {
                    TodoListViewModel.AddItemCommand.Execute(this.TodoItem);
                        
                    IsAdding = false;
                }
                else
                {
                    TodoListViewModel.UpdateItemCommand.Execute(this.TodoItem);
                }

                await GoBack();
            }
        }

        private async void Cancel()
        {
            await GoBack();
        }

        private async Task GoBack()
        {
            await Navigation.PopAsync();
        }

        private async void PickTime()
        {
            await Navigation.PushModalAsync(new TimePickerPage(this, TodoListViewModel));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
