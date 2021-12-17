using System;
using System.Collections.Generic;
using OrderingSystem.Domain;
using OrderingSystem.Logic.Interfaces;

namespace OrderingSystem.Logic.SqlLogic
{
    public class SqlTableLogic : ITableLogic
    {
        public void Add(Table table)
        {
            throw new NotImplementedException();
        }

        public void Edit(Table table)
        {
            throw new NotImplementedException();
        }

        public void Delete(Table table)
        {
            throw new NotImplementedException();
        }

        public void AddDrinkToTable(Drink drink)
        {
            throw new NotImplementedException();
        }

        public void DeleteDrinkFromTable(Drink drink)
        {
            throw new NotImplementedException();
        }

        public Table GetTable(Guid guid)
        {
            throw new NotImplementedException();
        }

        public List<Table> GetTables()
        {
            throw new NotImplementedException();
        }

        public List<Drink> GetDrinks()
        {
            throw new NotImplementedException();
        }
    }
}