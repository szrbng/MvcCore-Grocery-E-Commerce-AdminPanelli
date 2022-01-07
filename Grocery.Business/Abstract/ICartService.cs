using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);
        Cart GetCartByUserId(string userId);
        void AddToCart(string userId, int productId, int quantity);
        void RemoveFromCart(string userId, int productId);
        void ClearCart(string cartId);
        Cart GetCartByUserWishlistId(string userId);
        void AddToWishlist(string userId, int productId);
        void RemoveFromWishlist(string userId, int productId);
    }

}
