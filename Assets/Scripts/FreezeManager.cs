using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class FreezeManager : MonoBehaviour
{
    public static float FreezeTimer { get; private set; } = 1;
    public static bool TimeStopped { get; private set; }

    private void Awake()
    {
        FreezeTimer = 1;
        TimeStopped = false;
    }

    public static void FreezeTime()
    {
        TimeStopped = !TimeStopped;
        if (TimeStopped) FreezeTimer = 0;
        else FreezeTimer = 1;
    }
}
