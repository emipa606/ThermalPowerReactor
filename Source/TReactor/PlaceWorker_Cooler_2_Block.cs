using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace RimWorld;

public class PlaceWorker_Cooler_2_Block : PlaceWorker
{
    public override void DrawGhost(ThingDef def, IntVec3 center, Rot4 rot, Color ghostCol, Thing thing = null)
    {
        var currentMap = Find.CurrentMap;
        var intVec = center + IntVec3.South.RotatedBy(rot);
        var intVec2 = center + IntVec3.North.RotatedBy(rot) + IntVec3.North.RotatedBy(rot);
        GenDraw.DrawFieldEdges(new List<IntVec3> { intVec }, GenTemperature.ColorSpotCold);
        GenDraw.DrawFieldEdges(new List<IntVec3> { intVec2 }, GenTemperature.ColorSpotHot);
        var roomOne = intVec2.GetRoom(currentMap);
        var roomTwo = intVec.GetRoom(currentMap);
        if (roomOne == null || roomTwo == null)
        {
            return;
        }

        if (roomOne == roomTwo && !roomOne.UsesOutdoorTemperature)
        {
            GenDraw.DrawFieldEdges(roomOne.Cells.ToList(), new Color(1f, 0.7f, 0f, 0.5f));
            return;
        }

        if (!roomOne.UsesOutdoorTemperature)
        {
            GenDraw.DrawFieldEdges(roomOne.Cells.ToList(), GenTemperature.ColorRoomHot);
        }

        if (!roomTwo.UsesOutdoorTemperature)
        {
            GenDraw.DrawFieldEdges(roomTwo.Cells.ToList(), GenTemperature.ColorRoomCold);
        }
    }

    public override AcceptanceReport AllowsPlacing(BuildableDef def, IntVec3 center, Rot4 rot, Map map,
        Thing thingToIgnore = null,
        Thing thing = null)
    {
        var c = center + IntVec3.South.RotatedBy(rot) + IntVec3.South.RotatedBy(rot);
        var c2 = center + IntVec3.North.RotatedBy(rot);
        if (c.Impassable(map) || c2.Impassable(map))
        {
            return "MustPlaceCoolerWithFreeSpaces".Translate();
        }

        return true;
    }
}