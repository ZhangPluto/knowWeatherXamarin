using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using finalProject.model;
using Newtonsoft.Json;
using System.Net.Http;
using Plugin.Geolocator.Abstractions;
using Plugin.Geolocator;
using System.Diagnostics;
using Xamarin.Forms.Xaml;

namespace finalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        FirebaseHealper firebase = new FirebaseHealper();
        public MainPage()
        {
            InitializeComponent();
            goToCityList.IsVisible = false;
            logOut.IsVisible = false;
            if(allAccess.isFirstIn == true)
            {
                DisplayAlert("Waring", "Please use iPhone 12 mini for the best experience", "OK");
            }
            allAccess.isFirstIn = false;
            GetWeatherWithCoord();

        }

        private async void GetWeatherWithCoord()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            string url = "https://api.openweathermap.org/data/2.5/weather?lat=" + position.Latitude + "&lon=" + position.Longitude + "&appid=055431410a903050bfa6e6052c9f1cf7";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);
                    var weather = JsonConvert.DeserializeObject<MainWeather>(response);
                    maxTemp.Text = (Convert.ToInt32(weather.MainInfos.TempMax - 273.65)).ToString();
                    minTemp.Text = (Convert.ToInt32(weather.MainInfos.TempMin - 273.65)).ToString();
                    currentTemp.Text = (Convert.ToInt32(weather.MainInfos.Temp - 273.65)).ToString();
                    fellTemp.Text = (Convert.ToInt32(weather.MainInfos.FeelsLike - 273.65)).ToString();
                    currentWeather.Text = weather.Weathers[0].Description;
                    Location.Text = weather.Name;
                    GetTime(weather.DateTime);

                }

            }
            catch (HttpRequestException)
            {
                //await DisplayAlert("Error", e1.Message.ToString(), "Ok");
                await DisplayAlert("Error", "City not Found!", "Ok");

            }

        }

        private async void IfAlreadyMarked(string city)
        {
            var findCity = await firebase.ReadCities(city);
            if(findCity != null)
            {
                likeCity.Text = "Delete the mark";
            }
            if(findCity == null)
            {
                likeCity.Text = "Mark this city";
            }
        }


        private async void GetWeatherWithCityName(string cityName)
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q="+ cityName +"&appid=055431410a903050bfa6e6052c9f1cf7";
            try
            {
                
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);
                    var weather = JsonConvert.DeserializeObject<MainWeather>(response);
                    maxTemp.Text = (Convert.ToInt32(weather.MainInfos.TempMax - 273.65)).ToString();
                    minTemp.Text = (Convert.ToInt32(weather.MainInfos.TempMin - 273.65)).ToString();
                    currentTemp.Text = (Convert.ToInt32(weather.MainInfos.Temp - 273.65)).ToString();
                    fellTemp.Text = (Convert.ToInt32(weather.MainInfos.FeelsLike - 273.65)).ToString();
                    currentWeather.Text = weather.Weathers[0].Description;
                    Location.Text = weather.Name;
                    GetTime(weather.DateTime);

                }

            }catch(HttpRequestException)
            {
                //await DisplayAlert("Error", e1.Message.ToString(), "Ok");
                await DisplayAlert("Error", "City not Found!", "Ok");

            }

        }

        private void GetTime(long timeStramp)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            DateTime dt = startTime.AddSeconds(timeStramp);
            currentDate.Text = dt.ToString("yyyy/MM/dd");
        }

        void searchCityButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var city = cityName.Text;
            GetWeatherWithCityName(city);
            if(allAccess.isLogIn == true)
            {
                IfAlreadyMarked(cityName.Text);
            }

        }

        async void logIn_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new logIn());
        }


        async void goToCityList_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new listOfCity());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (allAccess.isLogIn == true)
            {
                logIn.IsVisible = false;
                goToCityList.IsVisible = true;
                logOut.IsVisible = true;
            }
            if (allAccess.isListNav == true)
            {
                GetWeatherWithCityName(allAccess.nowSelecting);
                allAccess.isListNav = false;
                allAccess.nowSelecting = "";
                likeCity.Text = "Delete the mark";

            }
            IfAlreadyMarked(Location.Text);
        }

        async void logOut_Clicked(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Bye!", "Thank you for using knowWeather APP!", "Ok");
            logIn.IsVisible = true;
            goToCityList.IsVisible = false;
            allAccess.isLogIn = false;
            logOut.IsVisible = false;
            cityName.Text = "";
            likeCity.Text = "Mark this city!";
        }

        void reload_Clicked(System.Object sender, System.EventArgs e)
        {
            GetWeatherWithCoord();
            cityName.Text = "";
        }

        async void likeCity_Clicked(System.Object sender, System.EventArgs e)
        {
            if (allAccess.isLogIn == false)
            {
                await DisplayAlert("Error!", "You have to log in if you want to mark a city!", "Ok");
            }
            else
            {
                if (likeCity.Text == "Delete the mark")
                {
                    try
                    {
                        await firebase.deleteCities(Location.Text);
                        await DisplayAlert("Deleted!", "This city has been deleted from your bookmark list!", "Ok");
                        likeCity.Text = "Mark this city!";
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error", ex.Message.ToString(), "OK");
                    }
                }
                else
                {
                    try
                    {
                        await firebase.AddCitys(Location.Text);
                        await DisplayAlert("Added!", "This city has been added to your bookmark list!", "Ok");
                        likeCity.Text = "Delete the mark";
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error", ex.Message.ToString(), "OK");
                    }
                }

                
            }


        }
    }
}
