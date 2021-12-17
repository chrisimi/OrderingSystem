using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using OrderingSystem.Domain;
using OrderingSystem.Logic.Interfaces;

namespace OrderingSystem.Logic.SqlLogic
{
    public class SqlDrinkLogic : IDrinkLogic
    {
        private DBConnection _dbConnection = DBConnection.Instance();
        
        
        public void Add(Drink drink)
        {
            if (_dbConnection.IsConnected())
            {
                const string query = "INSERT INTO drinks(id, name, price, ingredients, extra_info) VALUES(@id, @name, @price, @ingredients, @extra_info)";
                
                MySqlCommand command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", drink.Id);
                command.Parameters.AddWithValue("@name", drink.Name);
                command.Parameters.AddWithValue("@price", drink.Price);
                command.Parameters.AddWithValue("@ingredients", drink.Ingredients);
                command.Parameters.AddWithValue("@extra_info", drink.ExtraInfo);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Drink drink)
        {
            throw new NotImplementedException();
        }

        public void Delete(Drink drink)
        {
            throw new NotImplementedException();
        }

        public Drink GetDrink(Guid guid)
        {
            throw new NotImplementedException();
        }

        public List<Drink> GetDrinks()
        {
            throw new NotImplementedException();
        }
    }
}