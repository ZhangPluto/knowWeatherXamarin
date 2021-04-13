//
// listOfCity.xaml.cs
//
// Author:
//       renhaozhang <lionelzhang99@gmail.com>
//
// Copyright (c) 2021 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using finalProject.model;

using Xamarin.Forms;

namespace finalProject
{
    public partial class listOfCity : ContentPage
    {
        FirebaseHealper firebase = new FirebaseHealper();
        public listOfCity()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            fillListView();
        }

        private async void fillListView()
        {
            var allCities = await firebase.GetAllCity();
            cityListView.ItemsSource = allCities;
        }

        void cityListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = (City)e.SelectedItem;
            allAccess.nowSelecting = item.CityName;
            allAccess.isListNav = true;
            Navigation.PushModalAsync(new MainPage());
        
        }

        async void goToMainPage_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}
