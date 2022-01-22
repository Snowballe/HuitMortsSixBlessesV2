using System.Diagnostics;
using System.Windows;

namespace HuitMortsSixBlesses.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Ca serait mieux de mettre l'URL dans un fichier de config plutôt qu'en dur ici
            
            //var clientApi = new Client("https://localhost:44319/", new HttpClient());

            //le async et le await c'est de la programmation asynchrone en C#
            
            //var triangles = await clientApi.PanierAdhAllAsync();

            
        }

        private void BtnSignin(object sender, RoutedEventArgs e)
        {

        }

        private void BtnToWebsite(object sender,RoutedEventArgs e)
        {
            string url = "https://www.google.com";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
    }
}
