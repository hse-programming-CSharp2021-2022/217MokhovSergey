using System;

namespace PizzaStuff.Recipes
{
    public sealed class PizzaPeperoni : PizzaRecipe
    {
        public override string Name => "Peperoni";

        public override Ingredients Ingredients =>
            Ingredients.Dough | Ingredients.Peperoni | Ingredients.OliveOil | Ingredients.Mozzarella | Ingredients.Herbs;
    }
}