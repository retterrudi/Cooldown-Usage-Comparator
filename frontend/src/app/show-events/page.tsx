'use client'

import {FightEvent} from "@/types/types";
import {FormEvent, useState} from "react";
import Image from 'next/image';

const DOTNET_API_BASE_URL = "http://localhost:5000";

export default function ShowEventsPage() {
  const reportCode: string = "NbJGzkjLPtThAc4W";
  const fightId: number = 1;
  const playerId: number = 46;
  const gameClass: string = "Mage";

  const [fightEvents, setFightEvents] = useState<FightEvent[] | null>(null);

  const handleSearch = async (event?: FormEvent<HTMLFormElement>) => {
    if (event) {
      event.preventDefault();
    }

    // TODO
    if (!reportCode.trim() && !event) {
      return;
    }

    try {
      const url = `${DOTNET_API_BASE_URL}/timeline?reportCode=${encodeURIComponent(reportCode)}&fightId=${encodeURIComponent(fightId)}&playerId=${encodeURIComponent(playerId)}&gameClassAsString=${encodeURIComponent(gameClass)}`;
      const response = await fetch(url);

      if (!response.ok) {
        // TODO
        throw new Error("Fix me");
      }

      const data = (await response.json()) as FightEvent[];
      setFightEvents(data);
    } catch (e: unknown) {
      // TODO
      console.log(e);
    } finally {
      // TODO
    }
  };

  return (
    <div>
      <h1>Timeline</h1>
      <form onSubmit={handleSearch}>
        <button>START</button>
      </form>
      <div>
        {fightEvents && fightEvents.length > 0 ? (
          <ul>
            {fightEvents.map((fightEvent) => (
              <li key={fightEvent.timestamp + Math.random()}>
                {getTimeFromNumber(fightEvent.timestamp)} {fightEvent.abilityName} <Image src={"/spellIcons/"+ fightEvent.imageName} alt={fightEvent.imageName} width={48} height={48} />
              </li>
            ))}
          </ul>
        ) : (
          <p>Something went wrong!</p>
        )}
      </div>
    </div>
  );
}

function getTimeFromNumber(millis: number): string {
  const remainingMillis = millis % 1000;
  const numberOfSeconds = Math.floor(millis / 1000);
  const remainingSeconds = numberOfSeconds % 60;
  const numberOfMinutes = Math.floor(numberOfSeconds / 1000);

  return "[" + String(numberOfMinutes).padStart(2, "0")
    + ":" + String(remainingSeconds).padStart(2, "0")
    + ":" + String(remainingMillis).padStart(3, "0") + "]";
}