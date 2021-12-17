using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using OrderingSystem.Domain;
using OrderingSystem.Logic.Interfaces;

namespace OrderingSystem.Logic.SqlLogic
{
    public class SqlTableLogic : ITableLogic
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance();
        public void Add(Table table)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "INSERT INTO tables(id, label, location_id) VALUES(@id, @label, @location_id)";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", table.Id);
                command.Parameters.AddWithValue("@label", table.Label);
                command.Parameters.AddWithValue("@location_id", table.LocationId);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Table table)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "UPDATE tables SET label=@label, location_id=@location_id WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", table.Id);
                command.Parameters.AddWithValue("@label", table.Label);
                command.Parameters.AddWithValue("@location_id", table.LocationId);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Guid tableId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "DELETE FROM tables WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", tableId);

                command.ExecuteNonQuery();
            }
        }
        
        public void AddDrinkToTable(Guid tableId, Guid drinkId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "INSERT INTO table_contents(id, table_id, drink_id) VALUES(@id, @table_id, @drink_id)";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", Guid.NewGuid());
                command.Parameters.AddWithValue("@table_id", tableId);
                command.Parameters.AddWithValue("@drink_id", drinkId);

                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteDrinkFromTable(Guid tableId, Guid drinkId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "DELETE FROM table_contents WHERE drink_id=@drink_id AND table_id=@table_id LIMIT 1";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@drink_id", drinkId);
                command.Parameters.AddWithValue("@table_id", tableId);

                command.ExecuteNonQuery();
            }
        }

        public List<Drink> GetDrinks(Guid tableId)
        {
            if (_dbConnection.IsConnected())
            {
                var returnList = new List<Drink>();
                var query = "SELECT * FROM table_contents WHERE table_id=@table_id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@table_id", tableId);

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

        public Table GetTable(Guid tableId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "SELECT * FROM tables WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", tableId);

                using MySqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    reader.Read();
                    return new Table()
                    {
                        Id = Guid.Parse(reader["id"].ToString()),
                        Label = reader["number"].ToString(),
                        LocationId = Guid.Parse(reader["location_id"].ToString())
                    };
                }
            }

            return null;
        }

        public List<Table> GetTables()
        {
            if (_dbConnection.IsConnected())
            {
                var returnList = new List<Table>();

                var query = "SELECT * FROM tables";

                var command = new MySqlCommand(query, _dbConnection.Connection);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnList.Add(new Table()
                        {
                            Id = Guid.Parse(reader["id"].ToString()),
                            Label = reader["number"].ToString(),
                            LocationId = Guid.Parse(reader["location_id"].ToString())
                        });
                    }

                    return returnList;
                }
            }

            return null;
        }

        public List<Table> GetTablesByLocation(Guid locationId)
        {
            if (_dbConnection.IsConnected())
            {
                var returnList = new List<Table>();

                var query = "SELECT * FROM tables WHERE location_id=@location_id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@location_id", locationId);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnList.Add(new Table()
                        {
                            Id = Guid.Parse(reader["id"].ToString()),
                            Label = reader["number"].ToString(),
                            LocationId = Guid.Parse(reader["location_id"].ToString())
                        });
                    }

                    return returnList;
                }
            }

            return null;
        }
        
    }
}