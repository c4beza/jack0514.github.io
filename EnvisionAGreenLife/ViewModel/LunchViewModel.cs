using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    //logic to get the lunch data into a list to be displayed in the view.
    public class lunchList
    {
        public IPagedList<recipe> Lunch { get; set; }
    }
}