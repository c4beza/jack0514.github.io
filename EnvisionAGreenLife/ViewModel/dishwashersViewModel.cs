﻿using EnvisionAGreenLife.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvisionAGreenLife.ViewModel
{
    public class DwList
    {
        public IPagedList<dishwasher> Dishwashers { get; set; }
    }
}