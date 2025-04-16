﻿using Cooldown_Usage_Comparator.Warcraftlogs.Models;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Comparers;

public class EventComparer : IEqualityComparer<Event>
{
    public bool Equals(Event? x, Event? y)
    {
        if (x is null || y is null) return false;
        return x.AbilityGameId == y.AbilityGameId && x.Type == y.Type;
    }
    
    public int GetHashCode(Event? e)
    {
        if (e is null) return 0;

        var hashAbilityGameId = e.AbilityGameId is null ? 0 : e.AbilityGameId.GetHashCode();
        var hashType = e.Type is null ? 0 : e.Type.GetHashCode();

        return hashAbilityGameId ^ hashType;
    }
}