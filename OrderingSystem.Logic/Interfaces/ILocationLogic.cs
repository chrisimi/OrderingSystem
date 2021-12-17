using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ILocationLogic
    {
        void Add(Location location);
        void Edit(Location location);
        void Delete(Location location);
        void AddTableToLocation(Table table);
        void DeleteTableFromLocation(Table table);
        Location GetLocation(Guid guid);
        List<Location> GetLocations();
        List<Table> GetTables();
    }
}