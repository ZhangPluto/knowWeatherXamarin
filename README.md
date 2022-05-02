# A weather application based on Xamarin hybrid programming

## Introduction
- API: openmapweather.
- Database: Firebase (Use email and password to log in, Mark city)
- [Download resourse](https://github.com/ZhangPluto/xamarinWeatherApplication.git)
- The project can display the time, name, temperature, visibility and other information of the current location in real time, while the project allows you to check the weather information of other cities, you can also add your frequently visited cities in the favorites list for quick viewing.

## Set up
- You need to go to this website to register and use your own API: [Click here to register](https://openweathermap.org/)
- Please change the address of your API in `Main/FinalProject/MainPage.xaml.cs` on line 41
- You need to register a new personal project here [Link](https://console.firebase.google.com/u/0/) and open the authentication function and database function, the database contains a field: Collection_City
- Starting a project with Visual Studio
