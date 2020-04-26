using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    public class breakfastList
    {
        public IPagedList<Food_recipes> Breakfasts { get; set; }
    }
}