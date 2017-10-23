using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee.Models
{
    public class User
    {
        public int ID { set; get; }
        public string Username { set; get; }
        public int Typer { set; get; }


        public virtual List<Order> Orders { set; get; }
    }
}