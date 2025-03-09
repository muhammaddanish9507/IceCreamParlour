using System.ComponentModel.DataAnnotations;

namespace IceCreamParlour.Models
{
    public class Payments
    {
        [Key]
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "Name on card is required")]
        [Display(Name = "Name on Card")]
        public string? NameOnCard { get; set; }

        [Required(ErrorMessage = "Card number is required")]
        [CreditCard(ErrorMessage = "Invalid card number")]
        [Display(Name = "Card Number")]
        public string? CardNumber { get; set; }

        [Required(ErrorMessage = "CVV is required")]
        [StringLength(4, ErrorMessage = "CVV must be 3 or 4 digits", MinimumLength = 3)]
        public string? CVV { get; set; }

        [Required(ErrorMessage = "Expiration date is required")]
        [Display(Name = "Expiration Date")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Invalid expiration date format. Use MM/YY")]
        public string? ExpirationDate { get; set; }

    }
}
