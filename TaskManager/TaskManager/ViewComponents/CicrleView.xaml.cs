using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.ViewComponents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CircleView : ContentView
    {
        public double CircleWidth { get; set; }
        public double CircleHeight { get; set; }

        private double radius;
        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;

                OnPropertyChanged(nameof(Radius));
                this.CircleHeight = this.CircleWidth = value * 2;
            }
        }

        private Color fillColor;
        public Color FillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;

                OnPropertyChanged(nameof(FillColor));
            }
        }

        private Color innerTextColor;
        public Color InnerTextColor
        {
            get { return innerTextColor; }
            set
            {
                innerTextColor = value;

                OnPropertyChanged(nameof(InnerTextColor));
            }
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

        private int innerTextSize;
        public int InnerTextSize
        {
            get { return innerTextSize; }
            set
            {
                innerTextSize = value;

                OnPropertyChanged(nameof(InnerTextSize));
            }
        }
        
        public static readonly BindableProperty TapCommandProperty =
          BindableProperty.Create("TapCommand",
            typeof(ICommand),
            typeof(CircleView),
            null);

        public ICommand TapCommand
        {
            get { return (ICommand)GetValue(TapCommandProperty); }
            set { SetValue(TapCommandProperty, value); }
        }

        public CircleView()
        {
            InitializeComponent();
        }
    }
}