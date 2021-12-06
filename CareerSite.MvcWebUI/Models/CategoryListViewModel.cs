﻿using CareerSite.Entities.Concrete;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace CareerSite.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; internal set; }
        public int CurrentCategory { get; internal set; }
    }
}