using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    //logic to get the dish washer data into a list to be displayed in the view.
    public class DwList
    {
        public IPagedList<dishwasher> Dishwashers { get; set; }
    }
}