using LocationWeather.Pages.MainPage;
using Xamarin.Forms;

namespace LocationWeather
{
    public partial class App
    {
        public App() {
            InitializeComponent();

            MainPage = new MainPageContent();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
