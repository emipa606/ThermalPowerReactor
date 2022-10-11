using UnityEngine;
using Verse;

namespace RimWorld;

public class NHeater : NTempnuclear
{
    private const float EfficiencyFalloffSpan = 100f;

    public static float i;

    public override void Tick()
    {
        if (!compPowerTrader.PowerOn)
        {
            return;
        }

        var ambientTemperature = AmbientTemperature;
        var num = ambientTemperature < 100f ? 1f :
            !(ambientTemperature > 2000f) ? Mathf.InverseLerp(2000f, 100f, ambientTemperature) : 0f;
        var energyLimit = compTempControl.Props.energyPerSecond * num * 4.1666665f;
        var num2 = GenTemperature.ControlTemperatureTempChange(Position, Map, energyLimit,
            compTempControl.targetTemperature);
        var operatingAtHighPower = compRefuelable.HasFuel && !Mathf.Approximately(num2, 0f);

        if (i == 0f)
        {
            i = compRefuelable.Props.fuelConsumptionRate;
        }

        var props = compPowerTrader.Props;
        if (operatingAtHighPower && compTempControl.parent.IsHashIntervalTick(60))
        {
            compRefuelable.Props.fuelConsumptionRate = i;
            var room = this.GetRoom();
            room.Temperature += num2;
            compPowerTrader.PowerOutput = 0f - props.PowerConsumption;
        }
        else if (operatingAtHighPower)
        {
            compRefuelable.Props.fuelConsumptionRate = i;
            compPowerTrader.PowerOutput = 0f - props.PowerConsumption;
        }
        else if (compTempControl.parent.IsHashIntervalTick(60))
        {
            compRefuelable.Props.fuelConsumptionRate = 0.1f;
            compPowerTrader.PowerOutput =
                (0f - props.PowerConsumption) * compTempControl.Props.lowPowerConsumptionFactor;
            var room = this.GetRoom();
            room.Temperature += num2 * (0.1f / i);
        }
        else
        {
            compRefuelable.Props.fuelConsumptionRate = 0.1f;
            compPowerTrader.PowerOutput =
                (0f - props.PowerConsumption) * compTempControl.Props.lowPowerConsumptionFactor;
        }

        compExplosive.CompTick();
        compRefuelable.CompTick();
        compTempControl.operatingAtHighPower = operatingAtHighPower;
    }
}