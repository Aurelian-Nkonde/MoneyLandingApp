using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace moneylandingApp.Models
{
    public class Borrower
    {
        [Key]
        public int Id { get;set; }
        [Required(ErrorMessage = "First-Name-Is-Required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string? FirstName { get;set; }
        [Required(ErrorMessage = "Last-Name-Is-Required")]
        [MinLength(2)]
        [MaxLength(200)]
        public string? LastName { get;set; }
        [Required(ErrorMessage = "Email-is-Required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get;set; }
        [Required(ErrorMessage = "Phone-Number-is-Required")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get;set; }
        [Required]
        public DateOnly DateOfBirth { get;set; }
        [Required]
        [MaxLength(12)]
        [MinLength(12)]
        public string? IdentityIdNumber { get;set; }
        [Required(ErrorMessage = "City-is-Required")]
        public string? City { get;set; }
        [Required(ErrorMessage = "HouseAddress-is-Required")]
        public string? HouseAddress { get;set; }
        [Required(ErrorMessage = "CashAmount-Required")]
        public decimal CashAmount { get;set; }
        public bool Repayed { get;set; }

        [DataType(DataType.Date)]
         public DateOnly  PayingDate { get;set; }
         public bool?  Approved { get;set; }

    }
}
