﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasketWebPanel.BindingModels
{
    public class CategoryBindingModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        public string Description { get; set; } = "";

        public short Status { get; set; }

        public int Store_Id { get; set; }

        public int? ParentCategoryId { get; set; }

        public string ImageUrl { get; set; }
    }

    //public class CategoriesVM
    //{

    //    public List<CategoriesBindingModel>
    //}
}