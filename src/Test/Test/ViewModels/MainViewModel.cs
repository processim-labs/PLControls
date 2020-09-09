using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Test.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        public ICommand TapCommand => new Command(ShowPopup);

        private async void ShowPopup()
        {
            await App.Current.MainPage.DisplayAlert("What does it say?","Sweet", "OK");
        }
    }
}
