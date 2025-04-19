namespace Cooldown_Usage_Comparator.Data;

public class SpellRepository
{
    public readonly Dictionary<AbilityGameId, Spell> Spells = new()
    {
        // Mage
        { AbilityGameId.FireballSpell, new Spell(133, "Fireball", "spell_fire_flamebolt.jpg") },
        { AbilityGameId.FlamestrikeSpell, new Spell(2120, "Flamestrike", "spell_fire_selfdestruct.jpg") },
        { AbilityGameId.Counterspell, new Spell(2139, "Counterspell", "spell_frost_iceshock.jpg") },
        { AbilityGameId.ScorchSpell, new Spell(2948, "Scorch", "spell_fire_soulburn.jpg") },
        { AbilityGameId.PyroblastSpell, new Spell(11366, "Pyroblast", "spell_fire_fireball02.jpg")},
        { AbilityGameId.MirrorImageSpell, new Spell(55342, "Mirror Image", "spell_magic_lesserinvisibilty.jpg")},
        { AbilityGameId.CauterizeSpell, new Spell(86949, "Cauterize", "spell_fire_rune.jpg")},
        { AbilityGameId.FireBlastSpell, new Spell(108853, "Fire Blast", "spell_fire_fireball.jpg")},
        { AbilityGameId.CombustionSpell, new Spell(190319, "Combustion", "spell_fire_sealoffire.jpg")},
        { AbilityGameId.ShimmerSpell, new Spell(212653, "Shimmer", "spell_arcane_massdispel")},
        { AbilityGameId.BlazingBarrierSpell, new Spell(235313, "Blazing Barrier", "ability_mage_moltenarmor.jpg")},
        { AbilityGameId.PhoenixFlamesSpell, new Spell(257541, "Phoenix Flames", "artifactability_firemage_phoenixbolt.jpg")},
        { AbilityGameId.AlterTimeSpell, new Spell(342245, "Alter Time", "spell_mage_altertime.jpg")},
        { AbilityGameId.ShiftingPowerSpell, new Spell(382440, "Shifting Power", "inv_ability_mage_shiftingpower.jpg")},
        { AbilityGameId.MassBarrierSpell, new Spell(414660, "Mass Barrier", "ability_racial_magicalresistance.jpg")},
    };
}

public enum AbilityGameId
{
    // Error
    // Error = -1,
    
    // Mage
    FireballSpell = 133,
    FlamestrikeSpell = 2120,
    Counterspell = 2139,
    ScorchSpell = 2948,
    PyroblastSpell = 11366,
    MirrorImageSpell = 55342, 
    CauterizeSpell = 86949, 
    FireBlastSpell = 108853, 
    CombustionSpell = 190319, 
    ShimmerSpell = 212653,
    BlazingBarrierSpell = 235313,
    PhoenixFlamesSpell = 257541,
    AlterTimeSpell = 342245,
    ShiftingPowerSpell = 382440,
    MassBarrierSpell = 414660,
    
}

public record Spell(int Id, string Name, string Icon);

public static class SpellExtensions
{
}