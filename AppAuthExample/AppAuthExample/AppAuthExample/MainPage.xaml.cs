using System;
using Xamarin.Forms;

namespace AppAuthExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            var loginProvider = DependencyService.Get<ILoginProvider>();
            await loginProvider.LoginAsync();
        }
    }
}