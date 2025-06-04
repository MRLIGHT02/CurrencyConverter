using CurrencyConverter.Service;

namespace CurrencyConverter
{
    public partial class MainPage : ContentPage
    {
        private readonly Exchange _exchange;

        public MainPage(Exchange exchange)
        {
            InitializeComponent();
            _exchange = exchange;
        }


    }
}
