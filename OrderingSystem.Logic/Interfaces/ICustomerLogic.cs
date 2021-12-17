using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ICustomerLogic
    {
        /// <summary>
        /// Inserts a Customer Object into a Database
        /// </summary>
        /// <param name="customer">The Customer Object</param>
        void Add(Customer customer);
        
        /// <summary>
        /// Edits a Customer Object in a Database
        /// </summary>
        /// <param name="customer">The new Customer Object</param>
        void Edit(Customer customer);
        
        /// <summary>
        /// Deletes a Customer Object from a Database
        /// </summary>
        /// <param name="customerId">The ID of the Customer</param>
        void Delete(Guid customerId);
        
        /// <summary>
        /// Adds a Drink Object to a Customer in a Database
        /// </summary>
        /// <param name="drinkId">The ID of the Drink</param>
        /// <param name="customerId">The ID fo the Customer</param>
        void AddDrinkToCustomer(Guid drinkId, Guid customerId);
        
        /// <summary>
        /// Deletes a Drink Object form a Customer from a Database
        /// </summary>
        /// <param name="drinkId">The ID of the Drink</param>
        /// <param name="customerId">The ID fo the Customer</param>
        void DeleteDrinkFromCustomer(Guid drinkId, Guid customerId);
        
        /// <summary>
        /// Gets all Drinks by its Customer from a Database
        /// </summary>
        /// <returns>A List of Drink Objects or null if it failed</returns>
        List<Drink> GetDrinks(Guid customerId);
        
        /// <summary>
        /// Gets a Customer Object by its ID from a Database
        /// </summary>
        /// <param name="customerId">The ID of the Customer</param>
        /// <returns>A Customer Object or null if it failed</returns>
        Customer GetCustomer(Guid customerId);
        
        /// <summary>
        /// Gets all Customer Objects from a Database
        /// </summary>
        /// <returns>A List of Customer Objects or null if it failed</returns>
        List<Customer> GetCustomers();

    }
}