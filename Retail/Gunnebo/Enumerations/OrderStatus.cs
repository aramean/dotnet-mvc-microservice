using System;

namespace Gunnebo.Enumirations
{
    [Flags]
    public enum OrderStatusEnum
    {
        Idle = 0,
        New = 1,
        Arrived = 2
    }
}
