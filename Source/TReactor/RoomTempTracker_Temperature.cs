using HarmonyLib;
using UnityEngine;
using Verse;

namespace TReactor;

[HarmonyPatch(typeof(RoomTempTracker), "Temperature", MethodType.Setter)]
public static class RoomTempTracker_Temperature
{
    public static bool Prefix(float value, ref float ___temperatureInt)
    {
        ___temperatureInt = Mathf.Clamp(value, -273.15f, 2000f);
        return false;
    }
}