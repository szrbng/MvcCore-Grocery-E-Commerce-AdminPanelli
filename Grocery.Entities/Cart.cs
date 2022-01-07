using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<WishList> Wishlists { get; set; }
    }
}
