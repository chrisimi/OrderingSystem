using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using OrderingSystem.Domain;
using OrderingSystem.Logic.Interfaces;
using Org.BouncyCastle.Security;

namespace OrderingSystem.Logic.SqlLogic
{
    public class SqlDrinkLogic : IDrinkLogic
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance();
        public void Add(Drink drink)
        {
            if (_dbConnection.IsConnected())
            {
                var query =
                    "INSERT INTO drinks(id, name, price, ingredients, extra_info) VALUES(@id, @name, @price, @ingredients, @extra_info)";

                var command = new MySqlCommand(query, _dbConnection.Connection);
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
            if (_dbConnection.IsConnected())
            {
                var query =
                    "UPDATE drinks SET name=@name, price=@price, ingredients=@ingredients, extra_info=@extra_info WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@name", drink.Name);
                command.Parameters.AddWithValue("@price", drink.Price);
                command.Parameters.AddWithValue("@ingredients", drink.Ingredients);
                command.Parameters.AddWithValue("@extra_info", drink.ExtraInfo);

                command.ExecuteNonQuery();
            }
        }
        
        public void Delete(Guid drinkId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "DELETE FROM drinks WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", drinkId);

                command.ExecuteNonQuery();
            }
        }


        public Drink GetDrink(Guid drinkId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "SELECT * FROM drinks WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", drinkId);
                
                
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    return new Drink()
                    {
                        Id = Guid.Parse(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        Price = float.Parse(reader["price"].ToString()),
                        Ingredients = reader["ingredients"].ToString(),
                        ExtraInfo = reader["extra_info"].ToString()
                    };
                }
                    
            }

            return null;
        }
        
        public List<Drink> GetDrinks()
        {
            if (_dbConnection.IsConnected())
            {
                var returnList = new List<Drink>();

                var query = "SELECT * FROM drinks";

                var command = new MySqlCommand(query, _dbConnection.Connection);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnList.Add(new Drink()
                        {
                            Id = Guid.Parse(reader["id"].ToString()),
                            Name = reader["name"].ToString(),
                            Price = float.Parse(reader["price"].ToString()),
                            Ingredients = reader["ingredients"].ToString(),
                            ExtraInfo = reader["extra_info"].ToString()
                        });
                    }

                    return returnList;
                }
            }
            return null;
        }
    }
}
        
