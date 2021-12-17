using System;
using System.Collections.Generic;

namespace OrderingSystem.Domain
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Drink> Drinks { get; set; }
        public Guid ParentCat { get; set; }
    }
}