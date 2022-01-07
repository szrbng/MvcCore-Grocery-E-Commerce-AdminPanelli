using Grocery.Business.Abstract;
using Grocery.DataAccess.Abstract;
using Grocery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Business.Concrete
{
    public class CartManager : ICartService
    {

        private readonly ICartRepository _cartRepository;
        public CartManager(ICartRepository cartRepository)
        {

            _cartRepository = cartRepository;
                
        }

        public void AddToCart(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(i => i.ProductId == productId);

                if(index < 0)
                {
                    cart.CartItems.Add(new CartItem
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id

                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                _cartRepository.Update(cart);
            }
        }

        public void AddToWishlist(string userId, int productId)
        {
            var cart = GetCartByUserWishlistId(userId);
            if (cart != null)
            {
                var index = cart.Wishlists.FindIndex(i => i.ProductId == productId);

                if (index < 0)
                {
                    cart.Wishlists.Add(new WishList()
                    {
                        ProductId = productId,
                        CartId = cart.Id
                    });
                }
                else
                {

                }

                _cartRepository.Update(cart);
            }
        }

        public void ClearCart(string cartId)
        {
            _cartRepository.ClearCart(cartId);
        }

        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetByUserId(userId);
        }

        public Cart GetCartByUserWishlistId(string userId)
        {
            return _cartRepository.GetByUserWishlsitId(userId);
        }

        public void InitializeCart(string userId)
        {
            _cartRepository.Create(new Cart() { UserId = userId });
        }

        public void RemoveFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                var cardId = cart.Id;
                _cartRepository.DeleteFromCart(cart.Id, productId);
            }
        }

        public void RemoveFromWishlist(string userId, int productId)
        {
            var cart = GetCartByUserWishlistId(userId);
            if (cart != null)
            {
                var cardId = cart.Id;
                _cartRepository.DeleteFromWishlist(cart.Id, productId);
            }
        }
    }
}
