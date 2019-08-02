using BasketWebPanel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasketWebPanel.ViewModels
{
    public class SearchUserViewModel : BaseViewModel
    {
        public SearchUserViewModel()
        {
            Users = new List<UserBindingModel>();
        }

        public List<UserBindingModel> Users { get; set; }

        public SelectList StatusOptions { get; internal set; }
    }

    public class UserBindingModel : BaseViewModel
    {
        public UserBindingModel()
        {
            UserAddresses = new List<UserAddressBindingModel>();
            PaymentCards = new List<UserPaymentCardBindingModel>();
            Favourites = new List<Favourites>();
            Orders = new List<OrderViewModel>();


        }

        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string FullName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        
        public string AccountType { get; set; }

        public string ZipCode { get; set; }

        public string DateofBirth { get; set; }

        public short? SignInType { get; set; }

        public string UserName { get; set; }

        public short? Status { get; set; }

        public bool EmailConfirmed { get; set; }


        public bool PhoneConfirmed { get; set; }

        public bool IsDeleted { get; set; }

        public string StatusName { get; set; }

        public bool IsChecked { get; set; }

        public List<OrderViewModel> Orders { get; set; }

        public List<UserAddressBindingModel> UserAddresses;

        public List<UserPaymentCardBindingModel> PaymentCards { get; set; }

        public List<Favourites> Favourites { get; set; }

        public List<UserRatingViewModel> UserRatings { get; set; }

        public List<StoreRatingViewModel> StoreRatings { get; set; }

        public List<DeliveryManRatingViewModel> DeliveryManRatings { get; set; }

        public List<ProductRatingViewModel> ProductRatings { get; set; }

        public List<AppRatingViewModel> AppRatings { get; set; }
        
        
    }

    public class UserPaymentCardBindingModel
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string CCV { get; set; }
        
        public string NameOnCard { get; set; }
        
        public int CardType { get; set; } //1 for Credit, 2 for Debit

        public int User_ID { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class UserAddressBindingModel
    {
        public int Id { get; set; }

        public int User_ID { get; set; }
        
        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string StreetName { get; set; }

        public string Floor { get; set; }

        public string Apartment { get; set; }
        
        public string NearestLandmark { get; set; }

        public string BuildingName { get; set; }
        
        public short Type { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsPrimary { get; set; }
    }

    public class DelivererBindingModel : BaseViewModel
    {
        public DelivererBindingModel()
        {
            UserAddresses = new List<UserAddressBindingModel>();
            AvailibilitySchedules = new HashSet<DeliveryMan_AvailibilityScheduleBindingModel>();
        }

        public int Id { get; set; }
        
        public string FullName { get; set; }

        public string Address { get; set; } = "";
        
        public string Email { get; set; }

        public string ZipCode { get; set; }

        public string DateOfBirth { get; set; }
        
        public string Phone { get; set; }

        public string ProfilePictureUrl { get; set; }
        
        public bool IsOnline { get; set; }
        public short? Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneConfirmed { get; set; }
        

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public DbGeography Location { get; set; }

        public short Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryMan_AvailibilityScheduleBindingModel> AvailibilitySchedules { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsNotificationsOn { get; set; }

        public List<UserAddressBindingModel> UserAddresses;

    }

    public class DeliveryMan_AvailibilityScheduleBindingModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsDeleted { get; set; }

        public int DeliveryMan_Id { get; set; }
    }

    public class Favourites
    {
        public Favourites()
        {
            Product = new SearchProductViewModel();
        }

        public int Id { get; set; }

        public int Product_Id { get; set; }

        public int User_ID { get; set; }

        public Boolean IsDeleted { get; set; }

        public SearchProductViewModel Product { get; set; }
    }

    public class OrderViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string OrderNo { get; set; }

        public int Status { get; set; }

        public DateTime OrderDateTime { get; set; }

        public DateTime DeliveryTime_From { get; set; }

        public DateTime DeliveryTime_To { get; set; }

        public string AdditionalNote { get; set; }

        public int PaymentMethod { get; set; }

        public string PaymentMethodName { get; set; }
        
        public double Subtotal { get; set; }

        public double ServiceFee { get; set; }

        public double DeliveryFee { get; set; }

        public double Total { get; set; }

        public int User_ID { get; set; }

        public bool IsDeleted { get; set; }

        public int? OrderPayment_Id { get; set; }

        public short PaymentStatus { get; set; }

        public string PaymentStatusName { get; set; }

        public string DeliveryAddress { get; set; }

        public virtual OrderPaymentViewModel OrderPayment { get; set; }

        public virtual ICollection<StoreOrderViewModel> StoreOrders { get; set; }

        public virtual UserViewModel User { get; set; }

    }

    public class OrderPaymentViewModel
    {
        public int Id { get; set; }

        public string Amount { get; set; }

        public string PaymentType { get; set; }

        public string CashCollected { get; set; }

        public string Status { get; set; }

        public string Order_Id { get; set; }

        public string AccountNo { get; set; }

        public int? DeliveryMan_Id { get; set; }

        public int Application_Id { get; set; }
    }
    public class Feedback
    {


    }

    public class StoreOrderViewModel
    {
        public StoreOrderViewModel()
        {
            OrderItems = new List<OrderItemViewModel>();
        }
        public int Id { get; set; }

        public string OrderNo { get; set; }

        public int Status { get; set; }

        public int Store_Id { get; set; }

        public double Subtotal { get; set; }

        public double Total { get; set; }

        public bool IsDeleted { get; set; }

        public int Order_Id { get; set; }

        public string StoreName { get; set; }

        public string ImageUrl { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }
    }

    public class OrderItemViewModel
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public int Qty { get; set; }

        public int StoreOrder_Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Weight { get; set; }

        public double WeightInGrams { get; set; }

        public double WeightInKiloGrams { get; set; }

        public string ImageUrl { get; set; }
        public bool IsFavourite { get; internal set; }
    }
}