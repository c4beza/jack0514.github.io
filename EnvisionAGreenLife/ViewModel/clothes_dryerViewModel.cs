using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    public class CdList
    {
        public IPagedList<clothes_dryer> Clothes_dryers { get; set; }
        public IPagedList<clothes_washer> Clothes_washers { get; internal set; }
    }
}