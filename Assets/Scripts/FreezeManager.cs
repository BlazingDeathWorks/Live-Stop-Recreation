using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal static class FreezeManager
{
    public static float FreezeTimer { get; private set; } = 1;
    public static bool TimeStopped { get; private set; }

    public static void FreezeTime()
    {
        TimeStopped = !TimeStopped;
        if (TimeStopped) FreezeTimer = 0;
        else FreezeTimer = 1;
    }
}
