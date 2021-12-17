using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ISubCategoryLogic
    {
        void Add(SubCategory subCategory);
        void Edit(SubCategory subCategory);
        void Delete(SubCategory subCategory);
        void AddDrinkToSubCategory(Drink drink);
        void DeleteDrinkFromSubCategory(Drink drink);
        SubCategory GetSubCategory(Guid guid);
    }
}