using CurrencyConverter.Service;

using System.Reflection;
namespace CurrencyConverter
{
    public partial class MainPage : ContentPage
    {
        private readonly Exchange _exchange;

        public MainPage(Exchange exchange)
        {
            InitializeComponent();
            _exchange = exchange;

            var currencyNames = typeof(ConversionRates)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Select(p => p.Name)
                        .ToList();

            fromCurrencyPicker.ItemsSource = currencyNames;

            toCurrencyPicker.ItemsSource = currencyNames;
        }

        private async void btnConvert_Clicked(object sender, EventArgs e)
        {
            string fromCurrency = fromCurrencyPicker.SelectedItem?.ToString();
            string toCurrency = toCurrencyPicker.SelectedItem?.ToString();

            if (fromCurrency == null || toCurrency == null)

            {

                await DisplayAlert("Error", "Please select both currencies.", "OK");

                if (fromCurrency == toCurrency)
                {
                    await DisplayAlert("Currency Is Same", "Change Currency ", "ok");
                }

                return;

            }

            var exchangeKey = await _exchange.CurrencyConvert(fromCurrency, toCurrency);

            if (exchangeKey != null && exchangeKey.result == "success")
            {
                int amount = Convert.ToInt32(amountEntry.Text);
                resultLabel.Text = $"{exchangeKey.conversion_rate * amount}";
            }
            else
            {
                resultLabel.Text = "Conversion failed.";
            }




        }
    }
}
