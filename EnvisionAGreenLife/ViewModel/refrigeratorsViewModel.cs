using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    //logic to get the refrigerator data into a list to be displayed in the view.
    public class RList
    {
        public IPagedList<refrigerator> Refrigerators { get; set; }
    }
}