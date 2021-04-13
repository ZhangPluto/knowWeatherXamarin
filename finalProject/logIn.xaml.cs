//
// logIn.xaml.cs
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
using Firebase.Auth;
using Xamarin.Forms;
using finalProject.model;
namespace finalProject
{
    public partial class logIn : ContentPage
    {
        public string webApiKey = "AIzaSyD5u9VUSb1w5Df9xsXt63lU3K-xtY46fGY";
        public logIn()
        {
            InitializeComponent();
        }



        async void logInButton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email.Text, password.Text);
                await DisplayAlert("Welcome!", "Welcome to knowWeather!", "OK");
                allAccess.isLogIn = true;
                await Navigation.PushModalAsync(new MainPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild to log in", ex.Message.ToString(), "OK");
            }
        }
        async void backButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        async void signInButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SignIn());
        }
    }
}
