namespace Cooldown_Usage_Comparator.Data;

public class SpellRepository
{
    public readonly Dictionary<AbilityGameId, Spell> Spells = new()
    {
        // Death Knight
        // { AbilityGameId.VampiricSpeedBuff, new Spell(434029, "Vampiric Speed", null)}, 
        
        // Mage
        { AbilityGameId.FireballSpell, new Spell(133, "Fireball", "spell_fire_flamebolt.jpg") },
        { AbilityGameId.FlamestrikeSpell, new Spell(2120, "Flamestrike", "spell_fire_selfdestruct.jpg") },
        { AbilityGameId.Counterspell, new Spell(2139, "Counterspell", "spell_frost_iceshock.jpg") },
        { AbilityGameId.ScorchSpell, new Spell(2948, "Scorch", "spell_fire_soulburn.jpg") },
        { AbilityGameId.PyroblastSpell, new Spell(11366, "Pyroblast", "spell_fire_fireball02.jpg")},
        // { AbilityGameId.IgniteDebuff, new Spell(12654, "Ignite", null)},
        // { AbilityGameId.LivingBombSpell, new Spell(44461, "Living Bomb", null)},
        // { AbilityGameId.HeatingUpBuff, new Spell(48107, "Heating Up", null)},
        // { AbilityGameId.HotStreakBuff, new Spell(48108, "Hot Streak!", null)},
        { AbilityGameId.MirrorImageSpell, new Spell(55342, "Mirror Image", "spell_magic_lesserinvisibilty.jpg")},
        { AbilityGameId.CauterizeSpell, new Spell(86949, "Cauterize", "spell_fire_rune.jpg")},
        { AbilityGameId.FireBlastSpell, new Spell(108853, "Fire Blast", "spell_fire_fireball.jpg")},
        { AbilityGameId.CombustionSpell, new Spell(190319, "Combustion", "spell_fire_sealoffire.jpg")},
        { AbilityGameId.ShimmerSpell, new Spell(212653, "Shimmer", "spell_arcane_massdispel")},
        // { AbilityGameId.LivingBombDebuff, new Spell(217694, "Living Bomb", null)},
        { AbilityGameId.BlazingBarrierSpell, new Spell(235313, "Blazing Barrier", "ability_mage_moltenarmor.jpg")},
        // { AbilityGameId.FreneticSpeedBuff, new Spell(236060, "Frenetic Speed", null)}, 
        // { AbilityGameId.LivingBombDebuff2, new Spell(244813, "Living Bomb", null)},
        { AbilityGameId.PhoenixFlamesSpell, new Spell(257541, "Phoenix Flames", "artifactability_firemage_phoenixbolt.jpg")},
        // { AbilityGameId.PhoenixFlamesDamage, new Spell(257542, "Phoenix Flames", null)},
        { AbilityGameId.AlterTimeSpell, new Spell(342245, "Alter Time", "spell_mage_altertime.jpg")},
        { AbilityGameId.ShiftingPowerSpell, new Spell(382440, "Shifting Power", "inv_ability_mage_shiftingpower.jpg")},
        // { AbilityGameId.ShiftingPowerSpell2, new Spell(382445, "Shifting Power", null)},
        // { AbilityGameId.FeelTheBurnBuff, new Spell(383395, "Feel the Burn", null)}, 
        // { AbilityGameId.WildfireBuff, new Spell(383492, "Wildfire", null)},
        // { AbilityGameId.WildfireBuffStack, new Spell(383493, "Wildfire", null)},
        // { AbilityGameId.FieryRushBuff, new Spell(383637, "Fiery Rush", null)},
        // { AbilityGameId.FeveredIncantationBuffStack, new Spell(383811, "Fevered Incantation", null)},
        // { AbilityGameId.HyperthermiaBuff, new Spell(383874, "Hyperthermia", null)},
        // { AbilityGameId.TemporalVelocityBuff, new Spell(384360, "Temporal Velocity", null)},
        // { AbilityGameId.OverflowingEnergyBuff, new Spell(394195, "Overflowing Energy", null)},
        { AbilityGameId.MassBarrierSpell, new Spell(414660, "Mass Barrier", "ability_racial_magicalresistance.jpg")},
        // { AbilityGameId.BlazingBarrierBuff, new Spell(414662, "Blazing Barrier", null)},
        // { AbilityGameId.IntensifyingFlameBuff, new Spell(419800, "Intensifying Flame", null)}, 
        // { AbilityGameId.SpellfireSphereBuffStack, new Spell(448604, "Spellfire Sphere", null)},
        // { AbilityGameId.ArcanePhoenixBuff, new Spell(448659, "Arcane Phoenix", null)},
        // { AbilityGameId.ManaCascadeBuffStack, new Spell(449314, "Mana Cascade", null)},
        // { AbilityGameId.MerelyASetbackBuff, new Spell(449331, "Merely a Setback", null)},
        // { AbilityGameId.SpellfireSpheresBuffStack, new Spell(449400, "Spellfire Spheres", null)},
        // { AbilityGameId.MeteoriteDamage, new Spell(449569, "Meteorite", null)},
        // { AbilityGameId.GreaterPyroblastSpell, new Spell(450421, "Greater Pyroblast", null)},
        { AbilityGameId.PyroblastDamage, new Spell(450461, "Pyroblast", null)},
        // { AbilityGameId.FlamestrikeDamage, new Spell(450462, "Flamestrike", null)},
        // { AbilityGameId.ArcaneBarrageSpell, new Spell(450499, "Arcane Barrage", null)},
        // { AbilityGameId.BurdenOfPowerBuff, new Spell(451049, "Burden of Power", null)},
        // { AbilityGameId.GloriousIncandescenceBuff, new Spell(451073, "Glorious Incandescence", null)},
        // { AbilityGameId.LitFuseBuff, new Spell(453207, "Lit Fuse", null)},
        // { AbilityGameId.LivingBombDamage, new Spell(453251, "Living Bomb", null)},
        // { AbilityGameId.ControlledDestructionDebuff, new Spell(453268, "Controlled Destruction", null)},
        // { AbilityGameId.ArcaneSurgeSpell, new Spell(453326, "Arcane Surge", null)},
        // { AbilityGameId.FiresIreBuff, new Spell(453385, "Fire's Ire", null)},
        // { AbilityGameId.MeteoriteSpell, new Spell(456139, "Meteorite", null)},
        // { AbilityGameId.LingeringEmbersBuffStack, new Spell(461145, "Lingering Embers", null)},
        // { AbilityGameId.RollinHotBuff, new Spell(1219035, "Rollin' Hot", null)},
        // { AbilityGameId.PhoenixRebornBuffStack, new Spell(1219304, "Phoenix Reborn", null)},
        // { AbilityGameId.PhoenixRebornBuff, new Spell(1219305, "Phoenix Reborn", null)},
        
        // Shaman
        // { AbilityGameId.HealingRainSpell, new Spell(73921, "Healing Rain", null)},
        // { AbilityGameId.WindRushBuff, new Spell(192082, "Wind Rush", null)},
    };
}

public enum AbilityGameId
{
    // Error
    // Error = -1,
    
    Death = 0,
    
    // Unknown
    Unknown = 1,
    WordOfMassRecall = 3, // ??
    
    
    // Misc
    // Weapon Enchant TWW
    AuthorityOfRadiantPowerBuff  = 448730, 
    AuthorityOfRadiantPowerDamage = 448744, 
    AuthorityOfFieryResolve = 449209, 
    
    // TWW M+
    VoidPulsar     = 1216858, 
    VoidPulsarBuff = 1216943, 
    
    // Trinkets
    BurinOfTheCandleKing = 443529, // ??
    WaxWard = 451924, // ??
    HypedBuff = 1216212,
    
    // Isle of Dorn Gems
    OldSaltsBardicCitrine  = 462959, 
    MarinerHallowedCitrine = 462960, 
    
    // Rookery
    BoundingVoidSpell     =  426893,
    LocalizedStormSpell   =  427439, 
    EnergizedBarrageSpell =  427616, 
    LightningBoltSpell    =  430109, 
    EntropyShieldSpell    =  450628, 
    LightningTorrentSpell = 1214323, 
    CrashingThunderSpell  = 1214324, 
    CrashingThunderSpell2 = 1214326,
    
    // Common
    DevotionAuraBuff         =    465,
    ArcaneIntellectBuff      =   1459,
    BloodlustBuff            =   2825, 
    SatedDebuff              =  57724, 
    LeechHeal                = 143924, 
    TimeWarpBuff             = 342242, 
    FlightStyleSkyridingBuff = 404464, 
    SkyfuryBuff              = 462854, 
    
    // Death Knight
    BlindingSleetDebuff = 207167, 
    VampiricSpeedBuff   = 434029,
    
    // Mage
    FireballSpell               =     133,
    FlamestrikeSpell            =    2120,
    Counterspell                =    2139,
    ScorchSpell                 =    2948,
    PyroblastSpell              =   11366,
    IgniteDebuff                =   12654, 
    HypothermiaDebuff           =   41425, 
    LivingBombSpell             =   44461, 
    HeatingUpBuff               =   48107,
    HotStreakBuff               =   48108, 
    MirrorImageSpell            =   55342, 
    CauterizeSpell              =   86949, 
    FireBlastSpell              =  108853, 
    CombustionSpell             =  190319, 
    ShimmerSpell                =  212653,
    LivingBombDebuff            =  217694, 
    BlazingBarrierSpell         =  235313,
    FreneticSpeedBuff           =  236060, 
    LivingBombDebuff2           =  244813, 
    PhoenixFlamesSpell          =  257541,
    PhoenixFlamesDamage         =  257542,
    AlterTimeSpell              =  342245,
    ShiftingPowerSpell          =  382440,
    ShiftingPowerSpell2         =  382445, 
    FeelTheBurnBuff             =  383395, 
    WildfireBuff                =  383492,
    WildfireBuffStack           =  383493,
    FieryRushBuff               =  383637,
    FeveredIncantationBuffStack =  383811, 
    HyperthermiaBuff            =  383874, 
    TemporalVelocityBuff        =  384360, 
    OverflowingEnergyBuff       =  394195, 
    IceColdSpell                =  414658, 
    MassBarrierSpell            =  414660,
    BlazingBarrierBuff          =  414662,
    IntensifyingFlameBuff       =  419800, 
    SpellfireSphereBuffStack    =  448604, 
    ArcanePhoenixBuff           =  448659, 
    ManaCascadeBuffStack        =  449314, 
    MerelyASetbackBuff          =  449331, 
    SpellfireSpheresBuffStack   =  449400, 
    MeteoriteDamage             =  449569, 
    GravityLapseSpell           =  449700, 
    GravityLapseSpell2          =  449715, 
    GreaterPyroblastSpell       =  450421, 
    PyroblastDamage             =  450461, 
    FlamestrikeDamage           =  450462,
    ArcaneBarrageSpell          =  450499, 
    ArcaneBarrageDamage         =  450500,
    BurdenOfPowerBuff           =  451049, 
    GloriousIncandescenceBuff   =  451073, 
    LitFuseBuff                 =  453207,
    LivingBombDamage            =  453251, 
    ControlledDestructionDebuff =  453268, 
    ArcaneSurgeSpell            =  453326, 
    FiresIreBuff                =  453385,
    MeteoriteSpell              =  456139, 
    LingeringEmbersBuffStack    =  461145, 
    GravityLapseDamage          =  473291, 
    RollinHotBuff               = 1219035,
    PhoenixRebornBuffStack      = 1219304, 
    PhoenixRebornBuff           = 1219305, 
    BornOfFlameBuff             = 1219307, 
    
    // Paladin
    LightforgedBlessingSpell = 403460, 
    LightbearerSpell         = 469421, 
    
    
    // Shaman
    ChainHealSpell          =   1064,
    AncestralSpiritSpell    =   2008, 
    HealingSurgeSpell       =   8004,
    HealingStreamTotemSpell =  52042,  
    RiptideBuff             =  61295, 
    HealingRainSpell        =  73921, 
    RestorativeMistsSpell2  = 114083, 
    HealingTideSpell        = 114942, 
    WindRushBuff            = 192082,
    AncestralVigorBuff      = 207400, 
    RestorativeMistsSpell   = 294020, 
    EarthlivingWeaponBuff   = 382024, 
    ChainHealSpell2         = 458357, 
    ElementalResistanceBuff = 462568, 
}

public record Spell(int Id, string Name, string Icon);

public static class SpellExtensions
{
}