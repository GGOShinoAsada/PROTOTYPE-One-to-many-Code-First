using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public Positions Position { get; set; }
        public Products()
        {
            Position = new Positions();
        }
        public Products(int _id, string n, int pid, string des, double rat)
        {
            Id = _id;
            Name = n;
            PositionId = pid;
            Description = des;
            Rating = rat;
        }
    }
}