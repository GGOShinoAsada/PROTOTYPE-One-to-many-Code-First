using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DDD.Models
{
    public class Positions
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Пожалуйста, введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Пожалуйста, введите характеристику")]
        public string Character { get; set; }
        [Required(ErrorMessage ="Пожалуйста, введите описание")]
        public string Description { get; set; }
        public List<Products> Products { get; set; }
        public Positions()
        {
            Products = new List<Products>();
        }
        public Positions(int i,string n, string ch, string des)
        {
            Id = i;
            Name = n;
            Character = ch;
            Description = des;
        }
    }
}