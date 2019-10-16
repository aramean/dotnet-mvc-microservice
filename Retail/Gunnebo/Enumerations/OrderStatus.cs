using System;
namespace Gunnebo.Enumirations
{
    [Flags] // It's here for now! 
    public enum OrderStatusEnum
    {
        Idle = 0,
        New = 1,
        Arrived = 2
    }
}
