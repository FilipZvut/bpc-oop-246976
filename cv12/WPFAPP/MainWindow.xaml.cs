using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFAPP
{
    public partial class MainWindow : Window
    {
        private CalcObjekt calcObjekt;
        private const string BaseUrl = "https://localhost:7109";

        public MainWindow()
        {
            InitializeComponent();
            Vysledek.Text = "0";
        }

        private async void CalculateButton_click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal operand1 = decimal.Parse(Operand1.Text);
                decimal operand2 = decimal.Parse(Operand2.Text);
                string operace = (Operace.SelectedItem as ComboBoxItem).Content.ToString();
                calcObjekt = new CalcObjekt(operand1, operand2, operace);

                using (HttpClient client = new HttpClient())
                {
                    // Nastavení základní adresy API
                    client.BaseAddress = new Uri(BaseUrl);

                    // Odeslání POST požadavku na API
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/calc", calcObjekt);
                    response.EnsureSuccessStatusCode();

                    // Přečtení odpovědi jako text
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Zobrazení výsledku
                    Vysledek.Text = responseBody;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba: {ex.Message}");
            }
        }
    }
}
