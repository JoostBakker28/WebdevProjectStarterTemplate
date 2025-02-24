﻿using System.ComponentModel.DataAnnotations;

namespace WebdevProjectStarterTemplate.Models
{
    public class Order
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public int TableID { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int AmountPaid { get; set; } = 0;
        public int AmountWantsToPay { get; set; }
    }
}
