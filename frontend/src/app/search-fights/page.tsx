'use client';

import {FormEvent, useState} from "react";
import {Fight} from "@/types/types";

const DOTNET_API_BASE_URL = "http://localhost:5000";

if (!DOTNET_API_BASE_URL) {
  console.warn("Warning: Backend Base-URL is not set");
}

export default function SearchFightsPage() {
  const [reportCode, setReportCode] = useState<string>('');
  // TODO: Should this really be nullable or just an empty list?
  const [fights, setFights] = useState<Fight[] | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);
  const [hasSearched, setHasSearched] = useState<boolean>(false);

  const handleSearch = async (event?: FormEvent<HTMLFormElement>) => {
    if (event) {
      event.preventDefault(); // Prevent default form submission
    }

    if (!reportCode.trim() && !event) {
      setError("Please enter a fight code.");
      setFights(null);
      setHasSearched(true);
      return;
    }

    if (!DOTNET_API_BASE_URL) {
      setError("Backend is not connected");
      setIsLoading(false);
      return;
    }

    setIsLoading(true);
    setError(null);
    setFights(null); // Clear previous results
    setHasSearched(true);

    try {
      const url = `${DOTNET_API_BASE_URL}/fights?reportCode=${encodeURIComponent(reportCode)}`;
      console.log(url);
      const response = await fetch(
        // `${DOTNET_API_BASE_URL}/fights?fightCode=${encodeURIComponent(fightCode)}`
        url
      );

      if (!response.ok) {
        let errorMessage = `Error: ${response.status} ${response.statusText}`;
        try {
          const errorData = await response.json();
          errorMessage = errorData.message || errorData.title || errorMessage;
        } catch (e) {
          // TODO: This should be handle in an other way
          // If parsing error JSON fails, stick to the status text
          console.log(e);
        }
        throw new Error(errorMessage);
      }

      const data = (await response.json()) as Fight[];
      setFights(data);
    } catch (e: unknown) {
      if (e instanceof Error) {
        setError(e.message);
      } else {
        setError("An unknown error occurred while fetching fights.");
      }
      console.error("Fetch error: ", e);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div style={{ padding: "20px", fontFamily: "Arial, sans-serif"}}>
      <h1>Search Fights</h1>
      <form onSubmit={handleSearch} style={{ marginBottom: "20px"}}>
        <input
          type="text"
          value={reportCode}
          onChange={(e) => setReportCode(e.target.value)}
          placeholder="Enter a fight code"
          disabled={isLoading}
          style={{ padding: "10px", marginRight: "10px", width: "300px" }}
          aria-label="Search fight code"
        />
        <button
          type="submit"
          disabled={isLoading || !reportCode.trim()}
          style={{ padding: "10px 15px", cursor: "pointer" }}
        >
          {isLoading ? "Searching..." : "Search"}
        </button>
      </form>

      {isLoading && <p>Loading results...</p>}

      {error && <p style={{ color: "red" }}>{error}</p>}

      {hasSearched && !isLoading && !error && (
        <div>
          <h2>Search Results</h2>
          {fights && fights.length > 0 ? (
            <ul style={{ listStyleType: "none", padding: 0 }}>
              {fights.map((fight) => (
                <li key={fight.Id || Math.random()} style={{ border: "1px solid #eee", padding: "10px", marginBottom: "10px"}}>
                  <strong>Name:</strong> {fight.Name ?? "N/A"} <br />
                  <strong>Keystone Level:</strong> {fight.KeystoneLevel ?? "N/A"}
                </li>
              ))}
            </ul>
          ) : (
            <p>No fights found for &#34;{reportCode}&#34;.</p>
          )}
        </div>
      )}
    </div>
  );
}