﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LILAPICourse.Model
{
    public abstract class ProductModelBase
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
    public class ProductViewModel: ProductModelBase
    {
        public Guid Id { get; set; }
        public string CategoryName { get; internal set; }
    }
    public class ProductCreateModel : ProductModelBase
    {
    }
    public class ProductUpdateModel : ProductModelBase
    {
        [Required]
        public Guid Id { get; set; }
    }
}
