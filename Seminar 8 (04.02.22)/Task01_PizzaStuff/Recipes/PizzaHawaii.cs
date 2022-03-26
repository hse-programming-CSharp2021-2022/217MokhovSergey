using System;

namespace PizzaStuff.Recipes
{
    public sealed class PizzaHawaii : PizzaRecipe
    {
        public override string Name => "Hawaii";

        public override Ingredients Ingredients =>
            Ingredients.Dough | Ingredients.Pineapple | Ingredients.Ham | Ingredients.Mozzarella;
    }
}
