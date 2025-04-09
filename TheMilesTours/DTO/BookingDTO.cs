using System.ComponentModel.DataAnnotations;

namespace TheMilesTours.DTO
{
    public class BookingDTO
    {
       
            [Required(ErrorMessage = "Name is required")]
            [Display(Name = "Your Name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            [Display(Name = "Your Email Address")]
            public string Email { get; set; }

            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Date is required")]
            [DataType(DataType.Date)]
            [Display(Name = "Booking Date")]
            public DateTime BookingDate { get; set; } = DateTime.Today;

         
            [Required(ErrorMessage = "Payment method is required")]
            [Display(Name = "Payment Method")]
            public string PaymentMethod { get; set; }
        }
}
