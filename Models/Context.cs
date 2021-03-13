using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DDD.Models
{
    public class Context:DbContext
    {
        public Context():base("MONGODB")
        {
           
        }
       public DbSet<Positions> PosContext { get; set; }
        public DbSet<Products> ProductsContext { get; set; }
         
    }
}