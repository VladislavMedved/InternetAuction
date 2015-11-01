using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.CustomDbInitialization
{
    public class EntityModelInitializer : DropCreateDatabaseAlways<EntityModel>
    {
        protected override void Seed(EntityModel context)
        {
            IList<Role> defaultRoles = new List<Role>();
            defaultRoles.Add(new Role() { Id = 1, Name = "Admin"});
            defaultRoles.Add(new Role() { Id = 2, Name = "User"});

            IList<User> defaultUsers = new List<User>();
            #region defaultUsers
            defaultUsers.Add(new User()
            {
                Id = 1,
                Login = "Sergei",
                E_mail = "sergei@gmail.com",
                Password = "qweasdzxc",
                Role_Id = 2,
                RegistryDate = DateTime.Now
            });
            defaultUsers.Add(new User()
            {
                Id = 2,
                Login = "Andrew",
                E_mail = "andrew@gmail.com",
                Password = "qweasdzxc",
                Role_Id = 2,
                RegistryDate = DateTime.Now
            });
            #endregion
            IList<Product> defaultProducts = new List<Product>();
            #region defaultProducts
            defaultProducts.Add(new Product()
            {
                Id = 1,
                Auction_Cost = 200,
                AuctionStart = DateTime.Now,
                AuctionEnd = DateTime.Now,
                Description = "Processor Intel8086",
                Seller_Id = 1,
                Customer_Id = 1
            });
            defaultProducts.Add(new Product()
            {
                Id = 1,
                Auction_Cost = 50,
                AuctionStart = DateTime.Now,
                AuctionEnd = new DateTime(2015,10,30,20,32,00),
                Description = "Book Bart de Smet",
                Seller_Id = 1,
                Customer_Id = 1
            });
            defaultProducts.Add(new Product()
            {
                Id = 1,
                Auction_Cost = 30,
                AuctionStart = DateTime.Now,
                AuctionEnd = new DateTime(2015, 10, 31, 15, 00, 00),
                Description = "Book Richter",
                Seller_Id = 1,
                Customer_Id = 1
            });
            defaultProducts.Add(new Product()
            {
                Id = 1,
                Auction_Cost = 30,
                AuctionStart = DateTime.Now,
                AuctionEnd = new DateTime(2015, 12, 30, 15, 00, 00),
                Description = "Car KIA RIO",
                Seller_Id = 1,
                Customer_Id = 1
            });
            defaultProducts.Add(new Product()
            {
                Id = 2,
                Auction_Cost = 10,
                AuctionStart = DateTime.Now,
                AuctionEnd = DateTime.Now,
                Description = "Processor Intel Pentium",
                Seller_Id = 1,
                Customer_Id = 1
            });
            defaultProducts.Add(new Product()
            {
                Id = 3,
                Auction_Cost = 100,
                AuctionStart = DateTime.Now,
                AuctionEnd = DateTime.Now,
                Description = "Processor Intel i3",
                Seller_Id = 1,
                Customer_Id = 1
            });

            defaultProducts.Add(new Product()
            {
                Id = 4,
                Auction_Cost = 300,
                AuctionStart = DateTime.Now,
                AuctionEnd = DateTime.Now,
                Description = "Processor Intel i7",
                Seller_Id = 1,
                Customer_Id = 1
            });
            #endregion

            foreach (var item in defaultRoles)
                context.Roles.Add(item);
            foreach (var item in defaultUsers)
                context.Users.Add(item);
            foreach (var item in defaultProducts)
                context.Products.Add(item);
            base.Seed(context);
        }
    }
}
