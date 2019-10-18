using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Orders.Enumerations;

namespace Orders.Data
{
    public class Order
    {
        [Key] // It knows but looks cool!.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; private set; }

        [Range(0, Int64.MaxValue, ErrorMessage = "{0} invalid value.")]
        public long OrderNumber { get; set; }

        [Range(0, Int64.MaxValue, ErrorMessage = "{0} invalid value.")]
        public long OrderRegistrationNumber { get; set; }

        [EnumDataType(typeof(OrderStatusEnum), ErrorMessage = "{0} invalid status.")]
        public OrderStatusEnum OrderStatus { get; set; } // Enum value, TODO: OrderStatus is public 

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime OrderDate { get; private set; }
    }
}