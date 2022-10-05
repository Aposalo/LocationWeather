using LocationWeather.Pages.MainPageContent;
using OpenWeatherMap.Model;
using OpenWeatherMap.repository;
using Xamarin.Forms;

namespace LocationWeather
{
    public class MainPage : ContentPage {

        private OpenWeatherMapModel model = new OpenWeatherMapModel(new OpenWeatherMapRepository());
        private Entry entryLocation;

        public MainPage() {
            entryLocation = new Entry {
                BackgroundColor = Color.ForestGreen,
                TextColor = Color.LimeGreen,
                Placeholder = "Please enter a city",
            };
            InitializeComponent("");
        }

        private void InitializeComponent(string location) {
            var weatherInfo = model.GetWeatherInfo(location);
            var formattedString = MainPageFormattedStrings.GetMainPageContent(location, weatherInfo);

            Content = new ScrollView{ 
                Content = new StackLayout {
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
                                                    Command = new Command(OnButtonClicked),
                                                    HorizontalOptions = LayoutOptions.Center
                                                }
                                            }
                                        }
                                    },
                        new Label {
                                        BackgroundColor = Color.ForestGreen,
                                        FontSize = 18,
                                        Margin = new Thickness(10, 10, 10, 10),
                                        FormattedText = formattedString
                                    }
                    }
                } 
            };
        }

        private void OnButtonClicked(object sender) {
            model = new OpenWeatherMapModel(new OpenWeatherMapRepository());
            InitializeComponent(entryLocation.Text);
        }
    }
}