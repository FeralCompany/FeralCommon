using System;
using System.Collections.Generic;
using System.Linq;
using FeralCommon.Utils;
using FeralCommon.Utils.Extensions;

namespace FeralCommon.Game;

public static class GameItems
{
    public static readonly List<GameItem> All = Enum.GetValues(typeof(GameItem)).OfType<GameItem>().ToList();
    public static readonly List<GameItem> Conductive = All.Where(x => x.IsConductive()).ToList();
    public static readonly List<GameItem> Weapons = All.Where(x => x.IsWeapon()).ToList();
    public static readonly List<GameItem> Tools = All.Where(x => x.IsTool()).ToList();

    public static readonly Dictionary<string, GameItem> PropertyNameToGameItem = All.ToDictionary(x => x.ToPropertyName(), x => x);

    public static GameItem? FromPropertyName(string propertyName)
    {
        if (PropertyNameToGameItem.TryGetValue(propertyName, out var value))
            return value;
        Log.Error($"No GameItem with property name: {propertyName}");
        return null;
    }

    public static GameItem? FromGrabbable(GrabbableObject obj)
    {
        return FromPropertyName(obj.itemProperties.itemName);
    }
}
