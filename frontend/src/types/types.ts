export interface Fight {
  difficulty: number | null;
  encounterId: number | null;
  endTime: number | null;
  friendlyPlayers: number[] | null;
  id: number | null;
  keystoneBonus: number | null;
  keystoneLevel: number | null;
  name: string | null;
  startTime: number | null;
}

export interface PlayerDetails {
  name: string | null;
  id: number | null;
  guid: number | null;
  type: string | null;
  server: string | null;
  region: string | null;
  icon: string | null;
  specs: PlayerSpec[] | null;
}

export interface PlayerSpec {
  spec: string | null;
  count: number;
}

export interface FightEvent {
  timestamp: number;
  abilityId: number;
  abilityName: string;
  imageName: string;
  // type: string; // Could be enum
}