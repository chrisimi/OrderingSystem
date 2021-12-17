using System;
using System.Collections.Generic;

namespace OrderingSystem.Domain
{
    public class Table
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public Guid? LocationId { get; set; }
    }
}