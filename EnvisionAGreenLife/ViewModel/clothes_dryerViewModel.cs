using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    //logic to get the clothes dryer data into a list to be displayed in the view.
    public class CdList
    {
        public IPagedList<clothes_dryer> Clothes_dryers { get; set; }
    }
}