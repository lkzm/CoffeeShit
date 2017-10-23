using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
    public class Amounts
    {
        public List<Drink> Drinks { set; get; }
        public List<int> Am { set; get; }
        public Amounts(List<Drink> A)
        {
            Drinks = A;
            Am = new List<int>();
            for (int i = 0; i < A.Count(); i++)
            {

                Am.Add(0);
            }
        }
    }
}