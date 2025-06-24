using Verse;

namespace RimWorld;

public class NTempnuclear : Building
{
    protected CompExplosive CompExplosive;

    protected CompPowerTrader CompPowerTrader;

    protected CompRefuelable CompRefuelable;
    protected CompTempControl CompTempControl;

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);
        CompTempControl = GetComp<CompTempControl>();
        CompPowerTrader = GetComp<CompPowerTrader>();
        CompRefuelable = GetComp<CompRefuelable>();
        CompExplosive = GetComp<CompExplosive>();
    }
}