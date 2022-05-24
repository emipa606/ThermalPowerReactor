using Verse;

namespace RimWorld;

public class NTempnuclear : Building
{
    public CompExplosive compExplosive;

    public CompPowerTrader compPowerTrader;

    public CompRefuelable compRefuelable;
    public CompTempControl compTempControl;

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);
        compTempControl = GetComp<CompTempControl>();
        compPowerTrader = GetComp<CompPowerTrader>();
        compRefuelable = GetComp<CompRefuelable>();
        compExplosive = GetComp<CompExplosive>();
    }
}