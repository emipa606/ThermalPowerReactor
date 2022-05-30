using HarmonyLib;
using RimWorld;
using UnityEngine;

namespace TReactor;

[HarmonyPatch(typeof(CompTempControl), "InterfaceChangeTargetTemperature", typeof(float))]
public static class CompTempControl_InterfaceChangeTargetTemperature
{
    public static void Prefix(float ___targetTemperature, out float __state)
    {
        __state = ___targetTemperature;
    }

    public static void Postfix(float offset, ref float ___targetTemperature, float __state)
    {
        ___targetTemperature = __state + offset;
        ___targetTemperature = Mathf.Clamp(___targetTemperature, -273.15f, 2000f);
    }
}