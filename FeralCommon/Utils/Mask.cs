using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace FeralCommon.Utils;

[UsedImplicitly]
public class Mask(int value)
{
    public static readonly Mask Default = new(1 << 0);
    public static readonly Mask TransparentFX = new(1 << 1);
    public static readonly Mask IgnoreRaycast = new(1 << 2);
    public static readonly Mask Player = new(1 << 3);
    public static readonly Mask Water = new(1 << 4);
    public static readonly Mask UI = new(1 << 5);
    public static readonly Mask Props = new(1 << 6);
    public static readonly Mask HelmetVisor = new(1 << 7);
    public static readonly Mask Room = new(1 << 8);
    public static readonly Mask InteractableObject = new(1 << 9);
    public static readonly Mask Foliage = new(1 << 10);
    public static readonly Mask Colliders = new(1 << 11);
    public static readonly Mask PhysicsObject = new(1 << 12);
    public static readonly Mask Triggers = new(1 << 13);
    public static readonly Mask MapRadar = new(1 << 14);
    public static readonly Mask NavigationSurface = new(1 << 15);
    public static readonly Mask RoomLight = new(1 << 16);
    public static readonly Mask Anomaly = new(1 << 17);
    public static readonly Mask LineOfSight = new(1 << 18);
    public static readonly Mask Enemies = new(1 << 19);
    public static readonly Mask PlayerRagdoll = new(1 << 20);
    public static readonly Mask MapHazards = new(1 << 21);
    public static readonly Mask ScanNode = new(1 << 22);
    public static readonly Mask EnemiesNotRendered = new(1 << 23);
    public static readonly Mask MiscLevelGeometry = new(1 << 24);
    public static readonly Mask Terrain = new(1 << 25);
    public static readonly Mask PlaceableShipObjects = new(1 << 26);
    public static readonly Mask PlacementBlocker = new(1 << 27);
    public static readonly Mask Railing = new(1 << 28);
    public static readonly Mask DecalStickableSurface = new(1 << 29);
    public static readonly Mask Unused1 = new(1 << 30);
    public static readonly Mask Unused2 = new(1 << 31);

    private int Value { get; } = value;

    [UsedImplicitly]
    public bool Contains(Mask mask)
    {
        return (this & mask) != 0;
    }

    [UsedImplicitly]
    public bool ContainsAny(params Mask[] masks)
    {
        return masks.Any(m => (this & m) != 0);
    }

    [UsedImplicitly]
    public Mask Add(params Mask[] masks)
    {
        return masks.Aggregate(this, (current, m) => current | m);
    }

    [UsedImplicitly]
    public Mask Remove(params Mask[] masks)
    {
        return masks.Aggregate(this, (current, m) => current & ~m);
    }

    [UsedImplicitly]
    public string[] Extract()
    {
        var masks = new List<string>();
        if (Contains(Default)) masks.Add(nameof(Default));
        if (Contains(TransparentFX)) masks.Add(nameof(TransparentFX));
        if (Contains(IgnoreRaycast)) masks.Add(nameof(IgnoreRaycast));
        if (Contains(Player)) masks.Add(nameof(Player));
        if (Contains(Water)) masks.Add(nameof(Water));
        if (Contains(UI)) masks.Add(nameof(UI));
        if (Contains(Props)) masks.Add(nameof(Props));
        if (Contains(HelmetVisor)) masks.Add(nameof(HelmetVisor));
        if (Contains(Room)) masks.Add(nameof(Room));
        if (Contains(InteractableObject)) masks.Add(nameof(InteractableObject));
        if (Contains(Foliage)) masks.Add(nameof(Foliage));
        if (Contains(Colliders)) masks.Add(nameof(Colliders));
        if (Contains(PhysicsObject)) masks.Add(nameof(PhysicsObject));
        if (Contains(Triggers)) masks.Add(nameof(Triggers));
        if (Contains(MapRadar)) masks.Add(nameof(MapRadar));
        if (Contains(NavigationSurface)) masks.Add(nameof(NavigationSurface));
        if (Contains(RoomLight)) masks.Add(nameof(RoomLight));
        if (Contains(Anomaly)) masks.Add(nameof(Anomaly));
        if (Contains(LineOfSight)) masks.Add(nameof(LineOfSight));
        if (Contains(Enemies)) masks.Add(nameof(Enemies));
        if (Contains(PlayerRagdoll)) masks.Add(nameof(PlayerRagdoll));
        if (Contains(MapHazards)) masks.Add(nameof(MapHazards));
        if (Contains(ScanNode)) masks.Add(nameof(ScanNode));
        if (Contains(EnemiesNotRendered)) masks.Add(nameof(EnemiesNotRendered));
        if (Contains(MiscLevelGeometry)) masks.Add(nameof(MiscLevelGeometry));
        if (Contains(Terrain)) masks.Add(nameof(Terrain));
        if (Contains(PlaceableShipObjects)) masks.Add(nameof(PlaceableShipObjects));
        if (Contains(PlacementBlocker)) masks.Add(nameof(PlacementBlocker));
        if (Contains(Railing)) masks.Add(nameof(Railing));
        if (Contains(DecalStickableSurface)) masks.Add(nameof(DecalStickableSurface));
        if (Contains(Unused1)) masks.Add(nameof(Unused1));
        if (Contains(Unused2)) masks.Add(nameof(Unused2));
        return masks.ToArray();
    }

    [UsedImplicitly]
    public static Mask Combine(params Mask[] masks)
    {
        return masks.Aggregate(0, (current, m) => current | m);
    }

    public static implicit operator int(Mask mask)
    {
        return mask.Value;
    }

    public static implicit operator Mask(int value)
    {
        return new Mask(value);
    }
}
