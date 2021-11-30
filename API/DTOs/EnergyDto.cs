using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class EnergyDto
    {
        public DateTime DateEntered { get; set; } 
        public String EnergyType { get; set; }
        public int Price{get; set;}
        public decimal PriceAfterDiscount{get; set;}  
 
    }
}