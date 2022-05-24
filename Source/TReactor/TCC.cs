using System.Text;
using Verse;

namespace RimWorld;

public class TCC : ThingComp
{
    public TR Props => (TR)props;

    public override string CompInspectStringExtra()
    {
        var stringBuilder = new StringBuilder();
        return stringBuilder.ToString();
    }
}