using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ITableLogic
    {
        void Add(Table table);
        void Edit(Table table);
        void Delete(Table table);
        void AddDrinkToTable(Drink drink);
        void DeleteDrinkFromTable(Drink drink);
        Table GetTable(Guid guid);
        List<Table> GetTables();
        List<Drink> GetDrinks();
    }
}