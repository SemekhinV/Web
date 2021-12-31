using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloAngularApp.Models
{
    public class Skin
    {
        // ID записи со скином
        public int Id { get; set; }
        // название скина 
        public string SkinName { get; set; }
        //
        public string Author { get; set; }
        // цена скина
        public int Price { get; set; }
        // image
        public string SkinImage { get; set; }
    }
}
