using System;
namespace KitchenService.Api.Model
{
    public class Appliance: IAppliance
    {
        public Appliance()
        {
        }

        public int ID { get; set; }

        public string Name { get; set; }
    }
}
