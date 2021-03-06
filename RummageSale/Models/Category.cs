﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RummageSale.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public bool? Electronics { get; set; }
        public bool? Furniture { get; set; }
        public bool? Toys { get; set; }
        public bool? Clothings { get; set; }
        [Display(Name = "Personal Care")]
        public bool? PersonalCare { get; set; }
        public bool? Media { get; set; }
        [ForeignKey("SaleId")]
        public string SaleId { get; set; }
        public Sale Sale { get; set; }


    }
}
