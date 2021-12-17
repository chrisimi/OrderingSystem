using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ICategoryModel
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
        /// Adds a SubCategory Object to a Category in a Database
        /// </summary>
        /// <param name="subCategoryId">The ID of the SubCategory</param>
        void AddSubCategoryToCategory(Guid subCategoryId);
        
        /// <summary>
        /// Deletes a SubCategory from a Category in a Database
        /// </summary>
        /// <param name="subCategoryId">The ID of the SubCategory</param>
        void DeleteSubCategoryFromCategory(Guid subCategoryId);
        
        /// <summary>
        /// Gets all SubCategory Objects from its Category in a Database
        /// </summary>
        /// <returns>A List of SubCategory Objects or null if it failed</returns>
        List<SubCategory> GetSubCategories();
        
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