using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ICategoryModel
    {
        void Add(Category category);
        void Edit(Category category);
        void Delete(Category category);
        void AddSubCategoryToCategory(SubCategory subCategory);
        void DeleteSubCategoryFromCategory(SubCategory subCategory);
        Category GetCategory(Guid guid);
        List<Category> GetCategories();
        List<SubCategory> GetSubCategories();
    }
}