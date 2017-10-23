using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
    public class Order
    {
        public int ID { set; get; }
        public bool Compl { set; get; }
        public double Price { set; get; }
        public virtual List<Drink> Drinks { set; get; }
        public virtual User User { set; get; }
        public int UserID { set; get; }

        public double Total ()
        {
            double sum = 0;
            foreach (Drink x in Drinks) sum += x.Price;
            return sum;
        }
    }
    
}
