using MyRecipeBook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRecipeBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultPage : ContentPage
    {
        public ObservableCollection<Recipe> SearchResults { get; set; } = new ObservableCollection<Recipe>();

        public SearchResultPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            dishSearchBar.SearchButtonPressed += OnSearchButtonPressed;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            dishSearchBar.SearchButtonPressed -= OnSearchButtonPressed;
        }

        private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            
            string searchText = dishSearchBar.Text;
            await PerformSearch(searchText);
        }

        private async Task PerformSearch(string query)
        {
            var recipes = await FetchRecipesFromApi(query);

            SearchResults.Clear();
            foreach (var recipe in recipes)
            {
                SearchResults.Add(recipe);
            }
        }

        private async Task<List<Recipe>> FetchRecipesFromApi(string query)
        {
            var httpClient = new HttpClient();
            try
            {
                string encodedQuery = Uri.EscapeDataString(query);
                string apiUrl = $"http://10.0.2.2:5000/recipes?query={encodedQuery}";

                var response = await httpClient.GetStringAsync(apiUrl);
                var recipes = JsonConvert.DeserializeObject<List<Recipe>>(response);
                return recipes;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to fetch recipes: {ex.Message}", "OK");
                return new List<Recipe>();
            }
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Recipe selectedRecipe)
            {
                // Navigate to the RecipeDetailPage, passing the selected recipe
                Navigation.PushAsync(new RecipeDetailPage(selectedRecipe));
                ((ListView)sender).SelectedItem = null;
            }
        }

    }
}