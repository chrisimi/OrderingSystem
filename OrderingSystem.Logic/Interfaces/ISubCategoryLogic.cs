using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ISubCategoryLogic
    {
        /// <summary>
        /// Inserts a SubCategory Object into a Database
        /// </summary>
        /// <param name="subCategory">The SubCategory Object</param>
        void Add(SubCategory subCategory);
        
        /// <summary>
        /// Edits a SubCategory Object in a Database
        /// </summary>
        /// <param name="subCategory">The new SubCategory Object</param>
        void Edit(SubCategory subCategory);
        
        /// <summary>
        /// Deletes a SubCategory Object from a Database
        /// </summary>
        /// <param name="subCategoryId">The ID of the SubCategory</param>
        void Delete(Guid subCategoryId);
        
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
        List<Drink> GetDrinks(Guid subCategoryId);

        /// <summary>
        /// Gets a SubCategory Object by its ID from a Database
        /// </summary>
        /// <param name="subCategoryId">The ID of the SubCategory</param>
        /// <returns>A SubCategory Object or null if it failed</returns>
        SubCategory GetSubCategory(Guid subCategoryId);
    }
}