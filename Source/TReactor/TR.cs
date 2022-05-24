using Verse;

namespace RimWorld;

public class TR : CompProperties
{
    public float energyPerSecond = 12f;

    public TR()
    {
        compClass = typeof(TCC);
    }
}