using MyRecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRecipeBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDetailPage : ContentPage
    {
        public RecipeDetailPage(Recipe recipe)
        {
            InitializeComponent();
            BindingContext = recipe;

            recipeName.Text = recipe.Name;
            recipeImage.Source = recipe.Image;
            recipeIngredients.Text = string.Join(Environment.NewLine, recipe.Ingredients);
        }


    }
}