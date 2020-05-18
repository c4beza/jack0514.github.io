using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    //logic to get the air conditioner data into a list to be displayed in the view.
    public class AcList
    {
        public IPagedList<air_conditioner> Air_Conditioners { get; set; }
    }
}