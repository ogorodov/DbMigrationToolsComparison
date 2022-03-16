﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DbMigrationsComparison.DalEf.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}