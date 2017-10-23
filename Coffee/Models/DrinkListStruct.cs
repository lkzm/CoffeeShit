using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
    public class DrinkListStruct
    {
        public Order order;
        public List<Drink> drinks;
        public DrinkListStruct(Order k, List<Drink> ks)
        {
            order = k;
            drinks = ks;
        }
    }
}