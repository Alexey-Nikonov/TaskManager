using System;
using System.Windows.Input;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TaskManager.Models;

namespace TaskManager.ViewComponents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClockView : ContentView
    {
        public ClockView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ClockItemsProperty =
            BindableProperty.Create("ClockItems",
                typeof(ObservableCollection<ClockItem>),
                typeof(ClockView),
                null,
                propertyChanged: OnClockItemsChanged);

        public ObservableCollection<ClockItem> ClockItems
        {
            set { SetValue(ClockItemsProperty, value); }
            get { return (ObservableCollection<ClockItem>)GetValue(ClockItemsProperty); }
        }

        private string innerText;

        public string InnerText
        {
            get { return innerText; }
            set
            {
                innerText = value;

                OnPropertyChanged(nameof(InnerText));
            }
        }

        // добавление кругов
        private static void OnClockItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var clockView = bindable as ClockView;

            if (newValue != null && clockView != null)
            {
                StackLayout stackLayout = clockView.Children[0] as StackLayout;
                Frame frame = stackLayout?.Children[0] as Frame;

                if (stackLayout != null && frame != null)
                {
                    AbsoluteLayout absoluteLayout = new AbsoluteLayout();

                    foreach (ClockItem clockItem in clockView.ClockItems)
                    {
                        CircleView circleView = new CircleView()
                        {
                            FillColor = (Color)Application.Current.Resources["Alizarin"],
                            Radius = 20,
                            InnerTextSize = 20,
                            InnerText = clockItem.InnerText,
                            InnerTextColor = (Color)Application.Current.Resources["Clouds"]
                        };
                                                
                        circleView.SetBinding(CircleView.TapCommandProperty, new Binding("OnClockItemClicked", source: clockView));
                        
                        double x = .5 + .5 * Math.Cos(clockItem.Angle);
                        double y = .5 + .5 * Math.Sin(clockItem.Angle);

                        AbsoluteLayout.SetLayoutBounds(circleView, new Rectangle(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                        AbsoluteLayout.SetLayoutFlags(circleView, AbsoluteLayoutFlags.PositionProportional);
                        absoluteLayout.Children.Add(circleView);
                    }
                    
                    var innerLabel = new Label
                    {
                        Text = clockView.InnerText,
                        FontSize = 30
                    };

                    AbsoluteLayout.SetLayoutBounds(innerLabel, new Rectangle(.5, .5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                    AbsoluteLayout.SetLayoutFlags(innerLabel, AbsoluteLayoutFlags.PositionProportional);
                    absoluteLayout.Children.Add(innerLabel);

                    frame.Content = absoluteLayout;
                }
            }
        }

        public static readonly BindableProperty OnClockItemClickedProperty =
          BindableProperty.Create("OnClockItemClicked",
            typeof(ICommand),
            typeof(ClockView),
            null);

        public ICommand OnClockItemClicked
        {
            get { return (ICommand)GetValue(OnClockItemClickedProperty); }
            set { SetValue(OnClockItemClickedProperty, value); }
        }
    }
}