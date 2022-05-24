using Verse;

namespace RimWorld;

public class TCP : Building
{
    public CompPowerPlant CompPowerPlant;
    public TCC compTempControl;

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);
        compTempControl = GetComp<TCC>();
        CompPowerPlant = GetComp<CompPowerPlant>();
    }
}