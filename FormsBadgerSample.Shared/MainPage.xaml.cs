using System.Windows.Input;
using Xam.Plugin.Badger.Abstractions;
using Xamarin.Forms;

namespace FormsSample.Shared
{
    public partial class MainPage : ContentPage
    {
        IBadgerService _badgeService;
        public MainPage()
        {
            _badgeService = DependencyService.Get<IBadgerService>();
            InitializeComponent();
            BindingContext = this;
        }

        string badgeValue = "";
        public string BadgeValue
        {
            get
            {
                return badgeValue;
            }
            set
            {
                var isInt = int.TryParse(value, out var parsed);
                if (isInt)
                    badgeValue = value;
                OnPropertyChanged(nameof(BadgeValue));
            }
        }

        public ICommand IncrementCommand
            => new Command(() => _badgeService.Increment());

        public ICommand DecrementCommand
            => new Command(() => _badgeService.Decrement());

        public ICommand ResetBadgeCommand
            => new Command(() => _badgeService.Reset());

        public ICommand SetBadgeCountCommand
            => new Command<string>((count) => _badgeService.SetCount(int.Parse(count)));
    }
}
