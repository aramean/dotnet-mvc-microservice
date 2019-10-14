using System;
namespace Gunnebo.Enumirations
{
    [Flags] // It's here for now! 
    public enum OrderStatusEnum
    {
        Idle = -1,
        New = 0,
        Arrived = 1
    }
}
