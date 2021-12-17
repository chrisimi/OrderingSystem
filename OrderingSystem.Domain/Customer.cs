using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace OrderingSystem.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}