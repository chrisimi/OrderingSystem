using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using OrderingSystem.Domain;
using OrderingSystem.Logic.Interfaces;

namespace OrderingSystem.Logic.SqlLogic
{
    public class SqlCategoryLogic : ICategoryLogic
    {
        private readonly DBConnection _dbConnection = DBConnection.Instance();
        
        public void Add(Category category)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "INSERT INTO categories(id, name, sub_category_of) VALUES(@id, @name, @sub_category_of)";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", category.Id);
                command.Parameters.AddWithValue("@name", category.Name);
                command.Parameters.AddWithValue("@sub_category_of", category.SubCategoryOf);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Category category)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "UPDATE categories SET name=@name, sub_category_of=@sub_category_of WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", category.Id);
                command.Parameters.AddWithValue("@name", category.Name);
                command.Parameters.AddWithValue("@sub_category_of", category.SubCategoryOf);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Guid categoryId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "DELETE FROM categories WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", categoryId);

                command.ExecuteNonQuery();
            }
        }

        public void AddDrinkToSubCategory(Guid drinkId, Guid categoryId)
        {
            if (_dbConnection.IsConnected())
            {
                var query =
                    "INSERT INTO category_contents(id, category_id, drink_id) VALUES(@id, @category_id, @drink_id)";
                
                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", Guid.NewGuid());
                command.Parameters.AddWithValue("@category_id", categoryId);
                command.Parameters.AddWithValue("@drink_id", drinkId);
                
                command.ExecuteNonQuery();
            }
        }

        public void DeleteDrinkFromSubCategory(Guid drinkId, Guid categoryId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "DELETE FROM category_contents WHERE drink_id=@drink_id AND category_id=@category_id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@drink_id", drinkId);
                command.Parameters.AddWithValue("@category_id", categoryId);

                command.ExecuteNonQuery();
            }
        }

        public List<Guid> GetDrinks(Guid categoryId)
        {
            if (_dbConnection.IsConnected())
            {
                var returnList = new List<Guid>();
                
                var query = "SELECT * FROM category_contents WHERE category_id=@category_id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@category_id", categoryId);
                
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnList.Add(Guid.Parse(reader["drink_id"].ToString()));
                    }

                    return returnList;
                }
            }
            return null;
        }


        public Category GetCategory(Guid categoryId)
        {
            if (_dbConnection.IsConnected())
            {
                var query = "SELECT * FROM categories WHERE id=@id";

                var command = new MySqlCommand(query, _dbConnection.Connection);
                command.Parameters.AddWithValue("@id", categoryId);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    var isSuccesful = Guid.TryParse(reader["sub_category_of"].ToString(), out Guid id);

                    if (isSuccesful)
                    {                    
                        return new Category()
                        {
                            Id = Guid.Parse(reader["id"].ToString()),
                            Name = reader["name"].ToString(),
                            SubCategoryOf = id
                        };
                    }
                    return new Category()
                    {
                        Id = Guid.Parse(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        SubCategoryOf = null
                    };
                }
            }

            return null;
        }

        public List<Category> GetCategories()
        {
            if (_dbConnection.IsConnected())
            {
                var returnList = new List<Category>();
                
                var query = "SELECT * FROM categories";

                var command = new MySqlCommand(query, _dbConnection.Connection);

                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var isSuccesful = Guid.TryParse(reader["sub_category_of"].ToString(), out Guid id);

                        if (isSuccesful)
                        {
                            returnList.Add(new Category()
                            {
                                Id = Guid.Parse(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                SubCategoryOf = id
                            });
                        }
                        else
                        {
                            returnList.Add(new Category()
                            {
                                Id = Guid.Parse(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                SubCategoryOf = null
                            });
                        }
                    }

                    return returnList;
                }
            }
            return null;
        }
    }
}