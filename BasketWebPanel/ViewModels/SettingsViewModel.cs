using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasketWebPanel.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public int Id { get; set; }
        
        //[Required(ErrorMessage = "This field is required")]
        //[Range(1, 10000, ErrorMessage = "Please enter a valid delivery fee")]
        //[RegularExpression(MyRegularExpressions.Price, ErrorMessage = "Please enter a valid delivery fee")]
        //public double DeliveryFee { get; set; } = 0;

        [Required]
        public string Currency { get; set; } = "";

        //[Required(ErrorMessage = "This field is required")]
        //[Range(1, 10000, ErrorMessage = "Please enter a valid price")]
        //[RegularExpression(MyRegularExpressions.Price, ErrorMessage = "Please enter a valid price")]
        //public double MinimumOrderPrice { get; set; }

        [Required]
        [StringLength(47, ErrorMessage = "Maximum 47 Characters.")]
        public string AboutUs { get; set; } = "";

        [Required]
        [StringLength(47, ErrorMessage = "Maximum 47 Characters.")]
        public string Help { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(0, 10000, ErrorMessage = "Please enter a valid price")]
        [RegularExpression(MyRegularExpressions.Price, ErrorMessage = "Please enter a valid price")]
        public double ServiceFee { get; set; }

        public int NearByRadius { get; set; }
    }
}