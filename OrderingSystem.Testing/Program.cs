using System;
using System.Data.SqlTypes;
using OrderingSystem.Domain;
using OrderingSystem.Logic.Interfaces;
using OrderingSystem.Logic.SqlLogic;

namespace OrderingSystem
{
    static class Program
    {
        static void Main(string[] args)
        {
            ILocationLogic locationLogic = new SqlLocationLogic();
            ICategoryLogic categoryLogic = new SqlCategoryLogic();
            IDrinkLogic drinkLogic = new SqlDrinkLogic();
            ICustomerLogic customerLogic = new SqlCustomerLogic();
            ITableLogic tableLogic = new SqlTableLogic();

            for (int i = 0; i < 6; i++)
            {
                tableLogic.Add(new Table()
                {
                    Id = Guid.NewGuid(),
                    Label = i.ToString(),
                    LocationId = Guid.Parse("18e1f433-83eb-4174-8945-00d6fe2feba0"),
                    WpfInfo = new WpfInfo()
                    {
                        PosX = 20 * i,
                        PosY = 20,
                        Height = 50,
                        Width = 50,
                        Shape = "Rectangle"
                    }
                });
            }
            for (int i = 0; i < 6; i++)
            {
                tableLogic.Add(new Table()
                {
                    Id = Guid.NewGuid(),
                    Label = i.ToString(),
                    LocationId = Guid.Parse("b2df8842-1906-4b56-80a8-250b1c25ca79"),
                    WpfInfo = new WpfInfo()
                    {
                        PosX = 20 * i,
                        PosY = 20,
                        Height = 50,
                        Width = 50,
                        Shape = "Rectangle"
                    }
                });
            }
            for (int i = 0; i < 6; i++)
            {
                tableLogic.Add(new Table()
                {
                    Id = Guid.NewGuid(),
                    Label = i.ToString(),
                    LocationId = Guid.Parse("8b8d2489-ca2c-4571-bb60-9e06cd998e9d"),
                    WpfInfo = new WpfInfo()
                    {
                        PosX = 20 * i,
                        PosY = 20,
                        Height = 50,
                        Width = 50,
                        Shape = "Rectangle"
                    }
                });
            }


        }
    }
}