using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ICategoryLogic
    {
        /// <summary>
        /// Inserts a Category Object into a Database
        /// </summary>
        /// <param name="category">The Category Object</param>
        void Add(Category category);
        
        /// <summary>
        /// Edits a Category Object in a Database
        /// </summary>
        /// <param name="category">The new Category Object</param>
        void Edit(Category category);
        
        /// <summary>
        /// Deletes a Category Object from a Database
        /// </summary>
        /// <param name="categoryId">The ID of the Category</param>
        void Delete(Guid categoryId);
        
        /// <summary>
        /// Adds a Drink Object to a SubCategory in a Database
        /// </summary>
        /// <param name="drinkId">The ID of the Drink</param>
        /// <param name="subCategoryId">The ID of the SubCategory</param>
        void AddDrinkToSubCategory(Guid drinkId, Guid subCategoryId);
        
        /// <summary>
        /// Deletes a Drink from a SubCategory in a Database
        /// </summary>
        /// <param name="drinkId">The ID of the Drink</param>
        /// <param name="subCategoryId">The ID of the SubCategory</param>
        void DeleteDrinkFromSubCategory(Guid drinkId, Guid subCategoryId);

        /// <summary>
        /// Gets all Drinks from a SubCategory in a Database
        /// </summary>
        /// <param name="subCategoryId">The ID of the SubCategory</param>
        /// <returns>A List of Drink Objects or null if it failed</returns>
        List<Guid> GetDrinks(Guid subCategoryId);
        
        /// <summary>
        /// Gets a Category Object by its ID from a Database
        /// </summary>
        /// <param name="categoryId">The ID of the Category</param>
        /// <returns>A Category Object or null if it failed</returns>
        Category GetCategory(Guid categoryId);
        
        /// <summary>
        /// Gets all Category Objects from a Database
        /// </summary>
        /// <returns>A List of Category Objects or null if it failed</returns>
        List<Category> GetCategories();

        
    }
}