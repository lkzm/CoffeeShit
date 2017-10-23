using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
    public class Drink
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public double Price { set; get; }
        public string Rec { set; get; }

        public virtual Order Order { set; get; }

    }
}