using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketWebPanel.ViewModels
{
    public class FeedbackViewModels
    {
    }
    // User Rating View Models
    public class UserRatingViewModel
    {
        public UserRatingViewModel()
        {
            DeliveryMan = new DeliveryManViewModel();
        }

        public int Id { get; set; }
        public Int16 Rating { get; set; }
        public int User_ID { get; set; }
        public int Deliverer_Id { get; set; }
        public string Description { get; set; }
        public DeliveryManViewModel DeliveryMan { get; set; }
    }


    // Store Rating View Models 
    public class StoreRatingViewModel
    {
        public StoreRatingViewModel()
        {
            Store = new StoreVM();
        }
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Store_Id { get; set; }
        public int Rating { get; set; }
        public StoreVM Store { get; set; }
    }
    public class StoreVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ImageUrl { get; set; }
        public string BannerUrl { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public TimeSpan Open_From { get; set; }
        public TimeSpan Open_To { get; set; }
        public double AverageRating { get; set; }
    }

    // Deliverer Rating View Models 

    public class DeliveryManRatingViewModel
    {
        public DeliveryManRatingViewModel()
        {
            DeliveryMan = new DeliveryManViewModel();
        }
        public int Id { get; set; }
        public Int16 Rating { get; set; }
        public int User_ID { get; set; }
        public int Deliverer_Id { get; set; }
        public string Description { get; set; }
        public DeliveryManViewModel DeliveryMan { get; set; }
    }
    public class DeliveryManViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; } = "";

        public string Email { get; set; }

        public string Password { get; set; }

        public string ZipCode { get; set; }

        public string DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string ProfilePictureUrl { get; set; }

        public short SignInType { get; set; }

    }

    // Product Rating View Models 
    public class ProductRatingViewModel
    {
        public ProductRatingViewModel()
        {
            Product = new SearchProductViewModel();
        }

        public int Id { get; set; }
        public int Rating { get; set; }
        public int Product_Id { get; set; }
        public int User_ID { get; set; }
        public SearchProductViewModel Product { get; set; }
    }

    // app rating View Model

    public class AppRatingViewModel
    {
        public AppRatingViewModel()
        {
            User = new UserViewModel();
        }

        public int Id { get; set; }
        public int User_ID { get; set; }
        public short Rating { get; set; }
        public string Description { get; set; }
        public UserViewModel User { get; set; }
    }

}