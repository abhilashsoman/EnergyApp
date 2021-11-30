using System;
using System.ComponentModel.DataAnnotations;


namespace API.Entities
{
    public class EnergyUsage
    {
        public int Id { get; set; }
         [Required]
        public DateTime InputDate { get; set; } 
         [Required]
        public String EnergyType { get; set; }
        [Required]
        public int Price { get; set; }

    }
}