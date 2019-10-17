using System;

namespace Gunnebo.Enumirations
{
    [Flags]
    public enum OrderStatusEnum
    {
        Idle = 1,
        New = 2,
        Arrived = 3
    }
}
