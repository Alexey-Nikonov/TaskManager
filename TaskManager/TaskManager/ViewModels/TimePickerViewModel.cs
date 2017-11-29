using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

using TaskManager.Enums;
using TaskManager.Models;
using TaskManager.Providers;

namespace TaskManager.ViewModels
{
    public class TimePickerViewModel : INotifyPropertyChanged
    {
        private readonly IClockItemRepository repository;
        public TodoItemViewModel TodoItemViewModel { get; set; }
        public TodoListViewModel TodoListViewModel { get; set; }

        public ICommand SetTimesOfDayCommand { get; set; }
        public ICommand SetHoursCommand { get; set; }
        public ICommand SetMinsCommand { get; set; }
        public ICommand SetTimeCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                if (time != value)
                {
                    time = value;

                    OnPropertyChanged(nameof(Time));
                }
            }
        }

        private ObservableCollection<ClockItem> pmHours;
        private ObservableCollection<ClockItem> amHours;

        private ObservableCollection<ClockItem> hours;
        public ObservableCollection<ClockItem> Hours
        {
            get { return hours; }
            set
            {
                if (hours != value)
                {
                    hours = value;
                    OnPropertyChanged("Hours");
                }
            }
        }

        private ObservableCollection<ClockItem> mins;
        public ObservableCollection<ClockItem> Mins
        {
            get { return mins; }
            set
            {
                if (mins != value)
                {
                    mins = value;
                    OnPropertyChanged("Mins");
                }
            }
        }
        
        public TimePickerViewModel()
        {
            repository = (IClockItemRepository)App.UnitOfWork.GetRepository<ClockItem>();     

            SetTimesOfDayCommand = new Command(SetTimesOfDay);
            SetHoursCommand = new Command(SetHours);
            SetMinsCommand = new Command(SetMins);
            SetTimeCommand = new Command(SetTime);
            GoBackCommand = new Command(GoBack);
        }

        private void SetTimesOfDay(object timesOfDayValue)
        {
            TimeUnits timesOfDay = (TimeUnits)Enum.Parse(typeof(TimeUnits), timesOfDayValue.ToString());
            Hours = timesOfDay == TimeUnits.AM ? amHours : pmHours;
        }

        private void SetHours(object timeValue)
        {
            int hours = Convert.ToInt32(timeValue);
            this.Time = new TimeSpan(hours, this.Time.Minutes, this.Time.Seconds);
        }

        private void SetMins(object timeValue)
        {
            int mins = Convert.ToInt32(timeValue);
            this.Time = new TimeSpan(this.Time.Hours, mins, this.Time.Seconds);
        }

        private async void SetTime()
        {
            this.TodoItemViewModel.Time = this.Time;

            await PopModal();
        }

        private async void GoBack()
        {
            await PopModal();
        }

        private async Task PopModal()
        {
            await Navigation.PopModalAsync();         
        }

        public async Task GetClockItems()
        {
            await Task.Factory.StartNew(() =>
            {
                Hours = amHours = new ObservableCollection<ClockItem>(repository.GetAMItemsAsync());
                pmHours = new ObservableCollection<ClockItem>(repository.GetPMItemsAsync());
                Mins = new ObservableCollection<ClockItem>(repository.GetMinsItemsAsync());
            });
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
