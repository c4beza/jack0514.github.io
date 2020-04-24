using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    public class CwList
    {
        public IPagedList<clothes_washer> Clothes_Washers { get; set; }
    }
}