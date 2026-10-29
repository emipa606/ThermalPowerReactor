using System.Reflection;
using HarmonyLib;
using Verse;

namespace TReactor;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        new Harmony("Mlie.TReactor").PatchAll(Assembly.GetExecutingAssembly());
    }
}