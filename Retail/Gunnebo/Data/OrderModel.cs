using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.Json;
using Gunnebo.Enumirations;

namespace gunnebo.Data
{
    public class Order
    {
        [Key] // It knows but looks cool!.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; private set; }

        public long OrderNumber { get; set; }

        public long OrderRegistrationNumber { get; set; }

        public OrderStatusEnum OrderStatus { get; set; } // Enum value, TODO: OrderStatus is public 

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime OrderDate { get; private set; }
    }
}