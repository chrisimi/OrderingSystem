using System;
using System.Collections.Generic;
using OrderingSystem.Domain;

namespace OrderingSystem.Logic.Interfaces
{
    public interface ILocationLogic
    {
        /// <summary>
        /// Inserts a Location Object into a Database
        /// </summary>
        /// <param name="location">The Location Object</param>
        void Add(Location location);
        
        /// <summary>
        /// Edits a Location Object in a Database
        /// </summary>
        /// <param name="location">The Location Database</param>
        void Edit(Location location);
        
        /// <summary>
        /// Deletes a Location Object from a Database
        /// </summary>
        /// <param name="locationId">The ID of the Location</param>
        void Delete(Guid locationId);
        
        /// <summary>
        /// Gets a Location Object by its ID from a Database
        /// </summary>
        /// <param name="locationId">The ID of the Location</param>
        /// <returns>A Location Object or null if it failed</returns>
        Location GetLocation(Guid locationId);
        
        /// <summary>
        /// Gets all Location Objects from a Database
        /// </summary>
        /// <returns>A List of Location Objects or null if it failed</returns>
        List<Location> GetLocations();
    }
}