using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    public class lunchList
    {
        public IPagedList<Food_recipes> Lunch { get; set; }
    }
}