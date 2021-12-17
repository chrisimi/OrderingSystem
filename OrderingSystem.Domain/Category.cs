using System;
using System.Collections.Generic;

namespace OrderingSystem.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}