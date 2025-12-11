Projektet kræver .NET 8 SDK og en SQL Server database

For at forbinde til og oprette database:
- Ret ConnectionStrings i appsettings.json.
- Kør projektet igen, så seed-funktionen opretter data automatisk

I seed funktion er disse data oprettet:
- 4 lægehuse med ydernumre: 100001, 100002, 100003, 100004
- 4 apoteker der kan foretages receptudleveringer på
- 3 recepter med tilknyttet ordinationer på cprnumrene:
    - 2 recepter på 2010035647
    - 1 recept på 2205015643