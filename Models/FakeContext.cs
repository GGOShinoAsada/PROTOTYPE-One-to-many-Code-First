using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.Models
{
    public class FakeContext
    {
        public List<Positions> Positions = new List<Positions>();
        public List<Products> Products = new List<Products> ();
        public FakeContext()
        {
            Positions.AddRange(new List<Positions>(){
                new Positions(1,"Бытовая техника","характеристика","описание"),
                new Positions(2,"Компьютеры","характеристика","описание"),
                new Positions(3,"Мобильные телефоны","характеристика","описание"),
                new Positions(4,"Радиоприемники","характеристика","описание")
            });
            Products.AddRange(new List<Products>()
            {
                new Products(1,"Телевизор LG TV ST3456",1,"это хороший товар",25.4),
                new Products(2,"Телевизор Samsung DT456SR",2,"это хороший товар",26.4),
                new Products(3,"Мобильный телефон Nokia S3310",3,"это замечательный товар",17.5)
            });
        }
        
    }
}