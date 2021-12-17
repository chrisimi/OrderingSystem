using System;
using System.Collections.Generic;

namespace OrderingSystem.Domain
{
    public class Table
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}