using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApi.Model
{
    public class CategoryMst
    {
        public int id { get; set; }
        public string category { get; set; }
        public int isactive { get; set; }
        public int isdelete { get; set; }
    }
}
