using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project_0
{
    public class Orders
    {
        [Key]
        public int orderID {get; set;}
        [Required]
        public Store stroeLocation {get ; set;}
        [Required]
        public Customer customer {get; set;}
        public double total {get; set;}
        [Required,DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dateTime {get; set;}

        public override string ToString()
        {
            return $"Ordered at {stroeLocation.Id}\nTotal was {total}\nat {dateTime}";
        }
    }
}