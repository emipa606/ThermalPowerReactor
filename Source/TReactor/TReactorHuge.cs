using UnityEngine;
using Verse;

namespace RimWorld;

public class TReactorHuge : TCP
{
    private const float HeatOutputMultiplier = 1.25f;

    private const float EfficiencyLossPerDegreeDifference = 1f / 130f;

    public override void TickRare()
    {
        if (!CompPowerPlant.PowerOn)
        {
            return;
        }

        var intVec = Position + IntVec3.South.RotatedBy(Rotation);
        var intVec2 = Position + IntVec3.North.RotatedBy(Rotation) + IntVec3.North.RotatedBy(Rotation);
        var tempChange = false;
        if (!intVec2.Impassable(Map) && !intVec.Impassable(Map))
        {
            var temperature = intVec2.GetTemperature(Map);
            var temperature2 = intVec.GetTemperature(Map);
            var num = temperature - temperature2;
            if (temperature - 1000f > num)
            {
                num = temperature - 1000f;
            }

            var num2 = 1f - (num * EfficiencyLossPerDegreeDifference);
            if (num2 < 0f)
            {
                num2 = 0f;
            }

            var num3 = compTempControl.Props.energyPerSecond * num2 * 4.1666665f;
            var num4 = GenTemperature.ControlTemperatureTempChange(intVec, Map, num3, 100f);
            tempChange = !Mathf.Approximately(num4, 0f);
            if (tempChange)
            {
                var roomGroup = intVec.GetRoom(Map);
                roomGroup.Temperature += num4;
                GenTemperature.PushHeat(intVec2, Map, (0f - num3) * 0.5f);
            }
        }

        var props = CompPowerPlant.Props;
        var num5 = intVec.GetTemperature(Map) - 100f;
        if (num5 > 1000f)
        {
            num5 = 1000f;
        }

        if (num5 < 0f)
        {
            num5 = 0f;
        }

        if (tempChange)
        {
            CompPowerPlant.PowerOutput = props.PowerConsumption * num5;
        }
        else
        {
            CompPowerPlant.PowerOutput = 0f;
        }
    }
}