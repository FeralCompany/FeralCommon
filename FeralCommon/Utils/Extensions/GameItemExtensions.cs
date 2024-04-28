using FeralCommon.Game;
using JetBrains.Annotations;

namespace FeralCommon.Utils.Extensions;

public static class GameItemExtensions
{
    [UsedImplicitly]
    public static string ToPropertyName(this GameItem item)
    {
        return item switch
        {
            GameItem.AirHorn => "Airhorn",
            GameItem.BeeHive => "Hive",
            GameItem.BigBolt => "Big bolt",
            GameItem.BrassBell => "Brass bell",
            GameItem.CashRegister => "Cash register",
            GameItem.ChemicalJug => "Chemical jug",
            GameItem.ClownHorn => "Clown horn",
            GameItem.CoffeeMug => "Coffee mug",
            GameItem.ComedyMask => "Comedy",
            GameItem.CookieSheet => "Cookie mold pan",
            GameItem.CubeToy => "Toy cube",
            GameItem.DustPan => "Dust pan",
            GameItem.EasterEgg => "Easter egg",
            GameItem.EggBeater => "Egg beater",
            GameItem.Engine => "V-type engine",
            GameItem.ExtensionLadder => "Extension Ladder",
            GameItem.FancyLamp => "Fancy lamp",
            GameItem.Flashbang => "Homemade flashbang",
            GameItem.GiftBox => "Gift",
            GameItem.GoldBar => "Gold bar",
            GameItem.GoldenCup => "Golden cup",
            GameItem.HairBrush => "Hair brush",
            GameItem.HairDryer => "Hairdryer",
            GameItem.KitchenKnife => "Kitchen knife",
            GameItem.LargeAxle => "Large axle",
            GameItem.LaserPointer => "Laser pointer",
            GameItem.LockPicker => "Lockpicker",
            GameItem.MagicSevenBall => "Magic 7 ball",
            GameItem.MagnifyingGlass => "Magnifying glass",
            GameItem.MetalSheet => "Metal sheet",
            GameItem.OldPhone => "Old phone",
            GameItem.Perfume => "Perfume bottle",
            GameItem.PickleJar => "Jar of pickles",
            GameItem.Pills => "Pill bottle",
            GameItem.PlasticFish => "Plastic fish",
            GameItem.PlayerBody => "Player Body",
            GameItem.ProFlashlight => "Pro-Flashlight",
            GameItem.RadarBooster => "Radar-Booster",
            GameItem.RobotToy => "Robot toy",
            GameItem.RubberDucky => "Rubber Ducky",
            GameItem.Shotgun => "Double-barrel",
            GameItem.ShotgunShell => "Ammo",
            GameItem.SodaCan => "Red soda",
            GameItem.SprayPaint => "Spray Paint",
            GameItem.SteeringWheel => "Steering wheel",
            GameItem.StopSign => "Stop sign",
            GameItem.StunGrenade => "Stun Grenade",
            GameItem.TeaKettle => "Tea kettle",
            GameItem.TragedyMask => "Tragedy",
            GameItem.TzpInhalant => "TZP-Inhalant",
            GameItem.WalkieTalkie => "Walkie-Talkie",
            GameItem.WhoopieCushion => "Whoopie-Cushion",
            GameItem.YieldSign => "Yield sign",
            GameItem.ZapGun => "Zap Gun",
            _ => item.ToString()
        };
    }

    [UsedImplicitly]
    public static bool IsConductive(this GameItem item)
    {
        return item switch
        {
            GameItem.Apparatus => true,
            GameItem.BeeHive => true,
            GameItem.BigBolt => true,
            GameItem.BrassBell => true,
            GameItem.CashRegister => true,
            GameItem.ClownHorn => true,
            GameItem.EggBeater => true,
            GameItem.Engine => true,
            GameItem.ExtensionLadder => true,
            GameItem.FancyLamp => true,
            GameItem.Flask => true,
            GameItem.GoldBar => true,
            GameItem.Jetpack => true,
            GameItem.KitchenKnife => true,
            GameItem.LargeAxle => true,
            GameItem.MetalSheet => true,
            GameItem.RadarBooster => true,
            GameItem.Ring => true,
            GameItem.RobotToy => true,
            GameItem.Shovel => true,
            GameItem.SodaCan => true,
            GameItem.StopSign => true,
            GameItem.TeaKettle => true,
            GameItem.TzpInhalant => true,
            GameItem.YieldSign => true,
            GameItem.ZapGun => true,
            _ => false
        };
    }

    [UsedImplicitly]
    public static bool IsWeapon(this GameItem item)
    {
        return item switch
        {
            GameItem.EasterEgg => true,
            GameItem.Flashbang => true,
            GameItem.KitchenKnife => true,
            GameItem.Shotgun => true,
            GameItem.ShotgunShell => true,
            GameItem.Shovel => true,
            GameItem.StopSign => true,
            GameItem.StunGrenade => true,
            GameItem.YieldSign => true,
            GameItem.ZapGun => true,
            _ => false
        };
    }

    [UsedImplicitly]
    public static bool IsTool(this GameItem item)
    {
        return item switch
        {
            GameItem.Key => true,
            GameItem.LockPicker => true,
            GameItem.Boombox => true,
            GameItem.ExtensionLadder => true,
            GameItem.Flashlight => true,
            GameItem.Jetpack => true,
            GameItem.ProFlashlight => true,
            GameItem.RadarBooster => true,
            GameItem.SprayPaint => true,
            GameItem.TzpInhalant => true,
            GameItem.WalkieTalkie => true,
            _ => false
        };
    }
}
