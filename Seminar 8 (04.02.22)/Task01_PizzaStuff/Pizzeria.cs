using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStuff
{
    public class Pizzeria
    {
        // Склад для ингредиентов. Хранит количество каждого ингредиента.
        private Dictionary<Ingredients, int> storage = new Dictionary<Ingredients, int>();

        /// <summary>
        /// Привозит новые ингредиенты на склад.
        /// Увеличивает количество ингредиента ingredients на значение amount.
        /// </summary>
        /// <param name="ingredients"> Ингредиент, который будет привезен на склад. </param>
        /// <param name="amount"> Количество ингредиента. </param>
        public void DeliverIngredient(Ingredients ingredients, int amount)
        {
            if (storage.ContainsKey(ingredients))
            {
                storage[ingredients] += amount;
            }
        }

        /// <summary>
        /// Возвращет информацию о количестве каждого ингредиента на складе.
        /// </summary>
        public (string name, int amount)[] GetStorage()
        {
            (string, int)[] arrayOfIngredients = new (string, int)[storage.Count];

            int index = 0;
            foreach (var key in storage.Keys)
            {
                arrayOfIngredients[index] = (key.ToString(), storage[key]);
                index++;
            }

            return arrayOfIngredients;
        }

        /// <summary>
        /// Готовит пиццу по рецепту.
        /// </summary>
        /// <param name="recipe"> Рецепт пиццы. </param>
        /// <returns> Приготовленная пицца. </returns>
        /// <exception cref="PizzaException"> Если на складе не хватает ингредиентов, чтобы приготовить пиццу по рецепту.</exception>
        public Pizza MakePizza(PizzaRecipe recipe)
        {
            if (!HasIngredients(recipe))
            {
                throw new PizzaException($"Not enough ingredients to make {recipe.Name}");
            }

            UseIngredients(recipe);

            return new Pizza(recipe);
        }

        /// <summary>
        /// Проверяет, есть ли на складе ингредиенты для рецепта.
        /// </summary>
        /// <param name="recipe"> Рецепт, наличие ингредиентов необходимо проверить. </param>
        /// <returns> true, если все ингредиенты есть на складе, false иначе. </returns>
        private bool HasIngredients(PizzaRecipe recipe)
        {
            if (recipe.Ingredients == 0)
            {
                return true;
            }
            foreach (Ingredients item in Enum.GetValues(typeof(Ingredients)))
            {
                if ((item & recipe.Ingredients) != 0 && storage[item] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Удаляет со склада по одному ингредиенту из рецепта.
        /// </summary>
        /// <param name="recipe"></param>
        private void UseIngredients(PizzaRecipe recipe)
        {
            foreach (Ingredients item in Enum.GetValues(typeof(Ingredients)))
            {
                if ((item & recipe.Ingredients) != 0)
                {
                    storage[item]--;
                }
            }
        }
    }
}
