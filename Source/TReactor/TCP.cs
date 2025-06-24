using Verse;

namespace RimWorld;

public class TCP : Building
{
    protected CompPowerPlant CompPowerPlant;
    protected TCC CompTempControl;

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);
        CompTempControl = GetComp<TCC>();
        CompPowerPlant = GetComp<CompPowerPlant>();
    }
}