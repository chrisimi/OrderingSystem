using System;
using System.Collections.Generic;

namespace OrderingSystem.Domain
{
    public class Drink
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public List<string> Ingredients { get; set; }
        public string ExtraInfo { get; set; }
    }
}