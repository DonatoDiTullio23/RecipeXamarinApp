using MyRecipeBook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRecipeBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public async Task<List<Recipe>> GetRecipesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                //Locally get the recipes from API
                var response = await httpClient.GetStringAsync("http://10.0.2.2:5000/recipes");

                return JsonConvert.DeserializeObject<List<Recipe>>(response);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            RecipesListView.ItemsSource = await GetRecipesAsync();
        }


        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());

        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchResultPage());
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Recipe selectedRecipe)
            {
                Navigation.PushAsync(new RecipeDetailPage(selectedRecipe));
                ((ListView)sender).SelectedItem = null;
            }
        }

    }


}