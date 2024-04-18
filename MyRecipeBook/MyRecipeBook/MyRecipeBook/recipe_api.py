from flask import Flask, jsonify, request

app = Flask(__name__)

recipes = [
    {
        'name': 'Spaghetti Carbonara',
        'ingredients': ['Spaghetti', 'Eggs', 'Parmesan Cheese', 'Pancetta', 'Black Pepper'],
        'image': 'https://static01.nyt.com/images/2021/02/14/dining/carbonara-horizontal/carbonara-horizontal-square640-v2.jpg'
    },
    {
        'name': 'Margherita Pizza',
        'ingredients': ['Pizza Dough', 'Tomato Sauce', 'Mozzarella Cheese', 'Basil'],
        'image': 'https://cdn.loveandlemons.com/wp-content/uploads/2023/07/margherita-pizza-recipe.jpg'
    },
    {
        'name': "Vegetarian Chili",
        'ingredients': [ "Kidney Beans", "Black Beans", "Tomato", "Onion", "Bell Peppers", "Carrot", "Garlic", "Chili Powder", "Cumin", "Olive Oil", "Salt", "Pepper" ],
        'image': "https://www.ambitiouskitchen.com/wp-content/uploads/2020/01/The-Best-Vegetarian-Chili-4-725x725-1.jpg"
    },
    {
        'name': 'Chicken Caesar Salad',
        'ingredients': ['Romaine Lettuce', 'Chicken Breast', 'Croutons', 'Parmesan Cheese', 'Caesar Dressing'],
        'image': 'https://kalejunkie.com/wp-content/uploads/2023/08/KJ_Chicken-Caesar-Pasta-Salad-5.jpg'
    },
    {
        'name': 'Beef Tacos',
        'ingredients': ['Ground Beef', 'Taco Shells', 'Cheddar Cheese', 'Lettuce', 'Tomato', 'Sour Cream'],
        'image': 'https://loveandgoodstuff.com/wp-content/uploads/2020/08/classic-ground-beef-tacos-1200x1200.jpg'
    },
    {
        'name': 'Butternut Squash Soup',
        'ingredients': ['Butternut Squash', 'Vegetable Stock', 'Onion', 'Carrot', 'Celery', 'Cream', 'Nutmeg'],
        'image': 'https://reciperunner.com/wp-content/uploads/2021/10/butternut-squash-apple-soup-photos.jpg'
    },
    {
        'name': 'Grilled Cheese Sandwich',
        'ingredients': ['Bread', 'Cheddar Cheese', 'Butter'],
        'image': 'https://therecipecritic.com/wp-content/uploads/2022/08/grilledcheese-1.jpg'
    },
    {
        'name': 'Pan-Seared Salmon',
        'ingredients': ['Salmon Fillets', 'Salt', 'Pepper', 'Olive Oil', 'Lemon'],
        'image': 'https://www.healthyseasonalrecipes.com/wp-content/uploads/2022/11/crispy-seared-salmon-hero-sq-32.jpg'
    },
    {
        'name': 'Avocado Toast',
        'ingredients': ['Bread', 'Avocado', 'Salt', 'Pepper', 'Red Pepper Flakes', 'Lemon Juice'],
        'image': 'https://vancouverwithlove.com/wp-content/uploads/2023/05/high-protein-avocado-toast-featured.jpg'
    },
    {
        'name': 'Lemon Garlic Pasta',
        'ingredients': ['Spaghetti', 'Garlic', 'Lemon', 'Olive Oil', 'Parmesan Cheese', 'Parsley'],
        'image': 'https://assets-global.website-files.com/60da4419d98adf0a36dc660e/6176ef6f4ad1f6137a60777c_GarlicPasta-18_1-scaled.jpg'
    },
    {
        'name': 'Cheese Pizza',
        'ingredients': ['Pizza Dough', 'Tomato Sauce', 'Mozzarella Cheese'],
        'image': 'https://bakerbynature.com/wp-content/uploads/2014/05/IMG_4645-500x500.jpg'
    }
]

@app.route('/recipes', methods=['GET'])
def get_recipes():
    query = request.args.get('query')
    if query:
        # Filter recipes to those containing the query string in the name, case insensitive
        filtered_recipes = [recipe for recipe in recipes if query.lower() in recipe['name'].lower()]
        return jsonify(filtered_recipes)
    return jsonify(recipes)

if __name__ == '__main__':
    app.run(debug=True)
