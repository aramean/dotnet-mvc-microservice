using System;

namespace Gunnebo.Enumerations

{
    [Flags]
    public enum OrderStatusEnum
    {
        None = 0,
        Idle = 1,
        New = 2,
        Arrived = 3
    }
}
