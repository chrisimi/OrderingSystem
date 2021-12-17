using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface IDrinkLogic
    {
        void Add(Drink drink);
        void Edit(Drink drink);
        void Delete(Drink drink);
        Drink GetDrink(Guid guid);
        List<Drink> GetDrinks();
    }
}