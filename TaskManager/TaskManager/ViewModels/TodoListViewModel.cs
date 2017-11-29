using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

using TaskManager.Views;
using TaskManager.Models;
using TaskManager.Providers;

namespace TaskManager.ViewModels
{
    public class TodoListViewModel : INotifyPropertyChanged
    {
        private readonly ITodoItemRepository repository;
        public ObservableCollection<TodoItem> TodoItems { get; private set; }
        private bool initialized;

        public ICommand CreateItemCommand { get; protected set; }
        public ICommand AddItemCommand { get; protected set; }
        public ICommand DeleteItemCommand { get; protected set; }        
        public ICommand UpdateItemCommand { get; protected set; }

        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public TodoListViewModel()
        {
            repository = (ITodoItemRepository)App.UnitOfWork.GetRepository<TodoItem>();
            TodoItems = new ObservableCollection<TodoItem>();

            CreateItemCommand = new Command(CreateItem);
            DeleteItemCommand = new Command(DeleteItem);
            AddItemCommand = new Command(AddItem);
            UpdateItemCommand = new Command(UpdateItem);
        }

        private TodoItem selectedItem;
        public TodoItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = null;
                    OnPropertyChanged("SelectedItem");
                    Navigation.PushAsync(new TodoItemPage(value, this));
                }
            }
        }

        private async void CreateItem()
        {
            await Navigation.PushAsync(new TodoItemPage(this));
        }        

        private async void DeleteItem(object id)
        {
            int deletedId = Convert.ToInt32(id);

            TodoItem todoItem = TodoItems.SingleOrDefault(x => x.Id == deletedId);

            if (todoItem != null)
            {
                await repository.RemoveAsync(todoItem);
                TodoItems.Remove(todoItem);
            }
        }

        private async void AddItem(object todoItemValue)
        {
            TodoItem todoItem = todoItemValue as TodoItem;
            
            if (todoItem != null)
            {
                await repository.AddAsync(todoItem);
                TodoItems.Add(todoItem);
            }            
        }

        private async void UpdateItem(object todoItemValue)
        {
            TodoItem todoItem = todoItemValue as TodoItem;

            if (todoItem != null)
            {
                await repository.UpdateAsync(todoItem);
                
                int pos = TodoItems.IndexOf(TodoItems.Where(x => x.Id == todoItem.Id).SingleOrDefault());
                TodoItems.RemoveAt(pos);
                TodoItems.Insert(pos, todoItem);
            }
        }

        public async Task GetTodoItems()
        {
            if (initialized) return;

            IEnumerable<TodoItem> todoItems = await repository.GetAllAsync();

            foreach (TodoItem item in todoItems)
            {
                TodoItems.Add(item);
            }

            initialized = true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
