using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url_img { get; set; }
        public double Priece { get; set; }
        public int sale { get; set; }
        public bool isChecked { get; set; }
        public int qty { get; set; }
    }
}
