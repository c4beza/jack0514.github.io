using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    public class AcList
    {
        public PagedList.IPagedList<air_conditioner> air_Conditioners { get; set; }
        public bool Ischecked { get; set; }
    }
}