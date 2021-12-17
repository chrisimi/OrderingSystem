using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient;
using OrderingSystem.Domain;
using OrderingSystem.Logic.Interfaces;

namespace OrderingSystem.Logic.SqlLogic
{
    public class SqlCustomerLogic : ICustomerLogic
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance();
        
        public void Add(Customer customer)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "INSERT INTO customers(id, name) VALUES(@id, @name)";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", customer.Id);
                command.Parameters.AddWithValue("@name", customer.Name);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Customer customer)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "UPDATE customers SET name=@name WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", customer.Id);
                command.Parameters.AddWithValue("@name", customer.Name);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Guid customerId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "DELETE FROM customers WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", customerId);

                command.ExecuteNonQuery();
            }
        }

        public void AddDrinkToCustomer(Guid drinkId, Guid customerId)
        {
            if (_dbConnection.IsConnected())
            {
                var query =
                    "INSERT INTO customer_contents(id, customer_id, drink_id) VALUES(@id, @customer_id, @drink_id)";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", Guid.NewGuid());
                command.Parameters.AddWithValue("@customer_id", customerId);
                command.Parameters.AddWithValue("@drink_id", drinkId);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteDrinkFromCustomer(Guid drinkId, Guid customerId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "DELETE FROM customer_contents WHERE drink_id=@drink_id AND customer_id=@customer_id LIMIT 1";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@drink_id", drinkId);
                command.Parameters.AddWithValue("@customer_id", customerId);

                command.ExecuteNonQuery();
            }
        }

        public List<Drink> GetDrinks(Guid customerId)
        {
            if (_dbConnection.IsConnected())
            {
                var returnList = new List<Drink>();
                var query = "SELECT * FROM customer_contents WHERE customer_id=@customer_Id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@customer_Id", customerId);

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

        public Customer GetCustomer(Guid customerId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "SELECT * FROM customers WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", customerId);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    return new Customer()
                    {
                        Id = Guid.Parse(reader["id"].ToString()),
                        Name = reader["name"].ToString()
                    };
                }
            }

            return null;
        }

        public List<Customer> GetCustomers()
        {
            if (_dbConnection.IsConnected())
            {
                var returnList = new List<Customer>();

                var query = "SELECT * FROM customers";

                var command = new MySqlCommand(query, _dbConnection.Connection);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnList.Add(new Customer()
                        {
                            Id = Guid.Parse(reader["id"].ToString()),
                            Name = reader["name"].ToString()
                        });
                    }

                    return returnList;
                }

            }

            return null;
        }
    }
}