using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Image { get; set; }

        public string IngredientsText => string.Join(", ", Ingredients);
    }

}
