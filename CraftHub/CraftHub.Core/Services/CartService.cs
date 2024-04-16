using CraftHub.Core.Contracts;
using CraftHub.Core.Models.Cart;
using CraftHub.Core.Models.Product;
using CraftHub.Data;
using CraftHub.Infrastructure.Data.Common;
using CraftHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repository;

        private readonly CraftHubDbContext data;

        public CartService(IRepository _repository, CraftHubDbContext _data)
        {
            repository = _repository;
            data= _data;
        }

        public async Task<string> AddToCartAsync(int productId,string userId)
        {
            var product = repository.AllReadOnly<Product>().Where(c => c.Id == productId).FirstOrDefault();

            Cart cart = new Cart()
            {
                BuyerId = userId,
                ProductId = product.Id
            };

            await repository.AddAsync(cart);
            await repository.SaveChangesAsync();

            return userId;
        }

        public async Task<string> RemoveFromCartAsync(int productId, string userId)
        {
            var product = repository.AllReadOnly<Product>().Where(c => c.Id == productId).FirstOrDefault();

            var cp = repository.AllReadOnly<Cart>()
                .FirstOrDefault(cp => cp.BuyerId == userId);


            data.Carts.Remove(cp);
            await data.SaveChangesAsync();

            return userId;
        }

        public ShopCartViewModel AllCartProducts(string userId)
        {
            var productIds = repository.AllReadOnly<Cart>().Where(c => c.BuyerId == userId)
                            .Select(c => c.ProductId)
                            .ToList();

            var productsModel = new List<ProductServiceModel>();
            decimal totalProductsPrice = 0;

            foreach (var product in repository.AllReadOnly<Product>())
            {
                if (productIds.Contains(product.Id))
                {
                    productsModel.Add(new ProductServiceModel()
                    {
                        Id = product.Id,
                        ImageUrl = product.ImageUrl,
                        Title = product.Title,
                        Price = product.Price,
                        Description = product.Description
                    });
                    totalProductsPrice += product.Price;
                }
            }
            decimal deliveryPrice = 0m;

            if (totalProductsPrice <= 90&&totalProductsPrice>0)
            {
                deliveryPrice += 5.00m;
            }

            ShopCartViewModel shopCart=new ShopCartViewModel();
            shopCart.products = productsModel;
            shopCart.Delivery= deliveryPrice;
            shopCart.TotalProductSum= totalProductsPrice;
            shopCart.TotalSum = totalProductsPrice+deliveryPrice;

            return shopCart;
        }

        public bool AlreadyAddedToCart(int productId, string userId)
        {
            return repository.AllReadOnly<Cart>()
                .Any(c => c.BuyerId == userId && c.ProductId == productId);
        }
    }
}
