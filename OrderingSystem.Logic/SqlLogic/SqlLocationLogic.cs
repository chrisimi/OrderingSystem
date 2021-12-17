using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using OrderingSystem.Domain;
using OrderingSystem.Logic.Interfaces;

namespace OrderingSystem.Logic.SqlLogic
{
    public class SqlLocationLogic : ILocationLogic
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance();
        
        public void Add(Location location)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "INSERT INTO locations(id, name) VALUES(@id, @name)";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", location.Id);
                command.Parameters.AddWithValue("@name", location.Name);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Location location)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "UPDATE locations SET name=@name WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", location.Id);
                command.Parameters.AddWithValue("@name", location.Name);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Guid locationId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "DELETE FROM locations WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", locationId);

                command.ExecuteNonQuery();
            }
        }

        public Location GetLocation(Guid locationId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "SELECT * FROM locations WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", locationId);

                using MySqlDataReader reader = command.ExecuteReader();
                
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Location()
                    {
                        Id = Guid.Parse(reader["id"].ToString()),
                        Name = reader["name"].ToString()
                    };
                }
            }

            return null;
        }

        public List<Location> GetLocations()
        {
            if (_dbConnection.IsConnected())
            {
                var returnList = new List<Location>();

                var query = "SELECT * FROM locations";

                var command = new MySqlCommand(query, _dbConnection.Connection);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnList.Add(new Location()
                        {
                            Id = Guid.Parse(reader["id"].ToString()),
                            Name = reader["name"].ToString()
                        });
                    }
                }

                return returnList;
            }

            return null;
        }
    }
}