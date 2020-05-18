using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    //logic to get the clothes washer data into a list to be displayed in the view.
    public class CwList
    {
        public IPagedList<clothes_washer> Clothes_Washers { get; set; }
    }
}