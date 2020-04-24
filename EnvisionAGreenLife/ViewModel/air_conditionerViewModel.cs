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
        public IPagedList<air_conditioner> Air_Conditioners { get; set; }
    }
}