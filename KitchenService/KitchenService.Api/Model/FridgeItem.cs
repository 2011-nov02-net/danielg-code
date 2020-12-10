using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KitchenService.Api.Model
{
    public class FridgeItem
    {
        public FridgeItem()
        {
        }

        [BindNever]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.PositiveInfinity)]
        public double WeightOz { get; set; }

        public DateTimeOffset? Expiration { get; set; }


        public bool isExpired => Expiration <= DateTime.UtcNow;
    }



}
