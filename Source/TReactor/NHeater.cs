using UnityEngine;
using Verse;

namespace RimWorld;

public class NHeater : NTempnuclear
{
    private const float EfficiencyFalloffSpan = 100f;

    private static float i;

    protected override void Tick()
    {
        if (!CompPowerTrader.PowerOn)
        {
            return;
        }

        var ambientTemperature = AmbientTemperature;
        float num;
        if (ambientTemperature < EfficiencyFalloffSpan)
        {
            num = 1f;
        }
        else
        {
            num = !(ambientTemperature > 2000f)
                ? Mathf.InverseLerp(2000f, EfficiencyFalloffSpan, ambientTemperature)
                : 0f;
        }

        var energyLimit = CompTempControl.Props.energyPerSecond * num * 4.1666665f;
        var num2 = GenTemperature.ControlTemperatureTempChange(Position, Map, energyLimit,
            CompTempControl.targetTemperature);
        var operatingAtHighPower = CompRefuelable.HasFuel && !Mathf.Approximately(num2, 0f);

        if (i == 0f)
        {
            i = CompRefuelable.Props.fuelConsumptionRate;
        }

        var props = CompPowerTrader.Props;
        switch (operatingAtHighPower)
        {
            case true when CompTempControl.parent.IsHashIntervalTick(60):
            {
                CompRefuelable.Props.fuelConsumptionRate = i;
                var room = this.GetRoom();
                room.Temperature += num2;
                CompPowerTrader.PowerOutput = 0f - props.PowerConsumption;
                break;
            }
            case true:
                CompRefuelable.Props.fuelConsumptionRate = i;
                CompPowerTrader.PowerOutput = 0f - props.PowerConsumption;
                break;
            default:
            {
                if (CompTempControl.parent.IsHashIntervalTick(60))
                {
                    CompRefuelable.Props.fuelConsumptionRate = 0.1f;
                    CompPowerTrader.PowerOutput =
                        (0f - props.PowerConsumption) * CompTempControl.Props.lowPowerConsumptionFactor;
                    var room = this.GetRoom();
                    room.Temperature += num2 * (0.1f / i);
                }
                else
                {
                    CompRefuelable.Props.fuelConsumptionRate = 0.1f;
                    CompPowerTrader.PowerOutput =
                        (0f - props.PowerConsumption) * CompTempControl.Props.lowPowerConsumptionFactor;
                }

                break;
            }
        }

        CompExplosive.CompTick();
        CompRefuelable.CompTick();
        CompTempControl.operatingAtHighPower = operatingAtHighPower;
    }
}