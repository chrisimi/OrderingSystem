using System;
using System.Data.SqlTypes;
using OrderingSystem.Domain;
using OrderingSystem.Logic.SqlLogic;

namespace OrderingSystem
{
    static class Program
    {
        static void Main(string[] args)
        {
            SqlDrinkLogic sqlDrinkLogic = new SqlDrinkLogic();
            sqlDrinkLogic.Add(new Drink()
            {
                Id = Guid.NewGuid(),
                Name = "Vodka Bull",
                Ingredients = "Vodka, Red Bull",
                Price = 4.20f,
                ExtraInfo = "-"
            });
        }
    }
}