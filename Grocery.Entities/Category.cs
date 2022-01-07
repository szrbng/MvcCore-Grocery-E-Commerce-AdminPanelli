using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
