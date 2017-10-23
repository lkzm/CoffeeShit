using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
    public class PlaceModel
    {


        public List<Drink> menu { set; get; }
        public List<Drink> order { set; get; }
        public PlaceModel(List<Drink> A, List<Drink> B)
        {
            menu = A;
            order = B;
        }


    }
}