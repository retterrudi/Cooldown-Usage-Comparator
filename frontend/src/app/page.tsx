import {Fight} from "@/types/types";

export default async function Home() {
  const content = await getFightsAsync("NbJGzkjLPtThAc4W");

  return <div>
    <h1>Fights</h1>
    <ul>
      {content.map((fight: Fight) => (
        <li key={fight.Id}>{fight.Name} {fight.KeystoneLevel !== null ? fight.KeystoneLevel : "Empty"}</li>
      ))}
    </ul>
  </div>;
}

export async function getFightsAsync(fightCode: string): Promise<Fight[]> {
  const data: Response = await fetch(
    `http://localhost:5000/fights?reportCode=${fightCode}`
  );

  if (!data.ok) {
    throw Error("An error occurred during fetching of fights");
  }

  return data.json();
}