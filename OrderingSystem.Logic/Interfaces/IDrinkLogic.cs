using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface IDrinkLogic
    {
        /// <summary>
        /// Inserts a Drink Object to a Database
        /// </summary>
        /// <param name="drink">The Drink Object</param>
        void Add(Drink drink);
        
        /// <summary>
        /// Edits a Drink Object in a Database
        /// </summary>
        /// <param name="drink">The new Drink Object</param>
        void Edit(Drink drink);
        
        /// <summary>
        /// Deletes a Drink Object from a Database
        /// </summary>
        /// <param name="drinkId">The ID of the Drink</param>
        void Delete(Guid drinkId);
        
        /// <summary>
        /// Gets a Drink Object by its ID from a Database
        /// </summary>
        /// <param name="drinkId">The ID of the Drink</param>
        /// <returns>A Drink Object or null if it failed</returns>
        Drink GetDrink(Guid drinkId);
        
        /// <summary>
        /// Gets all Drink Objects from a Database
        /// </summary>
        /// <returns>A List of Drink Objects or null if it failed</returns>
        List<Drink> GetDrinks();
    }
}