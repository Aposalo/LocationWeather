using LocationWeather.Pages.MainPageContent;
using LocationWeather.Repositories;
using LocationWeather.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocationWeather
{

    public class MainPage : ContentPage {

        private OpenWeatherMapModel model = new OpenWeatherMapModel();
        private RootObject weatherInfo;
        private Entry entryLocation;
        private Frame mainPageContent;

        public MainPage() {
            entryLocation = new Entry {
                BackgroundColor = Color.ForestGreen,
                TextColor = Color.LimeGreen,
                Placeholder = "Please enter a city",
            };
            InitializeComponent();
        }

        private void InitializeComponent() {
            mainPageContent = MainPageContentFrame.GetMainPageContent(entryLocation.Text, weatherInfo);
            InitializeContent();
        }

        private void InitializeContent() {
            Content = new ScrollView {
                Content =
                new StackLayout {
                    BackgroundColor = Color.DarkGreen,
                    Children = {
                        new Frame {
                            Content = new Label {
                                Text = "Open Weather Map",
                                HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = 22,
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Color.LightGreen
                            },
                            BackgroundColor = Color.ForestGreen,
                        },
                        new Frame {
                            BackgroundColor = Color.ForestGreen,
                            Content = new StackLayout {
                                BackgroundColor = Color.ForestGreen,
                                Children = {
                                    entryLocation,
                                    new Button {
                                        BackgroundColor = Color.DarkGreen,
                                        TextColor = Color.LimeGreen,
                                        Text = "Apply",
                                        Command = new Command(OnButtonClickedAsync),
                                        HorizontalOptions = LayoutOptions.Center
                                    }
                                }
                            }
                        },
                        mainPageContent
                    }
                }
            };
        }

        public void GetWeatherInfo() 
        {
            weatherInfo = model.GetWeatherInfo(entryLocation.Text);
        }

        private async void OnButtonClickedAsync() {
            if (!string.IsNullOrEmpty(entryLocation.Text)) {
                mainPageContent = MainPageContentFrame.GetActivityIndicatorMainPageContent();
                InitializeContent();
                Task GetInfoThread = new Task(GetWeatherInfo);
                GetInfoThread.Start();
                await Task.WhenAll(GetInfoThread);
            }
            InitializeComponent();
        }
    
    }
}