'use client'

import {FormEvent, useState} from "react";
import {PlayerDetails} from "@/types/types";

const DOTNET_API_BASE_URL = "http://localhost:5000";

export default function SearchPlayersPage() {
  const reportCode: string = "NbJGzkjLPtThAc4W";
  const fightId: number = 1;

  const [players, setPlayers] = useState<PlayerDetails[] | null>(null);

  const handleSearch = async (event?: FormEvent<HTMLFormElement>) => {
    if (event) {
      event.preventDefault();
    }

    if (!reportCode.trim() && !event) {
      return;
    }
    
    try {
      const url = `${DOTNET_API_BASE_URL}/players?reportCode=${encodeURIComponent(reportCode)}&fightId=${encodeURIComponent(fightId)}`;
      const response = await fetch(
        url
      );
      
      if (!response.ok) {
        // TODO: Handle bad request
        throw new Error("Error during fetch (fix me).")
      }
      
      const data = (await response.json()) as PlayerDetails[];
      setPlayers(data);
    } catch (e: unknown) {
      // TODO: Handle
      console.log(e);
    } finally {
      // TODO
    }
  };
  
  return (
    <div>
      <h1>Search Players</h1>
      <form onSubmit={handleSearch}>
        <button>
          Submit -{">"} Change me later!
        </button>
      </form>
      <div>
        <h2>Search Results</h2>
        {players && players.length > 0 ? (
          <ul>
            {players.map((player) => (
              <li key={player.id || Math.random()}>
                <strong>Name:</strong> {player.name ?? "N/A"} <br/>
                <strong>Server:</strong> {player.server ?? "N/A"} <br/>
                <strong>Spec:</strong> {player.specs ? player.specs.map((spec) => (spec.spec?.toString())) : ""} <br/>
              </li>
            ))}
          </ul>
        ) : (
          <p>No players found for &#34;{reportCode}&#34;</p>
        )} 
      </div>
    </div>
  );
}