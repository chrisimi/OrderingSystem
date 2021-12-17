using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ICustomerLogic
    {
        void Add(Customer customer);
        void Edit(Customer customer);
        void Delete(Customer customer);
        void AddDrinkToCustomer(Drink drink);
        void DeleteDrinkFromCustomer(Drink drink);
        Customer GetCustomer(Guid id);
        List<Drink> GetDrinks();
    }
}