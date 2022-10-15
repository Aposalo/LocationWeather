using System.Threading.Tasks;
using LocationWeather.Models;
using LocationWeather.Repositories;
using Xamarin.Forms;

namespace LocationWeather.Pages.MainPage {
    
    public class MainPageContent : ContentPage {

        private readonly OpenWeatherMapModel _model = new OpenWeatherMapModel();
        private readonly Entry _entryLocation;
        
        private RootObject _weatherInfo;
        private Frame _mainPageContent;

        public MainPageContent() {
            _entryLocation = new Entry {
                BackgroundColor = Color.ForestGreen,
                TextColor = Color.LimeGreen,
                Placeholder = "Please enter a city",
            };
            InitializeComponent();
        }

        private void InitializeComponent() {
            _mainPageContent = MainPageContentFrame.GetMainPageContent(_entryLocation.Text, _weatherInfo);
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
                                    _entryLocation,
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
                        _mainPageContent
                    }
                }
            };
        }

        public void GetWeatherInfo() 
        {
            _weatherInfo = _model.GetWeatherInfo(_entryLocation.Text);
        }

        private async void OnButtonClickedAsync() {
            if (!string.IsNullOrEmpty(_entryLocation.Text)) {
                _mainPageContent = MainPageContentFrame.GetActivityIndicatorMainPageContent();
                InitializeContent();
                Task GetInfoThread = new Task(GetWeatherInfo);
                GetInfoThread.Start();
                await Task.WhenAll(GetInfoThread);
            }
            InitializeComponent();
        }
    
    }
}