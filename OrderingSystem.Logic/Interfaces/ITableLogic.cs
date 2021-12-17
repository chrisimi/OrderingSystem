using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ITableLogic
    {
        /// <summary>
        /// Inserts a new Table object into a Database
        /// </summary>
        /// <param name="table">The Table Object</param>
        void Add(Table table);
                
        /// <summary>
        /// Edits a Table object in a Database
        /// </summary>
        /// <param name="table">The Table Object</param>
        void Edit(Table table);
        
        
        /// <summary>
        /// Deletes a Table object from a Database
        /// </summary>
        /// <param name="tableId">The ID of the Table</param>
        void Delete(Guid tableId);
        
        /// <summary>
        /// Adds a Drink Object to a Table in a Database
        /// </summary>
        /// <param name="tableId">The ID of the Table</param>
        /// <param name="drinkId">The ID of the Drink</param>
        void AddDrinkToTable(Guid tableId, Guid drinkId);
        
        /// <summary>
        /// Deletes a Drink Object from a Table in a Database
        /// </summary>
        /// <param name="tableId">The ID of the Table</param>
        /// <param name="drinkId">The ID of the Drink</param>
        void DeleteDrinkFromTable(Guid tableId, Guid drinkId);
                
        /// <summary>
        /// Gets all Drinks Objects from a Table in a Database
        /// </summary>
        /// <param name="tableId">The ID of the Table</param>
        /// <returns>A List of Drink Objects or null if it failed</returns>
        List<Drink> GetDrinks(Guid tableId);
            
        /// <summary>
        /// Gets a Table Object by its ID from a Database
        /// </summary>
        /// <param name="tableId">The ID of the Table</param>
        /// <returns>A Table Object or null if it failed</returns>
        Table GetTable(Guid tableId);
        
        /// <summary>
        /// Gets all Tables from a MySQL Database
        /// </summary>
        /// <returns>A List of Table Objects or null if it failed</returns>
        List<Table> GetTables();
        
            
        /// <summary>
        /// Gets all Table Objects by its Location from a Database
        /// </summary>
        /// <param name="locationId">The ID of the Location</param>
        /// <returns>A List of Table Objects or null if it failed</returns>
        List<Table> GetTablesByLocation(Guid locationId);
        
    }
}