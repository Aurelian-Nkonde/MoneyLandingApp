using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace moneylandingApp.Models
{
    public class OurBankAmount
    {
        [Key]
        public int Id { get;set; }
        [Required]
        public int Amount { get;set; } = 100;
    }
}
