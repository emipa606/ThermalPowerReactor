using System.Reflection;
using HarmonyLib;
using Verse;

namespace TReactor;

[StaticConstructorOnStartup]
public class Main
{
    static Main()
    {
        new Harmony("Mlie.TReactor").PatchAll(Assembly.GetExecutingAssembly());
    }
}