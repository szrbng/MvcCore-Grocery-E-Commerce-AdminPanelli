using Grocery.DataAccess.Abstract;
using Grocery.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grocery.DataAccess.Concrete.EFCore
{
    public class EfCartReposiory : EfGenericRepository<Cart, GroceryContext>, ICartRepository
    {
        public void ClearCart(string cartId)
        {
            using (var context = new GroceryContext())
            {
                var cmd = @"delete from CartItem where CartId=@p0";
                context.Database.ExecuteSqlRaw(cmd, cartId);
            }
        }

        public void DeleteFromCart(int cartId, int productId)
        {
            using (var context = new GroceryContext())
            {
                var cmd = @"delete from CartItem where CartId=@p0 And ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

        public void DeleteFromWishlist(int cartId, int productId)
        {
            using (var context = new GroceryContext())
            {
                var cmd = @"delete from Wishlist where CartId=@p0 And ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

        public Cart GetByUserId(string userId)
        {
            using (var context = new GroceryContext())
            {
                return context
                    .Carts
                    .Include(i => i.CartItems)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault(i => i.UserId == userId);
            }
        }

        public Cart GetByUserWishlsitId(string userId)
        {
            using (var context = new GroceryContext())
            {
                return context
                    .Carts
                    .Include(i => i.Wishlists)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault(i => i.UserId == userId);
            }
        }
    }
}
